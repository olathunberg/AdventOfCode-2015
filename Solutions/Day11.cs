using System;
using System.Linq;

namespace Solutions
{
    public static class Day11
    {
        public static void Solve()
        {
            var input = "hxbxwxba";

            var result1 = GetNetPass(input);
            Console.WriteLine($"Day 11: Result part 1: {result1}");   // hxbxxyzz

            var result2 = GetNetPass(result1);
            Console.WriteLine($"Day 11: Result part 2: {result2}");   // hxcaabcc
            Console.WriteLine();
        }

        public static string GetNetPass(string pass)
        {
            var newPass = Generate(pass);
            while (!IsValid(newPass))
                newPass = Generate(newPass);

            return newPass;
        }

        private static string Generate(string pass)
        {
            var newPass = pass.ToCharArray();
            var inc = newPass.Last(x => x <= 'z');

            for (int i = newPass.Length - 1; i > 0; i--)
            {
                if (newPass[i] == 'z')
                    newPass[i] = 'a';
                else
                {
                    newPass[i] = (char)((int)newPass[i] + 1);
                    break;
                }
            }

            return new string(newPass);
        }

        public static bool IsValid(string pass)
        {
            var rule1 = pass.Windowed(3).Any(x => x[1] == x[0] + 1 && x[2] == x[1] + 1);
            var rule2 = !pass.Any(x => x == 'i' || x == 'o' || x == 'l');

            var pairs = pass.Skip(1)
                .Select((x, i) => (i, x))
                .Windowed(2)
                .Where(x => x[0].Item2 == x[1].Item2)
                .Select(x => x);

            var rule3 = pairs.Where(x => !pairs
                                            .Select(z => z[1].Item1)
                                            .Contains(x[0].Item1))
                             .Count() >= 2;

            return rule1 && rule2 && rule3;
        }
    }
}
