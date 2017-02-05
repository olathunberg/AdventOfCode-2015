using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day19;

namespace Tests
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        public void Day19Part1()
        {
            var indata1 = new string[]
            {
                "H => HO",
                "H => OH",
                "O => HH",
                "",
                "HOH"
            };
            Assert.AreEqual(4, GetNumberOfCombinations(indata1));

            var indata2 = new string[]
            {
                "H => HO",
                "H => OH",
                "O => HH",
                "",
                "HOHOHO"
            };
            Assert.AreEqual(7, GetNumberOfCombinations(indata2));
        }

        [TestMethod]
        public void Day19Part2()
        {
            var indata1 = new string[]
            {
                "e => H",
                "e => O",
                "H => HO",
                "H => OH",
                "O => HH",
                "",
                "HOH"
            };
            Assert.AreEqual(3, StepsFromTargetToElectron(indata1));
            Assert.AreEqual(3, AStarStepsCounter(indata1));

            var indata2 = new string[]
            {
                "e => H",
                "e => O",
                "H => HO",
                "H => OH",
                "O => HH",
                "",
                "HOHOHO"
            };
            Assert.AreEqual(6, StepsFromTargetToElectron(indata2));
        }
    }
}
