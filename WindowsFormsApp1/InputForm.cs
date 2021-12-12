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
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }
        public IEnumerable<string> Lines { get; private set; }
        private void NextButton_Click(object sender, EventArgs e)
        {
            Lines = InputTextBox.Lines;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
