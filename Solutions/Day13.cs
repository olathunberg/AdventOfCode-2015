using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public static class Day13
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day13.txt");

            var result1 = GetBestSeatingsGain(input, false);
            Console.WriteLine($"Day 13: Result part 1: {result1}");   // 709

            var result2 = GetBestSeatingsGain(input, true);
            Console.WriteLine($"Day 13: Result part 2: {result2}");   // 668
            Console.WriteLine();
        }

        public static int GetBestSeatingsGain(string[] input, bool addMe)
        {
            var seatings = GetNames(input, addMe).GetPermutations().Select(x => x.ToList()).ToList();
            foreach (var seating in seatings)
                seating.Add(seating.First());

            var gains = GetGains(input);

            return seatings.Select(seating => seating.Windowed(2).Sum(x => GainByNames(gains, x[0], x[1]) +
                                                                           GainByNames(gains, x[1], x[0])))
                           .Max();
        }

        private static int GainByNames(List<(string name, string nextTo, int gain)> gains, string name, string nextTo)
        {
            if (name == "Me" || nextTo == "Me")
                return 0;

            return gains.First(x => x.name == name && x.nextTo == nextTo).gain;
        }

        private static string[] GetNames(string[] input, bool addMe)
        {
            var result = input.Select(x => x.Split(' ').First()).Distinct().ToList();
            if (addMe)
                result.Add("Me");

            return result.ToArray();
        }

        private static List<(string name, string nextTo, int gain)> GetGains(string[] input)
        {
            var result = new List<(string name, string nextTo, int gain)>();

            foreach (var item in input)
            {
                var split = item
                    .Replace("would gain ", "")
                    .Replace("would lose ", "-")
                    .TrimEnd('.')
                    .Split(' ');
                result.Add((split.First(), split.Last(), int.Parse(split[1])));
            }

            return result;
        }
    }
}
