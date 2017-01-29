using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Solutions.Day15;

namespace Tests
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void Day15Part1()
        {
            var ingredients = new(int, Ingredient)[]
               {
                (44, new Ingredient(-1,-2,6,3,8)),
                (56, new Ingredient(2,3,-2,-1,3))
               };

            var scores = GetAllRecipeScores(ingredients);
            var result1 = scores.Select(x => x.score).Max();
            Assert.AreEqual(62842880, result1);
        }

        [TestMethod]
        public void Day15Part2()
        {
            var ingredients = new(int, Ingredient)[]
               {
                (44, new Ingredient(-1,-2,6,3,8)),
                (56, new Ingredient(2,3,-2,-1,3))
               };

            var scores = GetAllRecipeScores(ingredients);
            var result2 = scores.Where(x=>x.calories <= 500).Select(x => x.score).Max();
            Assert.AreEqual(57600000, result2);
        }
    }
}
