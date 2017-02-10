using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day21
    {
        public static void Solve()
        {
            var boss = new GameCharacter
            {
                HitPoints = 100,
                Damage = 8,
                Armor = 2
            };

            var shopItems = ShopItems()
                .Distinct();

            var result1 = shopItems
                .OrderBy(x => x.Cost)
                .First(x => IsPlayerWinning(boss, 100, x));
            Console.WriteLine($"Day 21: Result part 1: {result1.Cost}");   // 91

            var result2 = ShopItems()
                .OrderByDescending(x => x.Cost)
                .Where(x => !IsPlayerWinning(boss, 100, x))
                .First();
            Console.WriteLine($"Day 21: Result part 2: {result2.Cost}");   // 158

            Console.WriteLine();
        }

        public static bool IsPlayerWinning(GameCharacter boss, int playerHitPoints, (int Cost, int Damage, int Armor) shopItems)
        {
            var battleBoss = new GameCharacter
            {
                HitPoints = boss.HitPoints,
                Armor = boss.Armor,
                Damage = boss.Damage
            };
            var battlePlayer = new GameCharacter
            {
                HitPoints = playerHitPoints,
                Armor = shopItems.Armor,
                Damage = shopItems.Damage
            };

            var playerAttacks = true;

            while (battleBoss.HitPoints > 0 && battlePlayer.HitPoints > 0)
            {
                if (playerAttacks)
                    Attack(ref battlePlayer, ref battleBoss);
                else
                    Attack(ref battleBoss, ref battlePlayer);

                playerAttacks = !playerAttacks;
            }

            return battlePlayer.HitPoints > 0;

            // Fast cheat!
            // Since we start at the same hitpoints and player starts
            // Player only needs to do at least the same amount of damage
            // return (player.Damage - boss.Armor) >= (boss.Damage - player.Armor);
        }

        private static void Attack(ref GameCharacter attacker, ref GameCharacter defender)
        {
            if (attacker.Damage <= defender.Armor)
                defender.HitPoints--;
            else
                defender.HitPoints -= attacker.Damage - defender.Armor;
        }

        private static IEnumerable<(int Cost, int Damage, int Armor)> ShopItems()
        {
            var weapons = new(int, int, int)[]
                {
                    ( 8, 4, 0),
                    (10, 5, 0),
                    (25, 6, 0),
                    (40, 7, 0),
                    (74, 8, 0)
                };
            var armor = new(int, int, int)[]
                 {
                    (  0, 0, 0),
                    ( 13, 0, 1),
                    ( 31, 0, 2),
                    ( 53, 0, 3),
                    ( 75, 0, 4),
                    (102, 0, 5)
                };
            var rings = new(int, int, int)[]
             {
                    (  0, 0, 0),
                    ( 25, 1, 0),
                    ( 50, 2, 0),
                    (100, 3, 0),
                    ( 20, 0, 1),
                    ( 40, 0, 2),
                    ( 80, 0, 3)
                };

            for (int w = 0; w < weapons.Length; w++)
                for (int a = 0; a < armor.Length; a++)
                    for (int r1 = 0; r1 < rings.Length; r1++)
                        for (int r2 = 0; r2 < rings.Length; r2++)
                        {
                            var costSum = weapons[w].Item1 + armor[a].Item1 + rings[r1].Item1 + rings[r2].Item1;
                            var damageSum = weapons[w].Item2 + armor[a].Item2 + rings[r1].Item2 + rings[r2].Item2;
                            var armorSum = weapons[w].Item3 + armor[a].Item3 + rings[r1].Item3 + rings[r2].Item3;

                            yield return (costSum, damageSum, armorSum);
                        }
        }

        public struct GameCharacter
        {
            public int HitPoints;
            public int Damage;
            public int Armor;
        }
    }
}
