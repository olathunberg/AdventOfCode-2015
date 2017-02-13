using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day25;

namespace Tests
{
    [TestClass]
    public class Day25Tests
    {
        [TestMethod]
        public void Day25Part1()
        {
            Assert.AreEqual(01, GetCodeNumber(1,1));
            Assert.AreEqual(02, GetCodeNumber(2,1));
            Assert.AreEqual(03, GetCodeNumber(1,2));
            Assert.AreEqual(04, GetCodeNumber(3,1));
            Assert.AreEqual(05, GetCodeNumber(2,2));
            Assert.AreEqual(06, GetCodeNumber(1,3));
            Assert.AreEqual(07, GetCodeNumber(4,1));
            Assert.AreEqual(08, GetCodeNumber(3,2));
            Assert.AreEqual(09, GetCodeNumber(2,3));
            Assert.AreEqual(10, GetCodeNumber(1,4));
            Assert.AreEqual(11, GetCodeNumber(5,1));
            Assert.AreEqual(12, GetCodeNumber(4,2));
            Assert.AreEqual(13, GetCodeNumber(3,3));
            Assert.AreEqual(14, GetCodeNumber(2,4));
            Assert.AreEqual(15, GetCodeNumber(1,5));
            Assert.AreEqual(16, GetCodeNumber(6,1));
            Assert.AreEqual(17, GetCodeNumber(5,2));
            Assert.AreEqual(18, GetCodeNumber(4,3));
            Assert.AreEqual(19, GetCodeNumber(3,4));
            Assert.AreEqual(20, GetCodeNumber(2,5));
            Assert.AreEqual(21, GetCodeNumber(1,6));

            Assert.AreEqual(10600672, GetCode(4, 5));
            Assert.AreEqual(33511524, GetCode(1, 6));
            Assert.AreEqual(27995004, GetCode(6, 6));
            Assert.AreEqual(31916031, GetCode(2, 1));
            Assert.AreEqual(6796745, GetCode(6, 2));
        }
    }
}
