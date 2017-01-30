using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day17;

namespace Tests
{
    [TestClass]
    public class Day17Tests
    {
        [TestMethod]
        public void Day17Part1()
        {
            var availContainers = new int[]
            {
                20, 15, 10, 5, 5
            };

            var result1 = GetPossibleCombinations(availContainers, 25).Count();
            Assert.AreEqual(4, result1);
        }
    }
}
