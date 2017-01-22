using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void Part1()
        {
            Assert.IsTrue(Day01.Count("(())").floor == 0);
            Assert.IsTrue(Day01.Count("()()").floor == 0);
            Assert.IsTrue(Day01.Count("(((").floor == 3);
            Assert.IsTrue(Day01.Count("(()(()(").floor == 3);
            Assert.IsTrue(Day01.Count("))(((((").floor == 3);
            Assert.IsTrue(Day01.Count("())").floor == -1);
            Assert.IsTrue(Day01.Count("))(").floor == -1);
            Assert.IsTrue(Day01.Count(")))").floor == -3);
            Assert.IsTrue(Day01.Count(")())())").floor == -3);
        }

        [TestMethod]
        public void Part2()
        {
            Assert.IsTrue(Day01.Count(")").enteredBasementAt == 1);
            Assert.IsTrue(Day01.Count("()())").enteredBasementAt == 5);
        }
    }
}
