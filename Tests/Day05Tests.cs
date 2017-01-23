using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public void Day05Part1()
        {
            Assert.IsTrue(Day05.IsNice1("ugknbfddgicrmopn") == true);
            Assert.IsTrue(Day05.IsNice1("aaa") == true);
            Assert.IsTrue(Day05.IsNice1("jchzalrnumimnmhp") == false);
            Assert.IsTrue(Day05.IsNice1("haegwjzuvuyypxyu") == false);
            Assert.IsTrue(Day05.IsNice1("dvszwmarrgswjxmb") == false);
        }

        [TestMethod]
        public void Day05Part2()
        {
            Assert.IsTrue(Day05.IsNice2("qjhvhtzxzqqjkmpb") == true);
            Assert.IsTrue(Day05.IsNice2("xxyxx") == true);
            Assert.IsTrue(Day05.IsNice2("uurcxstgmygtbstg") == false);
            Assert.IsTrue(Day05.IsNice2("ieodomkazucvgmuy") == false);
            Assert.IsTrue(Day05.IsNice2("fbuqqaatackrvemm") == false);
        }
    }
}
