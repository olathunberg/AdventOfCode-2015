using System;
using System.Linq;

namespace Solutions
{
    public class Day03
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllText(@"Input\Day03.txt");

            var result1 = VisitedHouses(input).Count;
            var result2 = VisistedWithRobotSanta(input);

            Console.WriteLine($"Day 03: Result part 1: {result1}");   // 2565
            Console.WriteLine($"Day 03: Result part 2: {result2}");   // 2639
            Console.WriteLine();
        }

        public static System.Collections.Generic.Dictionary<(int, int), int> VisitedHouses(string input)
        {
            var current = (0, 0);
            var visited = new System.Collections.Generic.Dictionary<(int, int), int>
            {
                { current, 1 }
            };
            foreach (var dir in input)
            {
                current = Move(dir, current);
                if (visited.ContainsKey(current))
                    visited[current] = visited[current] + 1;
                else
                    visited.Add(current, 1);
            }
            return visited;
        }

        public static int VisistedWithRobotSanta(string input)
        {
            var santaPath = VisitedHouses(String.Concat (input.Where((x, idx) => idx % 2 == 0)));
            var roboPath = VisitedHouses(String.Concat(input.Where((x, idx) => idx % 2 != 0)));

            var totalCount = santaPath.Select(x => x.Key).Union(roboPath.Select(x => x.Key)).Distinct().Count();
            return totalCount;
        }

        private static (int x, int y) Move(char instruction, (int, int) current)
        {
            switch (instruction)
            {
                case '>': return (current.Item1 + 1, current.Item2);
                case '<': return (current.Item1 - 1, current.Item2);
                case '^': return (current.Item1, current.Item2 - 1);
                case 'v': return (current.Item1, current.Item2 + 1);
                default:
                    return current;
            }
        }
    }
}
