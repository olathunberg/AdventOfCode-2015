using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day24;

namespace Tests
{
    [TestClass]
    public class Day24Tests
    {
        [TestMethod]
        public void Day24Part1()
        {
            var indata = new List<int>
            {
                1,2,3,4,5,7,8,9,10,11
            };

            var result1 = GetWinningQE(indata, 3);

            Assert.AreEqual(99, result1);
        }

        [TestMethod]
        public void Day24Part2()
        {
            var indata = new List<int>
            {
                1,2,3,4,5,7,8,9,10,11
            };

            var result2 = GetWinningQE(indata, 4);

            Assert.AreEqual(44, result2);
        }
    }
}
