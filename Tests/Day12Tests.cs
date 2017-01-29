using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day12Tests
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Day12Part1()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day12Test.txt");

            foreach (var item in input.Take(7))
            {
                var split = item.Split('=');
                Assert.AreEqual(int.Parse(split[1]), Day12.CalcSum(split[0]));
            }
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Day12Part2()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day12Test.txt");

            foreach (var item in input)
            {
                var split = item.Split('=');
                Assert.AreEqual(int.Parse(split[1]), Day12.CalcSum(split[0], "red"));
            }
        }
    }
}
