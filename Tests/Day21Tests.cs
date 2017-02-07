using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;
using static Solutions.Day21;

namespace Tests
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void Day20Part1()
        {
            var boss = new GameCharacter
            {
                HitPoints = 12,
                Damage = 7,
                Armor = 2
            };

            Assert.AreEqual(true, IsPlayerWinning(boss, 100, (8, 5, 5)));
        }
    }
}
