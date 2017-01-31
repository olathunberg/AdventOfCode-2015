using System;
using System.Linq;

namespace Solutions
{
    public class Day18
    {
        public static void Solve()
        {
            var grid = System.IO.File.ReadAllLines(@"Input\Day18.txt");

            var newGrid = Animate(grid, 100);
            var result1 = NumberOfLightsOn(newGrid);
            Console.WriteLine($"Day 18: Result part 1: {result1}");   // 821

            newGrid = Animate(grid, 100, step2: true);
            var result2 = NumberOfLightsOn(newGrid);
            Console.WriteLine($"Day 18: Result part 2: {result2}");   // 886

            Console.WriteLine();
        }

        public static string[] Animate(string[] grid, int iterations, bool step2 = false)
        {
            var newGrid = new string[grid.Length];

            var maxY = grid.Length;
            var maxX = grid.First().Length;

            for (int y = 0; y < maxY; y++)
            {
                var newLine = string.Empty;
                for (int x = 0; x < maxX; x++)
                {
                    if (step2 && IsCorner(x, y, maxX, maxY))
                        newLine += '#';
                    else
                    {
                        var numNeighbors = NumberOfOnNeighbors(grid, x, y, step2);
                        if ((grid[y][x] == '#' && (numNeighbors == 2 || numNeighbors == 3))
                          || (grid[y][x] == '.' && (numNeighbors == 3)))
                            newLine += '#';
                        else
                            newLine += '.';
                    }
                }
                newGrid[y] = newLine;
            }

            iterations--;
            if (iterations > 0)
                newGrid = Animate(newGrid, iterations, step2);

            return newGrid;
        }

        public static int NumberOfLightsOn(string[] grid)
        {
            int numberOn = 0;
            for (int y = 0; y < grid.Length; y++)
                for (int x = 0; x < grid.First().Length; x++)
                    if (grid[y][x] == '#')
                        numberOn++;

            return numberOn;
        }

        private static int NumberOfOnNeighbors(string[] grid, int x, int y, bool step2)
        {
            var maxX = grid.First().Length;
            var maxY = grid.Length;

            var numberOn = 0;
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    // Skip the light itself
                    if (!(y == i && x == j))
                    {
                        if (step2 && IsCorner(j, i, maxX, maxY))
                            numberOn++;
                        // If not outside and on
                        else if (!(i == -1 || i == maxY || j == -1 || j == maxX) && grid[i][j] == '#')
                            numberOn++;
                    }
                }
            }

            return numberOn;
        }

        private static bool IsCorner(int x, int y, int maxX, int maxY)
        {
            return (y == 0 && x == 0)
                || (y == 0 && x == maxX - 1)
                || (x == 0 && y == maxY - 1)
                || (x == maxX - 1 && y == maxY - 1);
        }
    }
}
