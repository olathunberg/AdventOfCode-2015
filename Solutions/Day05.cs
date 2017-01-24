using System;
using System.Linq;

namespace Solutions
{
    public class Day05
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day05.txt");

            var result1 = input.Count(z => IsNice1(z));
            var result2 = input.Count(z => IsNice2(z));

            Console.WriteLine($"Day 05: Result part 1: {result1}");   // 236
            Console.WriteLine($"Day 05: Result part 2: {result2}");   // 51
            Console.WriteLine();
        }

        public static bool IsNice1(string input)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var hasThreeVowels = input.Count(x => vowels.Contains(x)) >= 3;

            var hasDoubleLetter = input.Windowed(2).Any(x => x[0] == x[1]);

            var forbiddenStrings = new string[] { "ab", "cd", "pq", "xy" };
            var hasForbidden = input.Windowed(2).Any(x => forbiddenStrings.Contains($"{x[0]}{x[1]}"));

            return hasThreeVowels && hasDoubleLetter && !hasForbidden;
        }

        public static bool IsNice2(string input)
        {
            var rule1 = IsNice2PairRule(input);
            var rule2 = input.Windowed(3).Any(x => x[0] == x[2]);

            return rule1 && rule2;
        }

        private static bool IsNice2PairRule(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                var pair = $"{input[i]}{input[i + 1]}";
                var temp1 = input.Substring(0, i);
                if (temp1.Windowed(2).Any(x => $"{x[0]}{x[1]}" == pair))
                    return true;
                var temp2 = input.Substring(i+2);
                if (temp2.Windowed(2).Any(x => $"{x[0]}{x[1]}" == pair))
                    return true;
            }
            return false;
        }
    }
}
