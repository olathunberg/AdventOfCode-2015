using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day22
    {
        public static void Solve()
        {
            var boss = new Boss
            {
                HitPoints = 55,
                Damage = 8
            };
            var player = new Wizard
            {
                HitPoints = 50,
                AvailableMana = 500,
                ActiveSpells = new List<(Spell spell, int timer)>(),
                UsedSpells = new List<Spell>()
            };

            var result1 = Battle(boss, player, false);
            Console.WriteLine($"Day 22: Result part 1: {result1}");   // 953

            var result2 = Battle(boss, player, true);
            Console.WriteLine($"Day 22: Result part 2: {result2}");   // 1289

            Console.WriteLine();
        }

        public static int Battle(Boss boss, Wizard player, bool isHard)
        {
            var playerWins = new List<Wizard>();
            var openSet = new Queue<(Boss boss, Wizard player)>();
            openSet.Enqueue((boss, player));
            var record = 0;

            while (openSet.Count > 0)
            {
                var set = openSet.Dequeue();

                foreach (var spell in Enum.GetValues(typeof(Spell)).Cast<Spell>())
                {
                    if (set.player.ActiveSpells.Where(x => x.timer > 1 && x.spell == spell).Any())
                        continue;

                    var wizardClone = set.player.Clone();
                    var bossClone = set.boss.Clone();

                    if (isHard)
                        wizardClone.HitPoints--;

                    if (wizardClone.HitPoints > 0 && bossClone.HitPoints > 0)
                        SpellEffects(bossClone, wizardClone);

                    if (wizardClone.HitPoints > 0 && bossClone.HitPoints > 0)
                        CastSpell(bossClone, wizardClone, spell);

                    if (wizardClone.AvailableMana <= 0)
                        continue;

                    if (wizardClone.HitPoints > 0 && bossClone.HitPoints > 0)
                        SpellEffects(bossClone, wizardClone);

                    if (wizardClone.HitPoints > 0 && bossClone.HitPoints > 0)
                        BossAttack(bossClone, wizardClone);

                    if (wizardClone.HitPoints <= 0)
                        continue;

                    if (wizardClone.HitPoints > 0 && bossClone.HitPoints <= 0)
                    {
                        if (record == 0 || wizardClone.SpentMana < record)
                            record = wizardClone.SpentMana;
                        playerWins.Add(wizardClone);
                        break;
                    }

                    if (record == 0 || wizardClone.SpentMana < record)
                        openSet.Enqueue((bossClone, wizardClone));
                }
            }

            var xx = playerWins.OrderBy(x => x.SpentMana);
            return xx.First().SpentMana;
        }

        private static void SpellEffects(Boss boss, Wizard player)
        {
            player.SpelledArmor = 0;
            for (int i = 0; i < player.ActiveSpells.Count; i++)
            {
                switch (player.ActiveSpells[i].spell)
                {
                    case Spell.Shield:
                        player.SpelledArmor += 7;
                        break;
                    case Spell.Poison:
                        boss.HitPoints -= 3;
                        break;
                    case Spell.Recharge:
                        player.AvailableMana += 101;
                        break;
                }
                player.ActiveSpells[i] = (player.ActiveSpells[i].spell, player.ActiveSpells[i].timer - 1);
            }
            player.ActiveSpells.RemoveAll(x => x.timer <= 0);
        }

        private static void BossAttack(Boss boss, Wizard player)
        {
            player.HitPoints -= Math.Max(1, boss.Damage - player.SpelledArmor);
        }

        private static void CastSpell(Boss boss, Wizard player, Spell spell)
        {
            int timer = 1;
            int cost = 0;
            switch (spell)
            {
                case Spell.Shield:
                    timer = 6;
                    cost = 113;
                    break;
                case Spell.Poison:
                    timer = 6;
                    cost = 173;
                    break;
                case Spell.Recharge:
                    timer = 5;
                    cost = 229;
                    break;
                case Spell.MagicMissile:
                    cost = 53;
                    boss.HitPoints -= 4;
                    break;
                case Spell.Drain:
                    cost = 73;
                    boss.HitPoints -= 2;
                    player.HitPoints += 2;
                    break;
            }

            player.UsedSpells.Add(spell);
            player.ActiveSpells.Add((spell, timer));
            player.SpentMana += cost;
            player.AvailableMana -= cost;
        }

        public enum Spell
        {
            Poison,
            MagicMissile,
            Drain,
            Shield,
            Recharge
        }

        public class Boss
        {
            public int HitPoints;
            public int Damage;

            public Boss Clone()
            {
                return (Boss)this.MemberwiseClone();
            }
        }

        public class Wizard
        {
            public int HitPoints;
            public int Damage;
            public int AvailableMana;
            public int SpentMana;
            public int SpelledArmor;
            public List<(Spell spell, int timer)> ActiveSpells;
            public List<Spell> UsedSpells;

            public Wizard Clone()
            {
                var newSpells = new(Spell, int)[this.ActiveSpells.Count];
                this.ActiveSpells.CopyTo(newSpells);
                var newUsedSpells = new Spell[this.UsedSpells.Count];
                this.UsedSpells.CopyTo(newUsedSpells);
                return new Wizard
                {
                    HitPoints = this.HitPoints,
                    Damage = this.Damage,
                    AvailableMana = this.AvailableMana,
                    SpentMana = this.SpentMana,
                    SpelledArmor = this.SpelledArmor,
                    ActiveSpells = newSpells.ToList(),
                    UsedSpells = newUsedSpells.ToList()
                };
            }
        }
    }
}
