using System;

namespace Solutions
{
    public static class Day06
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day06.txt");

            var lights = new bool[1000, 1000];
            foreach (var line in input)
                ParseLine(line, ref lights);

            var result1 = Count(lights, true);
            Console.WriteLine($"Day 06: Result part 1: {result1}");   // 400410

            var lights2 = new int[1000, 1000];
            foreach (var line in input)
                ParseLine2(line, ref lights2);

            var result2 = Count2(lights2);

            Console.WriteLine($"Day 06: Result part 2: {result2}");   // 15343601
            Console.WriteLine();
        }

        public static void ParseLine(string line, ref bool[,] lights)
        {
            var split = line.Split(' ');

            switch (split[0])
            {
                case "toggle":
                    SetValue(split[1], split[3], null, ref lights);
                    break;
                case "turn":
                    if (split[1] == "on")
                        SetValue(split[2], split[4], true, ref lights);
                    else
                        SetValue(split[2], split[4], false, ref lights);
                    break;
                default:
                    break;
            }
        }

        private static void SetValue(string startPoint, string endPoint, bool? state, ref bool[,] lights)
        {
            var start = GetCoord(startPoint);
            var end = GetCoord(endPoint);

            for (int i = start.x; i <= end.x; i++)
                for (int j = start.y; j <= end.y; j++)
                    if (state.HasValue)
                        lights[i, j] = state.Value;
                    else
                        lights[i, j] = !lights[i, j];
        }

        public static int Count(bool[,] lights, bool state)
        {
            var count = 0;
            for (int i = 0; i <= 999; i++)
                for (int j = 0; j <= 999; j++)
                    if (lights[i, j] == state)
                        count++;

            return count;
        }

        public static void ParseLine2(string line, ref int[,] lights)
        {
            var split = line.Split(' ');

            switch (split[0])
            {
                case "toggle":
                    SetValue2(split[1], split[3], 2, ref lights);
                    break;
                case "turn":
                    if (split[1] == "on")
                        SetValue2(split[2], split[4], 1, ref lights);
                    else
                        SetValue2(split[2], split[4], -1, ref lights);
                    break;
                default:
                    break;
            }
        }

        private static void SetValue2(string startPoint, string endPoint, int increment, ref int[,] lights)
        {
            var start = GetCoord(startPoint);
            var end = GetCoord(endPoint);

            for (int i = start.x; i <= end.x; i++)
                for (int j = start.y; j <= end.y; j++)
                {
                    lights[i, j] += increment;
                    if (lights[i, j] < 0)
                        lights[i, j] = 0;
                }
        }

        public static int Count2(int[,] lights)
        {
            var count = 0;
            for (int i = 0; i <= 999; i++)
                for (int j = 0; j <= 999; j++)
                    count += lights[i, j];

            return count;
        }

        private static (int x, int y) GetCoord(string point)
        {
            var split = point.Split(',');

            return (Convert.ToInt16(split[0]), Convert.ToInt16(split[1]));
        }
    }
}
