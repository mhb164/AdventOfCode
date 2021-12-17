using System;
using System.Collections.Generic;
using System.Drawing;
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
                var testResult = SolvePartOne(TestInput);
                if (testResult == PartOneTestOutput) return $"Success ({testResult})";
                else return $"Failed! ({testResult})";
            }
            catch (Exception ex) { return $"Error: {ex.Message}!"; }
        }
        internal string TestPartTwo()
        {
            try
            {
                var testResult = SolvePartTwo(TestInput);
                if (testResult == PartTwoTestOutput) return $"Success ({testResult})";
                else return $"Failed! ({testResult})";
            }
            catch (Exception ex) { return $"Error: {ex.Message}!"; }
        }

        private static IEnumerable<string> LoadTestInput(string resourceName)
        {
            using (Stream stream = typeof(PuzzleStep).Assembly.GetManifestResourceStream($"AdventOfCode2021.TestInputs.{resourceName}.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                var inputLines = new List<string>();
                var line = default(string);
                while ((line = reader.ReadLine()) != null)
                {
                    inputLines.Add(line);
                }
                return inputLines;
            }
        }
        internal static List<PuzzleStep> Create()
        {
            var output = new List<PuzzleStep>();
            output.Add(new PuzzleStep(01, Day01_1SolveMethod, Day01_2SolveMethod, LoadTestInput("Day01TestInput"), "7", "5", "Sonar Sweep"));
            output.Add(new PuzzleStep(02, Day02_1SolveMethod, Day02_2SolveMethod, LoadTestInput("Day02TestInput"), "150", "900", "Dive!"));
            output.Add(new PuzzleStep(03, Day03_1SolveMethod, Day03_2SolveMethod, LoadTestInput("Day03TestInput"), "198", "230", "Binary Diagnostic"));
            output.Add(new PuzzleStep(04, Day04_1SolveMethod, Day04_2SolveMethod, LoadTestInput("Day04TestInput"), "4512", "1924", "Giant Squid"));
            output.Add(new PuzzleStep(05, Day05_1SolveMethod, Day05_2SolveMethod, LoadTestInput("Day05TestInput"), "5", "12", "Hydrothermal Venture"));
            output.Add(new PuzzleStep(06, Day06_1SolveMethod, Day06_2SolveMethod, LoadTestInput("Day06TestInput"), "5934", "26984457539", "Lanternfish"));
            output.Add(new PuzzleStep(07, Day07_1SolveMethod, Day07_2SolveMethod, LoadTestInput("Day07TestInput"), "37", "168", "The Treachery of Whales"));
            return output;
        }

        #region general
        private static List<int> ToDigits(IEnumerable<string> inputLines)
        {
            var digits = new List<int>();
            foreach (var line in inputLines)
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

        class Line
        {
            public static List<Line> CreateLines(IEnumerable<string> input)
            {
                var lines = new List<Line>();
                foreach (var inputLine in input)
                {
                    var line = Line.CreateLine(inputLine);
                    if (line != null)
                        lines.Add(line);
                }
                return lines;
            }
            public static Line CreateLine(string input)
            {
                if (string.IsNullOrWhiteSpace(input)) return null;
                var points = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                return new Line(CreatePoint(points[0]), CreatePoint(points[1]));
            }
            private static Point CreatePoint(string input)
            {
                var splited = input.Split(',');
                return new Point(int.Parse(splited[0]), int.Parse(splited[1]));
            }

            public Line(Point p1, Point p2)
            {
                P1 = p1;
                P2 = p2;
                //---------------
                if (P1.Y == P2.Y)
                {
                    Points = new List<Point>();
                    for (int x = Math.Min(P1.X, P2.X); x <= Math.Max(P1.X, P2.X); x++)
                        Points.Add(new Point(x, P1.Y));
                }
                else if (P1.X == P2.X)
                {
                    Points = new List<Point>();
                    for (int y = Math.Min(P1.Y, P2.Y); y <= Math.Max(P1.Y, P2.Y); y++)
                        Points.Add(new Point(P1.X, y));
                }
                else
                {
                    var m = ((double)(P1.Y - P2.Y)) / ((double)(P1.X - P2.X));
                    var c = P1.Y - P1.X * m;
                    //--------------
                    var points = new Dictionary<string, Point>();
                    for (int x = Math.Min(P1.X, P2.X); x <= Math.Max(P1.X, P2.X); x++)
                    {
                        var y = (int)((m * x) + c);
                        var pointKey = $"{x},{y}";
                        if (points.ContainsKey(pointKey) == false)
                            points.Add(pointKey, new Point(x, y));
                    }
                    Points = points.Values.ToList();
                }
            }

            public Point P1 { get; private set; }
            public Point P2 { get; private set; }
            public List<Point> Points { get; internal set; }
            public bool IsHorizontal => P1.Y == P2.Y;
            public bool IsVertical => P1.X == P2.X;
            public bool Is45Degree => Math.Abs(P1.X - P2.X) == Math.Abs(P1.Y - P2.Y);

            public override string ToString()
            {
                if (IsHorizontal) return $"{P1} > {P2} Horizontal ({string.Join(", ", Points)})";
                else if (IsVertical) return $"{P1} > {P2} Vertical ({string.Join(", ", Points)})";
                else if (Is45Degree) return $"{P1} > {P2} 45Degree ({string.Join(", ", Points)})";
                else return $"{P1} > {P2} ({string.Join(", ", Points)})";
            }
        }

        #endregion

        #region Day01
        private static string Day01_1SolveMethod(IEnumerable<string> inputLines)
        {
            var digits = ToDigits(inputLines);
            return CountIncreases(digits).ToString();
        }
        private static string Day01_2SolveMethod(IEnumerable<string> inputLines)
        {
            var digits = ToDigits(inputLines);
            var slidings = new List<int>();
            for (int i = 0; i < digits.Count - 2; i++)
            {
                slidings.Add(digits[i] + digits[i + 1] + digits[i + 2]);
            }
            return CountIncreases(slidings).ToString();

        }
        #endregion

        #region Day02
        private static string Day02_1SolveMethod(IEnumerable<string> inputLines)
        {
            var forwardTotal = 0;
            var depth = 0;
            foreach (var line in inputLines)
            {
                if (line.StartsWith("forward"))
                {
                    var forward = int.Parse(line.Replace("forward", ""));
                    forwardTotal += forward;
                }
                else if (line.StartsWith("down"))
                {
                    depth += int.Parse(line.Replace("down", ""));
                }
                else if (line.StartsWith("up"))
                {
                    depth -= int.Parse(line.Replace("up", ""));
                }
            }
            return (forwardTotal * depth).ToString();
        }
        private static string Day02_2SolveMethod(IEnumerable<string> inputLines)
        {
            var forwardTotal = 0;
            var aim = 0;
            var depth = 0;
            foreach (var line in inputLines)
            {
                if (line.StartsWith("forward"))
                {
                    var forward = int.Parse(line.Replace("forward", ""));
                    forwardTotal += forward;

                    if (aim != 0)
                        depth += forward * aim;
                }
                else if (line.StartsWith("down"))
                {
                    aim += int.Parse(line.Replace("down", ""));
                }
                else if (line.StartsWith("up"))
                {
                    aim -= int.Parse(line.Replace("up", ""));
                }

            }
            return (forwardTotal * depth).ToString();
        }
        #endregion

        #region Day03
        private static string Day03_1SolveMethod(IEnumerable<string> inputLines)
        {
            var HighCounts = new List<int>();
            foreach (var line in inputLines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (HighCounts.Count <= i) HighCounts.Add(0);
                    if (line[i] == '1') HighCounts[i]++;
                }
            }

            var gammaRate = "";
            var epsilonRate = "";
            for (int i = 0; i < HighCounts.Count; i++)
            {
                if (HighCounts[i] > inputLines.Count() - HighCounts[i]) { gammaRate += "1"; epsilonRate += "0"; }
                else { gammaRate += "0"; epsilonRate += "1"; }
            }


            var gammaRateDigit = Convert.ToInt32(gammaRate, 2);
            var epsilonRateDigit = Convert.ToInt32(epsilonRate, 2);

            return (gammaRateDigit * epsilonRateDigit).ToString();

        }
        private static string Day03_2SolveMethod(IEnumerable<string> inputLines)
        {
            if (inputLines.Count() == 0) return "";
            var maxlength = inputLines.First().Trim().Length;
            var miror = inputLines.ToList();
            var col = 0;
            while (col > maxlength || miror.Count > 1)
            {
                var mostCommon = GetMostCommon(miror, col);
                miror.RemoveAll(x => x.Trim()[col] != mostCommon);
                col++;
            }
            var oxygenRating = Convert.ToInt32(miror[0], 2);


            miror = inputLines.ToList();
            col = 0;
            while (col > maxlength || miror.Count > 1)
            {
                var mostCommon = GetMostCommon(miror, col);
                miror.RemoveAll(x => x.Trim()[col] == mostCommon);
                col++;
            }
            var CO2Rating = Convert.ToInt32(miror[0], 2);


            return (oxygenRating * CO2Rating).ToString();

        }

        private static char GetMostCommon(List<string> items, int col)
        {
            var count0 = 0;
            var count1 = 0;
            foreach (var item in items)
            {
                if (item.Trim()[col] == '0') count0++;
                else count1++;
            }
            if (count1 >= count0) return '1';
            else return '0';
        }
        #endregion

        #region Day04
        class Day04Grid
        {
            public Day04Grid(List<List<int>> input)
            {
                rows = input;
                for (int i = 0; i < input.First().Count; i++)
                {
                    cols.Add(new List<int>());
                    foreach (var item in input)
                        cols.Last().Add(item[i]);
                }
            }
            List<List<int>> rows = new List<List<int>>();
            List<List<int>> cols = new List<List<int>>();

            internal bool HitTest(List<int> nums)
            {
                foreach (var row in rows)
                    if (row.Where(x => nums.Contains(x)).Count() == row.Count)
                        return true;

                foreach (var col in cols)
                    if (col.Where(x => nums.Contains(x)).Count() == col.Count)
                        return true;

                return false;
            }

            internal List<int> GetUnmarked(List<int> nums)
                => rows.SelectMany(x => x.Where(y => nums.Contains(y) == false)).ToList();
        }
        private static string Day04_1SolveMethod(IEnumerable<string> inputLines)
        {
            var series = inputLines.First().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            var grids_Rows = new List<List<List<int>>>();
            grids_Rows.Add(new List<List<int>>());
            foreach (var line in inputLines)
            {
                if (line.Contains(',')) continue;
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (grids_Rows.Last().Count >= 5)
                {
                    grids_Rows.Add(new List<List<int>>());
                }
                grids_Rows.Last().Add(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());
            }
            var grids = grids_Rows.Select(x => new Day04Grid(x)).ToList();

            for (int i = 0; i < series.Count; i++)
            {
                var nums = series.Take(i + 1).ToList();
                foreach (var grid in grids)
                {
                    if (grid.HitTest(nums))
                    {
                        var sumOfUnmarked = grid.GetUnmarked(nums).Sum();
                        var lastNum = series[i];
                        return (sumOfUnmarked * lastNum).ToString();
                    }
                }
            }
            return "?";
        }
        private static string Day04_2SolveMethod(IEnumerable<string> inputLines)
        {
            var series = inputLines.First().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            var grids_Rows = new List<List<List<int>>>();
            grids_Rows.Add(new List<List<int>>());
            foreach (var line in inputLines)
            {
                if (line.Contains(',')) continue;
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (grids_Rows.Last().Count >= 5)
                {
                    grids_Rows.Add(new List<List<int>>());
                }
                grids_Rows.Last().Add(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList());
            }
            var grids = grids_Rows.Select(x => new Day04Grid(x)).ToList();
            var winned = new List<Day04Grid>();

            var nums = new List<int>();
            for (int i = 0; i < series.Count; i++)
            {
                nums = series.Take(i + 1).ToList();
                foreach (var grid in grids)
                {
                    if (winned.Contains(grid)) continue;
                    if (grid.HitTest(nums))
                        winned.Add(grid);
                }
                var lastNum = series[i];
                if (winned.Count == grids.Count)
                    break;
            }

            var sumOfUnmarked = winned.Last().GetUnmarked(nums).Sum();
            return (sumOfUnmarked * nums.Last()).ToString();

        }
        #endregion

        #region Day05
        private static string Day05_1SolveMethod(IEnumerable<string> inputLines)
        {
            var lines = Line.CreateLines(inputLines);
            var points = new Dictionary<string, Point>();
            var pointsCounter = new Dictionary<string, int>();
            foreach (var line in lines)
                if (line.IsHorizontal || line.IsVertical)
                    foreach (var point in line.Points)
                    {
                        var pointKey = $"{point.X},{point.Y}";

                        if (points.ContainsKey(pointKey) == false)
                        {
                            points.Add(pointKey, point);
                            pointsCounter.Add(pointKey, 0);
                        }
                        pointsCounter[pointKey]++;
                    }

            return pointsCounter.Where(x => x.Value >= 2).Count().ToString();
        }
        private static string Day05_2SolveMethod(IEnumerable<string> inputLines)
        {
            var lines = Line.CreateLines(inputLines);
            var points = new Dictionary<string, Point>();
            var pointsCounter = new Dictionary<string, int>();
            foreach (var line in lines)
            {
                if (line.IsHorizontal || line.IsVertical || line.Is45Degree)
                    foreach (var point in line.Points)
                    {
                        var pointKey = $"{point.X},{point.Y}";

                        if (points.ContainsKey(pointKey) == false)
                        {
                            points.Add(pointKey, point);
                            pointsCounter.Add(pointKey, 0);
                        }
                        pointsCounter[pointKey]++;
                    }
            }

            return pointsCounter.Where(x => x.Value >= 2).Count().ToString();
        }
        #endregion

        #region Day06
        //public class Lanternfish
        //{
        //    public Lanternfish(int timer)
        //    {
        //        Timer = timer;
        //    }
        //    public int Timer { get; private set; }

        //    public bool DayPassed()
        //    {
        //        Timer--;
        //        if (Timer == -1)
        //        {
        //            Timer = 6;
        //            return true;
        //        }
        //        else return false;
        //    }
        //    public override string ToString() => $"fish({Timer})";

        //}
        private static Dictionary<int, long> CreateNewLanternfishTimers()
        {
            var timers = new Dictionary<int, long>();
            for (int i = 0; i <= 8; i++)
                timers.Add(i, 0);
            return timers;
        }
        public static long ProduceLanternfish2(List<int> initialstate, int days)
        {
            var timers = CreateNewLanternfishTimers();
            foreach (var item in initialstate)
                timers[item]++;

            for (int day = 0; day < days; day++)
            {
                var newTimers = CreateNewLanternfishTimers();
                foreach (var timer in timers)
                {
                    if (timer.Value == 0) continue;
                    if (timer.Key == 0)
                    {
                        newTimers[6] += timer.Value;
                        newTimers[8] += timer.Value;
                    }
                    else
                    {
                        newTimers[timer.Key - 1] += timer.Value;
                    }
                }
                timers = newTimers;
            }
            return timers.Values.Sum();
        }
        private static string Day06_1SolveMethod(IEnumerable<string> inputLines)
        {
            return ProduceLanternfish2(ToDigits(inputLines.First().Split(',')), 80).ToString();
        }
        private static string Day06_2SolveMethod(IEnumerable<string> inputLines)
        {
            return ProduceLanternfish2(ToDigits(inputLines.First().Split(',')), 256).ToString();
        }
        #endregion

        #region Day07
        private static string Day07_1SolveMethod(IEnumerable<string> inputLines)
        {
            var digits = ToDigits(inputLines.First().Split(','));

            var min = digits.Min();
            var max = digits.Max();
            var minCost = long.MaxValue;
            for (int i = min; i <= max; i++)
            {
                var cost = 0;
                foreach (var digit in digits)
                {
                    cost += Math.Abs(digit - i);
                }
                minCost = Math.Min(minCost, cost);
            }
            return minCost.ToString();
        }
        private static string Day07_2SolveMethod(IEnumerable<string> inputLines)
        {
            var digits = ToDigits(inputLines.First().Split(','));

            var min = digits.Min();
            var max = digits.Max();
            var minCost = long.MaxValue;
            for (int i = min; i <= max; i++)
            {
                var cost = 0;
                foreach (var digit in digits)
                {
                    var change = Math.Abs(digit - i);
                    for (int j = 0; j < change; j++)
                        cost += (j + 1);
                }
                minCost = Math.Min(minCost, cost);
            }
            return minCost.ToString();
        }
        #endregion

        //#region DayXX
        //private static string DayXX_1SolveMethod(IEnumerable<string> inputLines)
        //{
        //    throw new NotImplementedException();
        //}
        //private static string DayXX_2SolveMethod(IEnumerable<string> inputLines)
        //{
        //    throw new NotImplementedException();

        //}
        //#endregion
    }
}
