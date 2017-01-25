using System;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class Day08
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day08.txt");

            var result1 = input.Sum(x => x.Length - UnEscape(x).Length);
            Console.WriteLine($"Day 08: Result part 1: {result1}");   // 1333

            var result2 = input.Sum(x => Escape(x).Length - x.Length);
            Console.WriteLine($"Day 08: Result part 2: {result2}");   // 2046
            Console.WriteLine();
        }

        public static string UnEscape(string input)
        {
            var temp = input.Trim('"').ToCharArray();
            var sb = new StringBuilder();

            for (int i = 0; i < temp.Length; i++)
            {
                if (i == temp.Length - 1)
                    sb.Append(temp[i]);
                else if (temp[i] == '\\')
                {
                    if (temp[i + 1] == '"' || temp[i + 1] == '\\')
                    {
                        sb.Append(temp[i + 1]);
                        i++;
                    }
                    else if (temp[i + 1] == 'x')
                    {
                        int value = Convert.ToInt32($"{temp[i + 2]}{temp[i + 3]}", 16);
                        sb.Append(Char.ConvertFromUtf32(value));
                        i += 3;
                    }
                }
                else
                    sb.Append(temp[i]);
            }

            return sb.ToString();
        }

        public static string Escape(string input)
        {
            var temp = input.ToCharArray();
            var sb = new StringBuilder();
            sb.Append('"');
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '\\' || temp[i] == '"')
                {
                    sb.Append('\\');
                }
                sb.Append(temp[i]);
            }
            sb.Append('"');

            return sb.ToString();
        }
    }
}
