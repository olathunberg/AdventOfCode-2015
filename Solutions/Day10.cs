using System;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class Day10
    {
        public static void Solve()
        {
            var input = "3113322113";

            string lookAndSay = input;
            for (int i = 0; i < 40; i++)
                lookAndSay = LookAndSay(lookAndSay);

            Console.WriteLine($"Day 10: Result part 1: {lookAndSay.Length}");   // 

            for (int i = 0; i < 10; i++)
                lookAndSay = LookAndSay(lookAndSay);

            Console.WriteLine($"Day 10: Result part 2: {lookAndSay.Length}");   // 
            Console.WriteLine();
        }

        public static string LookAndSay(string input)
        {
            var result = new StringBuilder();

            char current = input[0];
            ushort count = 0;
            foreach (var item in input)
            {
                if(item != current)
                {
                    result.Append($"{count}{current}");
                    count = 0;
                }
                count++;
                current = item;
            }
            result.Append($"{count}{input.Last()}");

            return result.ToString();
        }
    }
}
