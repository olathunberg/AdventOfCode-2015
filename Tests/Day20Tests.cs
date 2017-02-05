using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day20;

namespace Tests
{
    [TestClass]
    public class Day20Tests
    {
        [TestMethod]
        public void Day20Part1()
        {
            var presentsPerHouse = PresentsPerHouse().Take(9).ToList();
            Assert.AreEqual(10, presentsPerHouse.First(x => x.houseNum == 1).presents);
            Assert.AreEqual(30, presentsPerHouse.First(x => x.houseNum == 2).presents);
            Assert.AreEqual(40, presentsPerHouse.First(x => x.houseNum == 3).presents);
            Assert.AreEqual(70, presentsPerHouse.First(x => x.houseNum == 4).presents);
            Assert.AreEqual(60, presentsPerHouse.First(x => x.houseNum == 5).presents);
            Assert.AreEqual(120, presentsPerHouse.First(x => x.houseNum == 6).presents);
            Assert.AreEqual(80, presentsPerHouse.First(x => x.houseNum == 7).presents);
            Assert.AreEqual(150, presentsPerHouse.First(x => x.houseNum == 8).presents);
            Assert.AreEqual(130, presentsPerHouse.First(x => x.houseNum == 9).presents);
        }
    }
}
