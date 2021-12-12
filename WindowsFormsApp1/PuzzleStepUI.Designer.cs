namespace AdventOfCode2021
{
    partial class PuzzleStepUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DayNumberLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TestPart1Button = new System.Windows.Forms.Button();
            this.SolvePart1Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SolvePart2Button = new System.Windows.Forms.Button();
            this.TestPart2Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DayNumberLabel
            // 
            this.DayNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DayNumberLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DayNumberLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayNumberLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DayNumberLabel.Location = new System.Drawing.Point(0, 0);
            this.DayNumberLabel.Name = "DayNumberLabel";
            this.DayNumberLabel.Size = new System.Drawing.Size(57, 60);
            this.DayNumberLabel.TabIndex = 0;
            this.DayNumberLabel.Text = "#00";
            this.DayNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(57, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(532, 60);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TestPart1Button
            // 
            this.TestPart1Button.AutoSize = true;
            this.TestPart1Button.Dock = System.Windows.Forms.DockStyle.Left;
            this.TestPart1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestPart1Button.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestPart1Button.ForeColor = System.Drawing.Color.Cyan;
            this.TestPart1Button.Location = new System.Drawing.Point(0, 0);
            this.TestPart1Button.Name = "TestPart1Button";
            this.TestPart1Button.Size = new System.Drawing.Size(97, 30);
            this.TestPart1Button.TabIndex = 2;
            this.TestPart1Button.Text = "Test P1";
            this.TestPart1Button.UseVisualStyleBackColor = true;
            // 
            // SolvePart1Button
            // 
            this.SolvePart1Button.AutoSize = true;
            this.SolvePart1Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SolvePart1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SolvePart1Button.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolvePart1Button.ForeColor = System.Drawing.Color.Cyan;
            this.SolvePart1Button.Location = new System.Drawing.Point(97, 0);
            this.SolvePart1Button.Name = "SolvePart1Button";
            this.SolvePart1Button.Size = new System.Drawing.Size(103, 30);
            this.SolvePart1Button.TabIndex = 3;
            this.SolvePart1Button.Text = "Solve P1";
            this.SolvePart1Button.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SolvePart1Button);
            this.panel1.Controls.Add(this.TestPart1Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(389, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 60);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SolvePart2Button);
            this.panel3.Controls.Add(this.TestPart2Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 30);
            this.panel3.TabIndex = 5;
            // 
            // SolvePart2Button
            // 
            this.SolvePart2Button.AutoSize = true;
            this.SolvePart2Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SolvePart2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SolvePart2Button.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolvePart2Button.ForeColor = System.Drawing.Color.Cyan;
            this.SolvePart2Button.Location = new System.Drawing.Point(97, 0);
            this.SolvePart2Button.Name = "SolvePart2Button";
            this.SolvePart2Button.Size = new System.Drawing.Size(103, 30);
            this.SolvePart2Button.TabIndex = 3;
            this.SolvePart2Button.Text = "Solve P2";
            this.SolvePart2Button.UseVisualStyleBackColor = true;
            // 
            // TestPart2Button
            // 
            this.TestPart2Button.AutoSize = true;
            this.TestPart2Button.Dock = System.Windows.Forms.DockStyle.Left;
            this.TestPart2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestPart2Button.Font = new System.Drawing.Font("Consolas", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestPart2Button.ForeColor = System.Drawing.Color.Cyan;
            this.TestPart2Button.Location = new System.Drawing.Point(0, 0);
            this.TestPart2Button.Name = "TestPart2Button";
            this.TestPart2Button.Size = new System.Drawing.Size(97, 30);
            this.TestPart2Button.TabIndex = 2;
            this.TestPart2Button.Text = "Test P2";
            this.TestPart2Button.UseVisualStyleBackColor = true;
            // 
            // PuzzleStepUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.DayNumberLabel);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "PuzzleStepUI";
            this.Size = new System.Drawing.Size(589, 60);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DayNumberLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button TestPart1Button;
        private System.Windows.Forms.Button SolvePart1Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SolvePart2Button;
        private System.Windows.Forms.Button TestPart2Button;
    }
}
