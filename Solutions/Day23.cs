using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day23
    {
        public static void Solve()
        {
            var indata = System.IO.File.ReadAllLines(@"Input\Day23.txt");

            var result1 = ProcessInstructions(indata, false)["b"];
            Console.WriteLine($"Day 23: Result part 1: {result1}");   // 184

            var result2 = ProcessInstructions(indata, true)["b"];
            Console.WriteLine($"Day 23: Result part 2: {result2}");   // 231
                                                                      
            Console.WriteLine();
        }

        public static Dictionary<string, long> ProcessInstructions(string[] instructions, bool part2)
        {
            var registers = new Dictionary<string, long>();
            var idx = 0L;
            if (part2)
                registers.Add("a", 1);

            while (idx < instructions.Length)
            {
                var split = instructions[idx].Split(' ');
                switch (split[0])
                {
                    case "hlf":
                        SetRegister(registers, split[1], GetRegister(registers, split[1]) / 2);
                        idx++;
                        break;
                    case "tpl":
                        SetRegister(registers, split[1], GetRegister(registers, split[1]) * 3);
                        idx++;
                        break;
                    case "inc":
                        SetRegister(registers, split[1], GetRegister(registers, split[1]) + 1);
                        idx++;
                        break;
                    case "jmp":
                        idx += int.Parse(split[1]);
                        break;
                    case "jie":
                        var isEven = GetRegister(registers, split[1].Replace(",", "")) % 2 == 0;
                        if (isEven)
                            idx += int.Parse(split[2]);
                        else
                            idx++;
                        break;
                    case "jio":
                        var isOne = GetRegister(registers, split[1].Replace(",", "")) == 1;
                        if (isOne)
                            idx += int.Parse(split[2]);
                        else
                            idx++;
                        break;
                }
            }

            return registers;
        }


        private static long GetRegister(Dictionary<string, long> registers, string register)
        {
            if (registers.ContainsKey(register))
                return registers[register];
            else
                return 0;
        }

        private static void SetRegister(Dictionary<string, long> registers, string register, long value)
        {
            if (registers.ContainsKey(register))
                registers[register] = value;
            else
                registers.Add(register, value);
        }
    }
}
