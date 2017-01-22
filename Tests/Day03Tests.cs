using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void Part1()
        {
            Assert.IsTrue(Day03.VisitedHouses(">").Count == 2);
            Assert.IsTrue(Day03.VisitedHouses("^>v<").Count == 4);
            Assert.IsTrue(Day03.VisitedHouses("^v^v^v^v^v").Count == 2);
        }

        [TestMethod]
        public void Part2()
        {
            Assert.IsTrue(Day03.VisistedWithRobotSanta("^v") == 3);
            Assert.IsTrue(Day03.VisistedWithRobotSanta("^>v<") == 3);
            Assert.IsTrue(Day03.VisistedWithRobotSanta("^v^v^v^v^v") == 11);
        }
    }
}
