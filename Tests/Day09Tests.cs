using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day09Tests
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Day09Part1()
        {
            var indata = new string[] {
                "London to Dublin = 464",
                "London to Belfast = 518",
                "Dublin to Belfast = 141" };

            Assert.AreEqual(605, Day09.GetShortest(indata));
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Day09Part2()
        {
            var indata = new string[] {
                "London to Dublin = 464",
                "London to Belfast = 518",
                "Dublin to Belfast = 141" };

            Assert.AreEqual(982, Day09.GetLongest(indata));
        }
    }
}
