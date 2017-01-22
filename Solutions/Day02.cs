using System;
using System.Linq;

namespace Solutions
{
    public static class Day02
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day02.txt");

            var result1 = input.Sum(x => CalcPaperArea(x));
            var result2 = input.Sum(x => CalcRibbonLength(x));

            Console.WriteLine($"Day 02: Result part 1: {result1}");   // 1588178
            Console.WriteLine($"Day 02: Result part 2: {result2}");   // 3783758
            Console.WriteLine();
        }

        public static int CalcPaperArea(string input)
        {
            var d = GetDimensions(input);

            var side1 = d.l * d.w;
            var side2 = d.w * d.h;
            var side3 = d.h * d.l;
            var result = 2 * side1 + 2 * side2 + 2 * side3 + Math.Min(Math.Min(side1, side2), side3);
            return result;
        }

        public static int CalcRibbonLength(string input)
        {
            var d = GetDimensions(input);

            var volume = d.l * d.w * d.h;

            var peri1 = 2 * (d.l + d.h);
            var peri2 = 2 * (d.h + d.w);
            var peri3 = 2 * (d.w + d.l);
            var result = Math.Min(Math.Min(peri1, peri2), peri3) + volume;
            return result;
        }

        private static (int l, int w, int h) GetDimensions(string input)
        {
            var split = input.Split('x');
            return (int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }
    }
}
