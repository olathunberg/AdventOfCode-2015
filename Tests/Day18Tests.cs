using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day18;

namespace Tests
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        public void Day18Part1()
        {
            var grid = new string[]
            {
                ".#.#.#",
                "...##.",
                "#....#",
                "..#...",
                "#.#..#",
                "####.."
            };

            var newGrid = Animate(grid, 4);
            Assert.AreEqual(4, NumberOfLightsOn( newGrid));
        }

        [TestMethod]
        public void Day18Part2()
        {
            var grid = new string[]
            {
                ".#.#.#",
                "...##.",
                "#....#",
                "..#...",
                "#.#..#",
                "####.."
            };

            var newGrid = Animate(grid, 5, true);
            Assert.AreEqual(17, NumberOfLightsOn(newGrid));
        }
    }
}
