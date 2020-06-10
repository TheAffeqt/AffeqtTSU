namespace WindowsFormsApplication4
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InputPrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.SellButton = new System.Windows.Forms.Button();
            this.BuyButton = new System.Windows.Forms.Button();
            this.LabelDollars = new System.Windows.Forms.Label();
            this.LabelRubles = new System.Windows.Forms.Label();
            this.InputSell = new System.Windows.Forms.NumericUpDown();
            this.InputBuy = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Sigma = new System.Windows.Forms.NumericUpDown();
            this.MU = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MU)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(2, 162);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Lime;
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "f4";
            series1.Legend = "Legend1";
            series1.Name = "Dollars";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(735, 507);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // InputPrice
            // 
            this.InputPrice.DecimalPlaces = 2;
            this.InputPrice.Location = new System.Drawing.Point(85, 14);
            this.InputPrice.Name = "InputPrice";
            this.InputPrice.Size = new System.Drawing.Size(58, 20);
            this.InputPrice.TabIndex = 1;
            this.InputPrice.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Initial price:";
            // 
            // CalculateButton
            // 
            this.CalculateButton.BackColor = System.Drawing.Color.Transparent;
            this.CalculateButton.Location = new System.Drawing.Point(181, 48);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 5;
            this.CalculateButton.Text = "Go";
            this.CalculateButton.UseVisualStyleBackColor = false;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // SellButton
            // 
            this.SellButton.Location = new System.Drawing.Point(502, 67);
            this.SellButton.Name = "SellButton";
            this.SellButton.Size = new System.Drawing.Size(75, 23);
            this.SellButton.TabIndex = 7;
            this.SellButton.Text = "Sell ($)";
            this.SellButton.UseVisualStyleBackColor = true;
            this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
            // 
            // BuyButton
            // 
            this.BuyButton.Location = new System.Drawing.Point(502, 27);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(75, 23);
            this.BuyButton.TabIndex = 8;
            this.BuyButton.Text = "Buy (₽)";
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // LabelDollars
            // 
            this.LabelDollars.AutoSize = true;
            this.LabelDollars.Location = new System.Drawing.Point(603, 72);
            this.LabelDollars.Name = "LabelDollars";
            this.LabelDollars.Size = new System.Drawing.Size(42, 13);
            this.LabelDollars.TabIndex = 9;
            this.LabelDollars.Text = "Dollars:";
            // 
            // LabelRubles
            // 
            this.LabelRubles.AutoSize = true;
            this.LabelRubles.Location = new System.Drawing.Point(603, 32);
            this.LabelRubles.Name = "LabelRubles";
            this.LabelRubles.Size = new System.Drawing.Size(43, 13);
            this.LabelRubles.TabIndex = 10;
            this.LabelRubles.Text = "Rubles:";
            // 
            // InputSell
            // 
            this.InputSell.DecimalPlaces = 2;
            this.InputSell.Location = new System.Drawing.Point(342, 70);
            this.InputSell.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.InputSell.Name = "InputSell";
            this.InputSell.Size = new System.Drawing.Size(106, 20);
            this.InputSell.TabIndex = 11;
            this.InputSell.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // InputBuy
            // 
            this.InputBuy.DecimalPlaces = 2;
            this.InputBuy.Location = new System.Drawing.Point(342, 30);
            this.InputBuy.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.InputBuy.Name = "InputBuy";
            this.InputBuy.Size = new System.Drawing.Size(106, 20);
            this.InputBuy.TabIndex = 12;
            this.InputBuy.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Amount ($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Amount (₽)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mean Return:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Deviation:";
            // 
            // Sigma
            // 
            this.Sigma.DecimalPlaces = 2;
            this.Sigma.Location = new System.Drawing.Point(85, 84);
            this.Sigma.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Sigma.Name = "Sigma";
            this.Sigma.Size = new System.Drawing.Size(58, 20);
            this.Sigma.TabIndex = 28;
            this.Sigma.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // MU
            // 
            this.MU.DecimalPlaces = 2;
            this.MU.Location = new System.Drawing.Point(85, 51);
            this.MU.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MU.Name = "MU";
            this.MU.Size = new System.Drawing.Size(58, 20);
            this.MU.TabIndex = 27;
            this.MU.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 692);
            this.Controls.Add(this.Sigma);
            this.Controls.Add(this.MU);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputBuy);
            this.Controls.Add(this.InputSell);
            this.Controls.Add(this.LabelRubles);
            this.Controls.Add(this.LabelDollars);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.SellButton);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputPrice);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown InputPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button SellButton;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.Label LabelDollars;
        private System.Windows.Forms.Label LabelRubles;
        private System.Windows.Forms.NumericUpDown InputSell;
        private System.Windows.Forms.NumericUpDown InputBuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Sigma;
        private System.Windows.Forms.NumericUpDown MU;
        private System.Windows.Forms.Timer timer1;
    }
}

