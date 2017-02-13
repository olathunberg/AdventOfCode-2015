using System;

namespace Solutions
{
    public class Day25
    {
        public static void Solve()
        {
            var result1 = GetCode(3010, 3019);
            Console.WriteLine($"Day 25: Result part 1: {result1:N0}");   // 8997277

            Console.WriteLine();
        }

        public static long GetCode(uint row, uint col)
        {
            var codeNum = GetCodeNumber(row, col);

            var code = 20151125L;
            for (int i = 1; i < codeNum; i++)
                code = code * 252533 % 33554393;

            return code;
        }

        public static long GetCodeNumber(uint row, uint col)
        {
            var code = 1L;

            for (int i = 1; i < row; i++)
                code += i;
            for (int i = 2; i <= col; i++)
                code += (i+row-1);

            return code;
        }
    }
}
