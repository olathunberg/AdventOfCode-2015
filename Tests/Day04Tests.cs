using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void Day04Part1()
        {
            Assert.IsTrue(Day04.GetFirstValueWith5zeroInHash("abcdef", 5, 0) == 609043);
            Assert.IsTrue(Day04.GetFirstValueWith5zeroInHash("pqrstuv", 5, 0) == 1048970);
        }
    }
}
