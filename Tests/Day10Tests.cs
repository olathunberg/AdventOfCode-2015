using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day10Tests
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Day10Part1()
        {
            Assert.AreEqual("1221", Day10.LookAndSay("211"));
            Assert.AreEqual("11", Day10.LookAndSay("1"));
            Assert.AreEqual("21", Day10.LookAndSay("11"));
            Assert.AreEqual("1211", Day10.LookAndSay("21"));
            Assert.AreEqual("111221", Day10.LookAndSay("1211"));
            Assert.AreEqual("312211", Day10.LookAndSay("111221"));
        }

        [TestMethod]
        public void Day10Part2()
        {
        }
    }
}
