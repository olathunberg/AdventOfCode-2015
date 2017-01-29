using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day15
    {
        public static void Solve()
        {
            var ingredients = new(int, Ingredient)[]
            {
                (0, new Ingredient(2,0,-2,0,3)),
                (0, new Ingredient(0,5,-3,0,3)),
                (0, new Ingredient(0,0,5,-1,8)),
                (0, new Ingredient(0,-1,0,5,8))
            };

            var scores = GetAllRecipeScores(ingredients);
            var result1 = scores.Select(x => x.score).Max();
            Console.WriteLine($"Day 15: Result part 1: {result1}");   // 21367368

            var result2 = scores.Where(x => x.calories <= 500).Select(x => x.score).Max();
            Console.WriteLine($"Day 15: Result part 2: {result2}");   // 1766400

            Console.WriteLine();
        }

        public static IEnumerable<(long score, long calories)> GetAllRecipeScores((int, Ingredient)[] ingredients)
        {
            var perms = Enumerable.Range(1, 99)
                          .GetCombinations(ingredients.Length)
                          .AsParallel()
                          .Where(x => x.Sum() == 100)
                          .ToList();

            return EnumerateScore(perms, ingredients).ToList();
        }

        private static IEnumerable<(long score, long calories)> EnumerateScore(IEnumerable<IEnumerable<int>> perms, (int, Ingredient)[] ingredients)
        {
            foreach (var perm in perms)
            {
                var list = perm.ToArray();
                for (int i = 0; i < ingredients.Length; i++)
                    ingredients[i].Item1 = list[i];

                yield return (CookieScore(ingredients), CookieCalories(ingredients));
            }
        }

        private static long CookieCalories((int amount, Ingredient)[] ingredients)
        {
            return ingredients.Sum(x => x.amount * x.Item2.Calories);
        }

        private static long CookieScore((int amount, Ingredient)[] ingredients)
        {
            var totCap = ingredients.Sum(x => x.amount * x.Item2.Capacity);
            var totDur = ingredients.Sum(x => x.amount * x.Item2.Durability);
            var totFla = ingredients.Sum(x => x.amount * x.Item2.Flavor);
            var totTex = ingredients.Sum(x => x.amount * x.Item2.Texture);

            return (totCap >= 0 ? totCap : 0) *
                   (totDur >= 0 ? totDur : 0) *
                   (totFla >= 0 ? totFla : 0) *
                   (totTex >= 0 ? totTex : 0);
        }

        public class Ingredient
        {
            public Ingredient(int capacity, int durability, int flavor, int texture, int calories)
            {
                Capacity = capacity;
                Durability = durability;
                Flavor = flavor;
                Texture = texture;
                Calories = calories;
            }

            public int Capacity { get; private set; }

            public int Durability { get; private set; }

            public int Flavor { get; private set; }

            public int Texture { get; private set; }

            public int Calories { get; private set; }
        }
    }
}
