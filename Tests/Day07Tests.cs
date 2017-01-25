using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        public void Day07Part1()
        {
            var testData = new string[]
                {
                    "123 -> x",
                    "456 -> y",
                    "x AND y -> d",
                    "x OR y -> e",
                    "x LSHIFT 2 -> f",
                    "y RSHIFT 2 -> g",
                    "NOT x -> h",
                    "NOT y -> i" };

            var dict = new Dictionary<string, ushort>();
            foreach (var line in testData)
                Day07.ParseLine(line, dict, "");

            Assert.IsTrue(dict["d"] == 72);
            Assert.IsTrue(dict["e"] == 507);
            Assert.IsTrue(dict["f"] == 492);
            Assert.IsTrue(dict["g"] == 114);
            Assert.IsTrue(dict["h"] == 65412);
            Assert.IsTrue(dict["i"] == 65079);
            Assert.IsTrue(dict["x"] == 123);
            Assert.IsTrue(dict["y"] == 456);
        }
    }
}
