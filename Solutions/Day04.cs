using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Solutions
{
    public class Day04
    {
        public static void Solve()
        {
            var input = "bgvyzdsv";

            var result1 = GetFirstValueWith5zeroInHash(input, 5, 1);
            var result2 = GetFirstValueWith5zeroInHash(input, 6, result1);

            Console.WriteLine($"Day 04: Result part 1: {result1}");   // 254575
            Console.WriteLine($"Day 04: Result part 2: {result2}");   // 1038736
            Console.WriteLine();
        }

        public static int GetFirstValueWith5zeroInHash(string indata, int noOfLeadingZeros, int startIndex)
        {
            var counter = startIndex;
            var md5Hasher = MD5.Create();
            var startsWith = String.Join("", Enumerable.Range(1, noOfLeadingZeros).Select(x => "0"));

            while (true)
            {
                var hash = CalculateMD5Hash(md5Hasher, $"{indata}{counter}");
                if (hash.StartsWith(startsWith, StringComparison.InvariantCultureIgnoreCase))
                    break;
                counter++;
            }

            return counter;
        }

        private static string CalculateMD5Hash(MD5 md5Hasher, string input)
        {
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            //return BitConverter.ToString(data).Replace("-", "");
            var result = new StringBuilder();
            foreach (byte b in data)
                result.Append(b.ToString("x2"));
            return result.ToString();
        }
    }
}
