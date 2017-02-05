using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Day19
    {
        public static void Solve()
        {
            var indata = System.IO.File.ReadAllLines(@"Input\Day19.txt");

            var result1 = GetNumberOfCombinations(indata);
            Console.WriteLine($"Day 19: Result part 1: {result1}");   // 509

            var result2 = StepsFromTargetToElectron(indata);
            Console.WriteLine($"Day 19: Result part 2: {result2}");   // 195
            
            Console.WriteLine();
        }

        // Based on the assumption that the input is not random
        // Test to do all rplacements in order, iterating until done or failed
        // There are 3,34e+49 ways to order replacements, so this solution is based on the input beeing in correct order!
        public static int StepsFromTargetToElectron(string[] indata)
        {
            var replacements = GetReplacements(indata).Where(x => x.original != "e");
            var lastSteps = GetReplacements(indata).Where(x => x.original == "e").Select(x => x.replacement).ToArray();

            var targetMolecule = indata.Last();
            int steps = 0;
            var idx = 0;

            while (!lastSteps.Contains(targetMolecule))
            {
                var tempMolecule = targetMolecule;

                foreach (var replacement in replacements)
                {
                    var nextReplacement = targetMolecule.IndexOf(replacement.replacement, idx);
                    if (nextReplacement != -1)
                    {
                        var nextIdx = nextReplacement + replacement.replacement.Length;
                        targetMolecule = $"{targetMolecule.Substring(0, nextReplacement)}{replacement.original}{targetMolecule.Substring(nextIdx)}";
                        steps++;
                    }
                }

                // No change, fail
                if (tempMolecule == targetMolecule)
                {
                    return -1;
                }
            }

            // Plus 1 since we do not do the last replacement
            return steps + 1;
        }

        // BFS: Takes to long time and EATS memory! A* would propably do it
        //public static int StepsToGenerate(string[] indata)
        //{
        //    var replacements = GetReplacements(indata).Where(x => x.original != "e");
        //    var lastSteps = GetReplacements(indata).Where(x => x.original == "e").Select(x => x.replacement).ToArray();
        //    var targetMolecule = indata.Last();

        //    var queue = new Queue<(string molecule, int steps)>();
        //    queue.Enqueue((targetMolecule, 0));

        //    while (queue.Count > 0)
        //    {
        //        var current = queue.Dequeue();
        //        var idx = 0;

        //        foreach (var replacement in replacements)
        //        {
        //            idx = 0;
        //            while (idx < current.molecule.Length)
        //            {
        //                var nextReplacement = current.molecule.IndexOf(replacement.replacement, idx);
        //                if (nextReplacement == -1)
        //                    break;

        //                var nextIdx = nextReplacement + replacement.replacement.Length;
        //                var newMolecule = $"{current.molecule.Substring(0, nextReplacement)}{replacement.original}{current.molecule.Substring(nextIdx)}";
        //                if (lastSteps.Contains(newMolecule))
        //                    return current.steps + 2;
        //                else
        //                    queue.Enqueue((newMolecule, current.steps + 1));

        //                idx = nextIdx;
        //            }
        //        }
        //    }

        //    return 0;
        //}

        private static List<string> GetAllNewPossibleMolecules(List<(string org, string repl)> replacements, string molecule)
        {
            var result = new List<string>();
            var idx = 0;
            var len = molecule.Length - 1;
            foreach (var replacement in replacements)
            {
                idx = 0;
                while (idx < len)
                {
                    var nextReplacement = molecule.IndexOf(replacement.org, idx);
                    if (nextReplacement == -1)
                        break;

                    var nextIdx = nextReplacement + replacement.org.Length;
                    var newMolecule = $"{molecule.Substring(0, nextReplacement)}{replacement.repl}{molecule.Substring(nextIdx)}";
                    if (!result.Contains(newMolecule))
                        result.Add(newMolecule);

                    idx = nextIdx;
                }
            }

            return result;
        }

        public static int GetNumberOfCombinations(string[] indata)
        {
            var replacements = GetReplacements(indata);
            var molecule = indata.Last();

            return GetAllNewPossibleMolecules(replacements, molecule).Count();
        }

        private static List<(string original, string replacement)> GetReplacements(string[] indata)
        {
            var result = new List<(string, string)>();
            foreach (var line in indata)
            {
                if (string.IsNullOrEmpty(line))
                    break;
                var split = line.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                result.Add((split[0], split[1]));
            }
            return result;
        }
    }
}
