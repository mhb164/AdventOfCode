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
    public partial class MainForm : Form
    {
        public MainForm(List<PuzzleStep> puzzleSteps)
        {
            InitializeComponent();

            PuzzleSteps = puzzleSteps;
        }

        List<PuzzleStep> PuzzleSteps = new List<PuzzleStep>();

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            foreach (var puzzleStep in PuzzleSteps)
            {
                var ui = new PuzzleStepUI(puzzleStep);
                ui.Dock = DockStyle.Top;
                Controls.Add(ui);
                ui.BringToFront();
            }
        }
    }
}
