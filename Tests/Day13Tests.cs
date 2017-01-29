using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void Day13Part1()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day13Test.txt");

            Assert.AreEqual(330, Day13.GetBestSeatingsGain(input, false));
        }
    }
}
