using System;
using System.Diagnostics.Contracts;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllText("Input.txt");


            Test();

            var (floor, enteredBasementAt) = Execute(input);
            Console.WriteLine($"Result part 1: {floor}");               // 280
            Console.WriteLine($"Result part 2: {enteredBasementAt}");   // 1797
            Console.ReadKey();
        }

        private static (int floor, int enteredBasementAt) Execute(string input)
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

        private static void Test()
        {
            Contract.Assert(Execute("(())").floor == 0);
            Contract.Assert(Execute("()()").floor == 0);
            Contract.Assert(Execute("(((").floor == 3);
            Contract.Assert(Execute("(()(()(").floor == 3);
            Contract.Assert(Execute("))(((((").floor == 3);
            Contract.Assert(Execute("())").floor == -1);
            Contract.Assert(Execute("))(").floor == -1);
            Contract.Assert(Execute(")))").floor == -3);
            Contract.Assert(Execute(")())())").floor == -3);
            Contract.Assert(Execute(")").enteredBasementAt == 1);
            Contract.Assert(Execute("()())").enteredBasementAt == 5);
        }
    }
}
