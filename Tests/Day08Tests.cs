using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public void Day08Part1()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day08Test.txt");

            var result1 = input.Sum(x => x.ToCharArray().Length);
            var result2 = input.Sum(x => Day08.UnEscape(x).Length);

            Assert.AreEqual(12, result1 - result2);
        }

        [TestMethod]
        public void Day08Part2()
        {
            var input = System.IO.File.ReadAllLines(@"Input\Day08Test.txt");

            var result1 = input.Sum(x => x.ToCharArray().Length);
            var result2 = input.Sum(x => Day08.Escape(x).Length);

            Assert.AreEqual(19, result2 - result1);
        }
    }
}
