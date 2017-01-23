using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void Day02Part1()
        {
            Assert.IsTrue(Day02.CalcPaperArea("2x3x4") == 58);
            Assert.IsTrue(Day02.CalcPaperArea("1x1x10") == 43);
        }

        [TestMethod]
        public void Day02Part2()
        {
            Assert.IsTrue(Day02.CalcRibbonLength("2x3x4") == 34);
            Assert.IsTrue(Day02.CalcRibbonLength("1x1x10") == 14);
        }
    }
}
