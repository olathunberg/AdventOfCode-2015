using System;

namespace Solutions
{
    public static class Day01
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllText(@"Input\Day01.txt");

            var (floor, enteredBasementAt) = Count(input);
            Console.WriteLine($"Day 01: Result part 1: {floor}");               // 280
            Console.WriteLine($"Day 01: Result part 2: {enteredBasementAt}");   // 1797
            Console.WriteLine();
        }

        public static (int floor, int enteredBasementAt) Count(string input)
        {
            var floor = 0;
            var position = 0;
            var enteredBasementAt = 0;

            foreach (var instruction in input)
            {
                position++;
                switch (instruction)
                {
                    case '(': floor++; break;
                    case ')': floor--; break;
                    default:
                        break;
                }

                if (floor < 0 && enteredBasementAt == 0)
                    enteredBasementAt = position;
            }

            return (floor, enteredBasementAt);
        }
    }
}
