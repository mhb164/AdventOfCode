using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class PuzzleStep
    {
        public PuzzleStep(int dayNumber,
                          Func<IEnumerable<string>, string> partOneSolveFunc,
                          Func<IEnumerable<string>, string> partTwoSolveFunc,
                          IEnumerable<string> testInput,
                          string partOneTestOutput,
                          string partTwoTestOutput,
                          string title)
        {
            DayNumber = dayNumber;
            PartOneSolveFunc = partOneSolveFunc;
            PartTwoSolveFunc = partTwoSolveFunc;
            Title = title.Trim();
            TestInput = testInput;
            PartOneTestOutput = partOneTestOutput.Trim();
            PartTwoTestOutput = partTwoTestOutput.Trim();
        }

        public int DayNumber { get; private set; }
        public Func<IEnumerable<string>, string> PartOneSolveFunc { get; private set; }
        public Func<IEnumerable<string>, string> PartTwoSolveFunc { get; private set; }
        public IEnumerable<string> TestInput { get; private set; }
        public string PartOneTestOutput { get; private set; }
        public string PartTwoTestOutput { get; private set; }
        public string Title { get; private set; }

        internal string SolvePartOne(IEnumerable<string> input) => PartOneSolveFunc?.Invoke(input);
        internal string SolvePartTwo(IEnumerable<string> input) => PartTwoSolveFunc?.Invoke(input);
        internal string TestPartOne()
        {
            try
            {
                if (SolvePartOne(TestInput) == PartOneTestOutput) return "Success";
                else return "Failed!";
            }
            catch (Exception ex) { return $"Error: {ex.Message}!"; }
        }
        internal string TestPartTwo()
        {
            try
            {
                if (SolvePartTwo(TestInput) == PartTwoTestOutput) return "Success";
                else return "Failed!";
            }
            catch (Exception ex) { return $"Error: {ex.Message}!"; }
        }

        private static IEnumerable<string> LoadTestInput(string resourceName)
        {
            using (Stream stream = typeof(PuzzleStep).Assembly.GetManifestResourceStream($"AdventOfCode2021.TestInputs.{resourceName}.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = new List<string>();
                var line = default(string);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                return lines;
            }
        }
        internal static List<PuzzleStep> Create()
        {
            var output = new List<PuzzleStep>();
            output.Add(new PuzzleStep(01, Day01_1SolveMethod, Day01_2SolveMethod, LoadTestInput("Day01TestInput"), "  7", "  5", "Sonar Sweep"));
            return output;
        }

        #region general
        private static List<int> ToDigits(IEnumerable<string> lines)
        {
            var digits = new List<int>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (int.TryParse(line, out var digit) == false) continue;
                digits.Add(digit);
            }
            return digits;
        }

        private static int CountIncreases(List<int> digits)
        {
            var pre = default(int?);
            var increases = 0;
            foreach (var current in digits)
            {
                if (pre.HasValue && pre < current)
                {
                    increases++;
                }
                pre = current;
            }
            return increases;
        }
        #endregion


        private static string Day01_1SolveMethod(IEnumerable<string> lines)
        {           
            var digits = ToDigits(lines);
            return CountIncreases(digits).ToString();            
        }

        private static string Day01_2SolveMethod(IEnumerable<string> lines)
        {
            var digits = ToDigits(lines);
            var slidings = new List<int>();
            for (int i = 0; i < digits.Count-2; i++)
            {
                slidings.Add(digits[i]+ digits[i+1] + digits[i+2]);
            }
            return CountIncreases(slidings).ToString();

        }
    }
}
