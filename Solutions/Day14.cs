using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day14
    {
        public static void Solve()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day14.txt");

            var rainDeers = input.Select(x => CreateRainDeer(x)).ToList();
            foreach (var rainDeer in rainDeers)
                rainDeer.TravelForSeconds(2503);

            var result1 = rainDeers.Select(x => x.TotalDistance).Max();
            Console.WriteLine($"Day 14: Result part 1: {result1}");   // 2696

            rainDeers = input.Select(x => CreateRainDeer(x)).ToList();
            Race(rainDeers, 2503);
            var result2 = rainDeers.OrderByDescending(x => x.Points).First().Points;
            Console.WriteLine($"Day 14: Result part 2: {result2}");   // 1084
            Console.WriteLine();
        }

        public static void Race(List<RainDeer> rainDeers, int racetime)
        {
            foreach (var item in Enumerable.Range(1, racetime))
            {
                foreach (var rainDeer in rainDeers)
                    rainDeer.TravelForSeconds(1);

                var leaderDist = rainDeers.Select(x => x.TotalDistance).Max();
                foreach (var raindeer in rainDeers.Where(x => x.TotalDistance == leaderDist))
                    raindeer.GivePoint();
            }
        }

        private static RainDeer CreateRainDeer(string input)
        {
            var split = input.Split(' ');
            return new RainDeer(split[0], int.Parse(split[3]), int.Parse(split[6]), int.Parse(split[13]));
        }
    }

    public class RainDeer
    {
        private readonly int resttime;
        private readonly int distbeforerest;
        private readonly int speed;
        private readonly string name;

        private int flying = 0;
        private int resting = 0;
        private bool isFlying = false;
        private bool isResting = true;
        private int points = 0;

        private int totalDistance = 0;

        public int TotalDistance => totalDistance;
        public string Name => name;
        public int Points => points;

        public RainDeer(string name, int speed, int timeBeforeResting, int resttime)
        {
            this.name = name;
            this.speed = speed;
            this.distbeforerest = timeBeforeResting;
            this.resttime = resttime;
            this.isFlying = true;
        }

        private void Inctime()
        {
            if (isFlying && flying < distbeforerest)
            {
                flying++;
                totalDistance += speed;
            }
            else if (isFlying && flying == distbeforerest)
            {
                isResting = true;
                isFlying = false;
                resting = 1;
            }
            else if (isResting && resting < resttime)
                resting++;
            else if (isResting && resting == resttime)
            {
                isResting = false;
                isFlying = true;
                totalDistance += speed;
                flying = 1;
            }
        }

        public void TravelForSeconds(int seconds)
        {
            for (int i = 0; i < seconds; i++)
                Inctime();
        }

        internal void GivePoint()
        {
            points++;
        }
    }
}
