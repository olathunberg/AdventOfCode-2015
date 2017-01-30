using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day16
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day16.txt");

            var knownProperties = new(string prop, int value)[]
            {
                ("children", 3),
                ("cats", 7),
                ("samoyeds", 2),
                ("pomeranians", 3),
                ("akitas", 0),
                ("vizslas", 0),
                ("goldfish", 5),
                ("trees", 3),
                ("cars", 2),
                ("perfumes", 1)
            };
            var aunties = input.Select(x => GetAuntProperties(x));

            foreach (var property in knownProperties)
            {
                aunties = aunties
                    .Where(x => (x.Item2.ContainsKey(property.prop) && x.Item2[property.prop] == property.value)
                             || !x.Item2.ContainsKey(property.prop));
            }

            var result1 = aunties.First();
            Console.WriteLine($"Day 16: Result part 1: {result1.aunt}");   // 40

            var realAunties = input.Select(x => GetAuntProperties(x));

            foreach (var property in knownProperties)
            {
                if (property.prop == "cats" || property.prop == "trees")
                    realAunties = realAunties
                        .Where(x => (x.Item2.ContainsKey(property.prop) && x.Item2[property.prop] > property.value)
                                 || !x.Item2.ContainsKey(property.prop));
                else if (property.prop == "pomeranians" || property.prop == "goldfish")
                    realAunties = realAunties
                        .Where(x => (x.Item2.ContainsKey(property.prop) && x.Item2[property.prop] < property.value)
                                 || !x.Item2.ContainsKey(property.prop));
                else
                    realAunties = realAunties
                        .Where(x => (x.Item2.ContainsKey(property.prop) && x.Item2[property.prop] == property.value)
                                 || !x.Item2.ContainsKey(property.prop));
            }

            var result2 = realAunties.First();
            Console.WriteLine($"Day 16: Result part 2: {result2.aunt}");   // 241

            Console.WriteLine();
        }

        private static (string aunt, Dictionary<string, int>) GetAuntProperties(string input)
        {
            var aunt = input.Substring(0, input.IndexOf(": ")).Split(' ').Last();
            var properties = input
                .Remove(0, input.IndexOf(": ") + 2)
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(x => x[0], x => int.Parse(x[1]));

            return (aunt, properties);
        }
    }
}
