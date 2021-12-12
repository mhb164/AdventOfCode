using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2021
{
    public partial class PuzzleStepUI : UserControl
    {
        public PuzzleStepUI(PuzzleStep content)
        {
            InitializeComponent();
            Content = content;

            DayNumberLabel.Text = $"#{Content.DayNumber:d2}";
            TitleLabel.Text = Content.Title;
            TestPart1Button.Click += (object sender, EventArgs e)=>PerformTestP1();
            SolvePart1Button.Click += (object sender, EventArgs e)=> PerformSolveP1();

            TestPart2Button.Click += (object sender, EventArgs e) => PerformTestP2();
            SolvePart2Button.Click += (object sender, EventArgs e) => PerformSolveP2();
        }
        PuzzleStep Content;

        private void PerformTestP1()
        {
            MessageBox.Show(this, $"Test: {Content.TestPartOne()}",$"Day{Content.DayNumber:d2} Part One");
        }

        private void PerformSolveP1()
        {
            using(var dialog = new InputForm())
                if(dialog.ShowDialog(this)== DialogResult.OK)
                {
                    var result = "";
                    try
                    {
                        result = Content.SolvePartOne(dialog.Lines);
                    }
                    catch (Exception ex) { result = $"Error: {ex.Message}!"; }
                    MessageBox.Show(this, $"Solve result: {result}", $"Day{Content.DayNumber:d2} Part One");

                }
        }
        private void PerformTestP2()
        {
            MessageBox.Show(this, $"Test: {Content.TestPartTwo()}", $"Day{Content.DayNumber:d2} Part Two");
        }

        private void PerformSolveP2()
        {
            using (var dialog = new InputForm())
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    var result = "";
                    try
                    {
                        result = Content.SolvePartTwo(dialog.Lines);
                    }
                    catch (Exception ex) { result = $"Error: {ex.Message}!"; }
                    MessageBox.Show(this, $"Solve result: {result}", $"Day{Content.DayNumber:d2} Part Two");

                }
        }
    }
}
