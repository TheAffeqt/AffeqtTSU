namespace SimulationDice
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DiceBox1 = new System.Windows.Forms.TextBox();
            this.DiceBox2 = new System.Windows.Forms.TextBox();
            this.RollButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.RichTextBox();
            this.LabelLoss = new System.Windows.Forms.Label();
            this.LabelWin = new System.Windows.Forms.Label();
            this.CheckCheat = new System.Windows.Forms.CheckBox();
            this.LabelSum1 = new System.Windows.Forms.Label();
            this.LabelSum2 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Dice:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enemy Dice:";
            // 
            // DiceBox1
            // 
            this.DiceBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DiceBox1.Location = new System.Drawing.Point(39, 81);
            this.DiceBox1.Name = "DiceBox1";
            this.DiceBox1.ReadOnly = true;
            this.DiceBox1.Size = new System.Drawing.Size(35, 29);
            this.DiceBox1.TabIndex = 2;
            // 
            // DiceBox2
            // 
            this.DiceBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DiceBox2.Location = new System.Drawing.Point(135, 81);
            this.DiceBox2.Name = "DiceBox2";
            this.DiceBox2.ReadOnly = true;
            this.DiceBox2.Size = new System.Drawing.Size(35, 29);
            this.DiceBox2.TabIndex = 3;
            // 
            // RollButton
            // 
            this.RollButton.BackColor = System.Drawing.Color.Coral;
            this.RollButton.Location = new System.Drawing.Point(59, 174);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(96, 58);
            this.RollButton.TabIndex = 1;
            this.RollButton.Text = "ROLL";
            this.RollButton.UseVisualStyleBackColor = false;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "2 Dice Game";
            // 
            // ResultBox
            // 
            this.ResultBox.BackColor = System.Drawing.Color.Teal;
            this.ResultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ResultBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.ResultBox.Location = new System.Drawing.Point(28, 281);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(165, 56);
            this.ResultBox.TabIndex = 6;
            this.ResultBox.Text = "";
            // 
            // LabelLoss
            // 
            this.LabelLoss.AutoSize = true;
            this.LabelLoss.Location = new System.Drawing.Point(142, 368);
            this.LabelLoss.Name = "LabelLoss";
            this.LabelLoss.Size = new System.Drawing.Size(66, 13);
            this.LabelLoss.TabIndex = 7;
            this.LabelLoss.Text = "Enemy wins:";
            // 
            // LabelWin
            // 
            this.LabelWin.AutoSize = true;
            this.LabelWin.Location = new System.Drawing.Point(2, 368);
            this.LabelWin.Name = "LabelWin";
            this.LabelWin.Size = new System.Drawing.Size(56, 13);
            this.LabelWin.TabIndex = 8;
            this.LabelWin.Text = "Your wins:";
            // 
            // CheckCheat
            // 
            this.CheckCheat.AutoSize = true;
            this.CheckCheat.Location = new System.Drawing.Point(42, 247);
            this.CheckCheat.Name = "CheckCheat";
            this.CheckCheat.Size = new System.Drawing.Size(128, 17);
            this.CheckCheat.TabIndex = 9;
            this.CheckCheat.Text = "Cheating Dice for me!";
            this.CheckCheat.UseVisualStyleBackColor = true;
            // 
            // LabelSum1
            // 
            this.LabelSum1.AutoSize = true;
            this.LabelSum1.Location = new System.Drawing.Point(36, 122);
            this.LabelSum1.Name = "LabelSum1";
            this.LabelSum1.Size = new System.Drawing.Size(34, 13);
            this.LabelSum1.TabIndex = 10;
            this.LabelSum1.Text = "Sum :";
            // 
            // LabelSum2
            // 
            this.LabelSum2.AutoSize = true;
            this.LabelSum2.Location = new System.Drawing.Point(132, 122);
            this.LabelSum2.Name = "LabelSum2";
            this.LabelSum2.Size = new System.Drawing.Size(34, 13);
            this.LabelSum2.TabIndex = 11;
            this.LabelSum2.Text = "Sum :";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(67, 158);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(74, 13);
            this.labelCount.TabIndex = 12;
            this.labelCount.Text = "Count of rolls :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 399);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.LabelSum2);
            this.Controls.Add(this.LabelSum1);
            this.Controls.Add(this.CheckCheat);
            this.Controls.Add(this.LabelWin);
            this.Controls.Add(this.LabelLoss);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RollButton);
            this.Controls.Add(this.DiceBox2);
            this.Controls.Add(this.DiceBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DiceBox1;
        private System.Windows.Forms.TextBox DiceBox2;
        private System.Windows.Forms.Button RollButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ResultBox;
        private System.Windows.Forms.Label LabelLoss;
        private System.Windows.Forms.Label LabelWin;
        private System.Windows.Forms.CheckBox CheckCheat;
        private System.Windows.Forms.Label LabelSum1;
        private System.Windows.Forms.Label LabelSum2;
        private System.Windows.Forms.Label labelCount;
    }
}

