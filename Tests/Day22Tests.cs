using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions;
using static Solutions.Day22;

namespace Tests
{
    [TestClass]
    public class Day22Tests
    {
        [TestMethod]
        public void Day22Part1()
        {
            var boss1 = new Boss
            {
                HitPoints = 13,
                Damage = 8
            };
            var player1 = new Wizard
            {
                HitPoints = 10,
                AvailableMana = 250,
                ActiveSpells = new List<(Spell spell, int timer)>(),
                UsedSpells = new List<Spell>()
            };

            Assert.AreEqual(173 + 53, Battle(boss1, player1, false));

            var boss2 = new Boss
            {
                HitPoints = 14,
                Damage = 8
            };
            var player2 = new Wizard
            {
                HitPoints = 10,
                AvailableMana = 250,
                ActiveSpells = new List<(Spell spell, int timer)>(),
                UsedSpells = new List<Spell>()
            };

            Assert.AreEqual(229+113+73+173+53, Battle(boss2, player2, false));
        }
    }
}
