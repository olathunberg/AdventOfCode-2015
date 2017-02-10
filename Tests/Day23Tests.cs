using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;
using static Solutions.Day23;

namespace Tests
{
    [TestClass]
    public class Day23Tests
    {
        [TestMethod]
        public void Day23Part1()
        {
            var indata = new string[]
            {
                "inc a",
                "jio a, +2",
                "tpl a",
                "inc a"
            };

            Assert.AreEqual(2, ProcessInstructions(indata)["a"]);
        }
    }
}
