using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public void Day06Part1()
        {
            var lights = new bool[1000, 1000];
            Day06.ParseLine("turn on 0,0 through 999,999", ref lights);
            var result1 = Day06.Count(lights, true);
            Assert.IsTrue(result1 == 1000000);

            Day06.ParseLine("toggle 0,0 through 999,0", ref lights);
            var result2 = Day06.Count(lights, true);
            Assert.IsTrue(result2 == 999000);

            Day06.ParseLine("turn off 499,499 through 500,500", ref lights);
            var result3 = Day06.Count(lights, true);
            Assert.IsTrue(result3 == 999000-4);
        }

        [TestMethod]
        public void Day06Part2()
        {
            var lights = new int[1000, 1000];
            Day06.ParseLine2("turn on 0,0 through 0,0", ref lights);
            var result1 = Day06.Count2(lights);
            Assert.IsTrue(result1 == 1);

            Day06.ParseLine2("toggle 0,0 through 999,999", ref lights);
            var result2 = Day06.Count2(lights);
            Assert.IsTrue(result2 == 2000001);
        }
    }
}
