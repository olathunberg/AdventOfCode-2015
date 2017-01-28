using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day11Tests
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Day11Part1()
        {
            Assert.AreEqual(false, Day11.IsValid("hijklmmn"));
            Assert.AreEqual(false, Day11.IsValid("abbceffg"));
            Assert.AreEqual(false, Day11.IsValid("abbcegjk"));
            Assert.AreEqual(true, Day11.IsValid("abcdffaa"));
            Assert.AreEqual(true, Day11.IsValid("ghjaabcc"));

            Assert.AreEqual("abcdffaa", Day11.GetNetPass("abcdefgh"));
            Assert.AreEqual("ghjaabcc", Day11.GetNetPass("ghijklmn"));
        }

        [TestMethod]
        public void Day11Part2()
        {
        }
    }
}
