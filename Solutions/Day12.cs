using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Solutions
{
    public class Day12
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllText(@"Input\Day12.txt");

            //var result1 = SumOfNumbers(input);
            //Console.WriteLine($"Day 12: Result part 1: {result1}");   // 191164

            var result1 = CalcSum(input);
            Console.WriteLine($"Day 12: Result part 1: {result1}");   // 191164

            var result2 = CalcSum(input, "red");
            Console.WriteLine($"Day 12: Result part 2: {result2}");   // 87842
            Console.WriteLine();
        }

        public static int CalcSum(string input, string skip = null)
        {
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<JToken>(input);
            return NumberFromJSon(data, skip);
        }

        private static int NumberFromJSon(JToken data, string skip)
        {
            if (data is JObject jo)
            {
                if (!string.IsNullOrEmpty(skip) && DoSkip(jo, skip)) return 0;
                return jo.Properties().Select(p => p.Value).Sum(jt => NumberFromJSon(jt, skip));
            }
            else if (data is JArray ja)
            {
                return ja.Sum(jt => NumberFromJSon(jt, skip));
            }
            else if (data is JValue jv)
            {
                return jv.Type == JTokenType.Integer ? jv.Value<int>() : 0;
            }

            return 0;
        }

        public static bool DoSkip(JObject jobj, string skip)
        {
            return jobj.Properties()
                .Select(p => p.Value).OfType<JValue>()
                .Select(j => j.Value).OfType<string>()
                .Any(j => j == skip);
        }

        // Cheap way not parsing the Json
        public static int SumOfNumbers(string input)
        {
            var numbers = new List<string>();
            var idx = 0;
            var delimiters = new char[] { '{', '}', '[', ']', ',', ':' };
            while (idx < input.Length)
            {
                if (char.IsDigit(input[idx]))
                {
                    var lastDigit = input.IndexOfAny(delimiters, idx);
                    if (input[idx - 1] == '-')
                        idx--;
                    var clipLength = lastDigit - idx;
                    numbers.Add(input.Substring(idx, clipLength));
                    idx += clipLength;
                    continue;
                }
                idx++;
            }

            return numbers.Select(x => int.Parse(x)).Sum();
        }
    }
}
