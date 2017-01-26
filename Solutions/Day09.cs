using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public static class Day09
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day09.txt");

            int result1 = GetShortest(input);
            Console.WriteLine($"Day 09: Result part 1: {result1}");   // 117

            int result2 = GetLongest(input);
            Console.WriteLine($"Day 09: Result part 2: {result2}");   // 909
            Console.WriteLine();
        }

        public static int GetShortest(string[] input)
        {
            var distances = input.Select(x => x.ParseLine()).ToList();
            var places = distances.SelectMany(x => new string[] { x.Item1, x.Item2 }).Distinct().ToList();
            var permutations = places.GetPermutations(places.Count);

            var result1 = permutations.Select(x => x.GetDistance(distances)).Min();
            return result1;
        }

        public static int GetLongest(string[] input)
        {
            var distances = input.Select(x => x.ParseLine()).ToList();
            var places = distances.SelectMany(x => new string[] { x.Item1, x.Item2 }).Distinct().ToList();
            var permutations = places.GetPermutations(places.Count);

            var result1 = permutations.Select(x => x.GetDistance(distances)).Max();
            return result1;
        }

        private static (string, string, int) ParseLine(this string line)
        {
            var split = line.Split(new string[] { " = ", " to " }, StringSplitOptions.RemoveEmptyEntries);
            return (split[0], split[1], int.Parse(split[2]));
        }

        private static int GetDistance(this IEnumerable<string> route, IEnumerable<(string, string, int)> distances)
        {
            return route
                .Windowed(2)
                .Sum(x => distances.First(z => (z.Item1 == x[0] && z.Item2 == x[1]) || (z.Item1 == x[1] && z.Item2 == x[0])).Item3);
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
