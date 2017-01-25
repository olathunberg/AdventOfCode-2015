using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public static class Day07
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day07.txt");

            var dict = new Dictionary<string, ushort>();
            var parsedLines = new bool[input.Length];
            while (parsedLines.Any(x => x == false))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if(!parsedLines[i])
                        parsedLines[i] = ParseLine(input[i], dict, "");
                }
            }

            var result1 = dict["a"];
            Console.WriteLine($"Day 07: Result part 1: {result1}");   // 46065

            dict = new Dictionary<string, ushort>();
            parsedLines = new bool[input.Length];
            dict["b"] = result1;
            while (parsedLines.Any(x => x == false))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!parsedLines[i])
                        parsedLines[i] = ParseLine(input[i], dict,"b");
                }
            }

            Console.WriteLine($"Day 07: Result part 2: {dict["a"]}");   // 14134
            Console.WriteLine();
        }

        public static bool ParseLine(string line, Dictionary<string, ushort> dict, string overrideRegister)
        {
            var split = line.Split(new string[] { " -> ", " " }, StringSplitOptions.None);
            var register = split.Last();

            if (register == overrideRegister)
                return true;

            switch (split.Length)
            {
                case 2:
                    var parseResult = GetValue(split[0], dict);
                    if (parseResult.result)
                        AddValue(register, parseResult.value, dict);

                    return parseResult.result;
                case 3 when split[0] == "NOT":
                    parseResult = GetValue(split[1], dict);
                    if (parseResult.result)
                        AddValue(register, (ushort)(~parseResult.value & 0xFFFF), dict);

                    return parseResult.result;
                case 4 when split[1] == "AND":
                    var parseResult1 = GetValue(split[0], dict);
                    var parseResult2 = GetValue(split[2], dict);
                    if (parseResult1.result && parseResult2.result)
                    {
                        var andValue = (ushort)(parseResult1.value & parseResult2.value & 0xFFFF);
                        AddValue(register, andValue, dict);
                    }

                    return parseResult1.result && parseResult2.result;
                case 4 when split[1] == "OR":
                    parseResult1 = GetValue(split[0], dict);
                    parseResult2 = GetValue(split[2], dict);
                    if (parseResult1.result && parseResult2.result)
                    {
                        var orValue = (ushort)(dict[split[0]] | dict[split[2]] & 0xFFFF);
                        AddValue(register, orValue, dict);
                    }

                    return parseResult1.result && parseResult2.result;
                case 4 when split[1] == "LSHIFT":
                    parseResult1 = GetValue(split[0], dict);
                    parseResult2 = GetValue(split[2], dict);
                    if (parseResult1.result && parseResult2.result)
                    {
                        var rShift = (ushort)((parseResult1.value << parseResult2.value) & 0xFFFF);
                        AddValue(register, rShift, dict);
                    }

                    return parseResult1.result && parseResult2.result;
                case 4 when split[1] == "RSHIFT":
                    parseResult1 = GetValue(split[0], dict);
                    parseResult2 = GetValue(split[2], dict);
                    if (parseResult1.result && parseResult2.result)
                    {
                        var rShift = (ushort)((parseResult1.value >> parseResult2.value) & 0xFFFF);
                        AddValue(register, rShift, dict);
                    }

                    return parseResult1.result && parseResult2.result;
                default:
                    break;
            }

            return false;
        }

        private static (bool result, ushort value) GetValue(string input, Dictionary<string, ushort> dict)
        {
            if (ushort.TryParse(input, out ushort value))
                return (true, value);
            else if (dict.ContainsKey(input))
                return (true, dict[input]);

            return (false, 0);
        }

        private static void AddValue(string register, ushort value, Dictionary<string, ushort> dict)
        {
            if (dict.ContainsKey(register))
                dict[register] = value;
            else
                dict.Add(register, value);
        }
    }
}
