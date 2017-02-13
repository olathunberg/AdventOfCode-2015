using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day24
    {
        public static void Solve()
        {
            var indata = System.IO.File.ReadAllLines(@"Input\Day24.txt")
                .Select(x => int.Parse(x))
                .ToList();

            var result1 = GetWinningQE(indata, 3);
            Console.WriteLine($"Day 24: Result part 1: {result1:N0}");   // 11846773891

            var result2 = GetWinningQE(indata, 4);
            Console.WriteLine($"Day 24: Result part 2: {result2:N0}");   // 80393059


            Console.WriteLine();
        }

        public static long GetWinningQE(List<int> indata, int chunks)
        {
            var winningGroup = GetBalancedLoad(indata, chunks)
                .OrderBy(z => z.Aggregate(1L, (x1, x2) => x1 * x2))
                .First();

            return winningGroup.Aggregate(1L, (x1, x2) => x1 * x2);
        }

        private static List<int[]> GetBalancedLoad(List<int> indata, int chunks)
        {
            List<int[]> GetGroups(IEnumerable<int> data, int leaveCount, int balanceLoad)
            {
                for (int i = 1; i < data.Count() - leaveCount; i++)
                {
                    var tre = Combinations(i, data.ToArray()).Where(x => x.Sum() == balanceLoad).ToList();
                    if (tre.Any())
                        return tre;
                }
                return null;
            }

            var targetSum = indata.Sum() / chunks;
            var result = new List<(int[], int[], int[])>();
            var firstGroups = GetGroups(indata, chunks - 1, targetSum);

            return firstGroups;
        }

        // Based on https://www.videlin.eu/2016/04/10/how-to-generate-combinations-without-repetition-interatively-in-c/
        private static IEnumerable<int[]> Combinations(int combinationLength, int[] indata)
        {
            var totalResult = new List<int[]>();
            var result = new int[combinationLength];
            var stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value < indata.Count())
                {
                    result[index++] = indata[value++];
                    stack.Push(value);
                    if (index == combinationLength)
                    {
                        yield return (int[])result.Clone();
                        break;
                    }
                }
            }
        }
    }
}
