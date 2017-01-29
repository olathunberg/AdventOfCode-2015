using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;

namespace Tests
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void Day14Part1()
        {
            var comet = new RainDeer("Comet", 14, 10, 127);
            comet.TravelForSeconds(1000);
            Assert.AreEqual(1120, comet.TotalDistance);


            var dancer = new RainDeer("Dancer", 16, 11, 162);
            dancer.TravelForSeconds(1000);
            Assert.AreEqual(1056, dancer.TotalDistance);
        }

        [TestMethod]
        public void Day14Part2()
        {
            var rainDeers = new RainDeer[]
            {
                new RainDeer("Comet", 14, 10, 127),
                new RainDeer("Dancer", 16, 11, 162)
            }.ToList();

            Day14.Race(rainDeers, 1000);

            Assert.AreEqual(689, rainDeers[1].Points);
            Assert.AreEqual(312, rainDeers[0].Points);
        }
    }
}
