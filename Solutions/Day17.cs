using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day17
    {
        public static void Solve()
        {
            var availContainers = new int[]
            {
                33, 14, 18, 20, 45, 35, 16, 35,  1, 13,
                18, 13, 50, 44, 48,  6, 24, 41, 30, 42
            };

            var possibles = GetPossibleCombinations(availContainers, 150);
            var result1 = possibles.Count();
            Console.WriteLine($"Day 17: Result part 1: {result1}");   // 1304

            var result2 = possibles.GroupBy(x => x.Count).OrderBy(x => x.Key).First().Count();
            Console.WriteLine($"Day 17: Result part 2: {result2}");   // 18

            Console.WriteLine();
        }

        public static IEnumerable<List<int>> GetPossibleCombinations(int[] availContainers, int amountToFill)
        {
            // First attemted to check all permutations and see which combinations starting values summed to amount
            // Took TOO long time
            return GetPossibles(new List<int>(), availContainers, amountToFill);
        }

        private static List<List<int>> GetPossibles(List<int> filled, int[] stillAvail, int amountToFill)
        {
            var result = new List<List<int>>();

            var leftToFill = amountToFill - filled.Sum();

            for (int i = 0; i < stillAvail.Length; i++)
            {
                // Skip if this cannot be entirely filled
                if (stillAvail[i] > leftToFill) continue;

                // Fill this up in new list, so we can reuse for other n
                var newFilled = filled.ToList();
                newFilled.Add(stillAvail[i]);

                // If we filled all, return filled list
                if (stillAvail[i] == leftToFill)
                    result.Add(newFilled);
                else
                {
                    // Try all stillavail, but current
                    foreach (var item in GetPossibles(newFilled, stillAvail.Skip(i + 1).ToArray(), amountToFill))
                        result.Add(item);
                }
            }
            return result;
        }
    }
}