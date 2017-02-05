using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day20
    {
        public static void Solve()
        {
            var indata = 29000000;

            var result1 = PresentsPerHouse().AsParallel().First(x => x.presents >= indata);
            Console.WriteLine($"Day 20: Result part 1: {result1.houseNum}");   // 665280

            var result2 = PresentsPerHouse2().AsParallel().First(x => x.presents >= indata);
            Console.WriteLine($"Day 20: Result part 2: {result2.houseNum}");   // 705600

            Console.WriteLine();
        }

        public static IEnumerable<(long houseNum, long presents)> PresentsPerHouse()
        {
            var houseNum = 0;

            while (true)
            {
                houseNum++;

                // For all divisors x; houseNum/x is also a divisor
                // Therefor we do dot need to search more than sqrt(houseNum)
                // 99: sqrt(99) == 9.95
                // 99 % 1 == 0, 99 / 1 == 99, 99 % 99 == 0
                // 99 % 3 == 0, 99 / 3 == 33, 99 % 33 == 0
                // 99 % 9 == 0, 99 / 9 == 11, 99 % 11 == 0
                var divisors = Enumerable.Range(1, (int)Math.Sqrt(houseNum))
                    .Where(x => houseNum % x == 0)
                    .SelectMany(x => new int[] { x, houseNum / x })
                    .Distinct();

                yield return (houseNum, divisors.Sum(x => x * 10));
            }
        }

        public static IEnumerable<(long houseNum, long presents)> PresentsPerHouse2()
        {
            var houseNum = 0;

            while (true)
            {
                houseNum++;

                // Elfs 1 retires after house 50
                // Elfs 2 retires after house 100
                // Elfs 3 retires after house 150
                // Elfs 4 retires after house 200
                // ...
                // Filter out house/Elf > 50
                var divisors = Enumerable.Range(1, (int)Math.Sqrt(houseNum))
                    .Where(x => houseNum % x == 0)
                    .SelectMany(x => new int[] { x, houseNum / x })
                    .Where(x => houseNum / x <= 50)
                    .Distinct();

                yield return (houseNum, divisors.Sum(x => x * 11));
            }
        }

        // Initial attempt before realising the pattern of retirements
        public static int FirstHouseToGetnPresentsPart21(int numPresents)
        {
            var houseNum = 0;
            var currentPresents = 0;
            var elfDeliveries = new Dictionary<int, int>();
            var retiredElfs = new List<int>();

            while (currentPresents < numPresents)
            {
                houseNum++;

                var divisors = Enumerable.Range(1, (int)Math.Sqrt(houseNum))
                    .Where(x => houseNum % x == 0)
                    .SelectMany(x => new int[] { x, houseNum / x })
                    .Distinct()
                    .Where(x => !retiredElfs.Contains(x));

                elfDeliveries.Add(houseNum, 0);
                foreach (var divisor in divisors)
                {
                    var curDeliveries = elfDeliveries[divisor] + 1;
                    elfDeliveries[divisor] = curDeliveries;
                    if (curDeliveries > 50)
                        retiredElfs.Add(divisor);
                }

                currentPresents = divisors
                    .Sum(x => x * 11);
            }

            return houseNum;
        }
    }
}
