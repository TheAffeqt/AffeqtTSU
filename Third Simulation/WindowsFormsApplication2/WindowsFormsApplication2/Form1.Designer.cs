namespace WindowsFormsApplication2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.height = new System.Windows.Forms.Label();
            this.angle = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.InputHeight = new System.Windows.Forms.NumericUpDown();
            this.InputAngle = new System.Windows.Forms.NumericUpDown();
            this.InputSpeed = new System.Windows.Forms.NumericUpDown();
            this.PauseButton = new System.Windows.Forms.Button();
            this.InputSize = new System.Windows.Forms.NumericUpDown();
            this.InputWeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labDistance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // height
            // 
            this.height.AutoSize = true;
            this.height.Location = new System.Drawing.Point(12, 26);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(41, 13);
            this.height.TabIndex = 3;
            this.height.Text = "Height:";
            // 
            // angle
            // 
            this.angle.AutoSize = true;
            this.angle.Location = new System.Drawing.Point(12, 64);
            this.angle.Name = "angle";
            this.angle.Size = new System.Drawing.Size(37, 13);
            this.angle.TabIndex = 4;
            this.angle.Text = "Angle:";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Location = new System.Drawing.Point(12, 102);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(41, 13);
            this.speed.TabIndex = 5;
            this.speed.Text = "Speed:";
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(450, 24);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchButton.TabIndex = 6;
            this.LaunchButton.Text = "Go";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(-1, 125);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "FlyingObject";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(766, 424);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InputHeight
            // 
            this.InputHeight.Location = new System.Drawing.Point(70, 24);
            this.InputHeight.Name = "InputHeight";
            this.InputHeight.Size = new System.Drawing.Size(120, 20);
            this.InputHeight.TabIndex = 8;
            // 
            // InputAngle
            // 
            this.InputAngle.Location = new System.Drawing.Point(70, 62);
            this.InputAngle.Name = "InputAngle";
            this.InputAngle.Size = new System.Drawing.Size(120, 20);
            this.InputAngle.TabIndex = 9;
            this.InputAngle.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // InputSpeed
            // 
            this.InputSpeed.Location = new System.Drawing.Point(70, 100);
            this.InputSpeed.Name = "InputSpeed";
            this.InputSpeed.Size = new System.Drawing.Size(120, 20);
            this.InputSpeed.TabIndex = 10;
            this.InputSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(436, 80);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(100, 23);
            this.PauseButton.TabIndex = 11;
            this.PauseButton.Text = "Pause or Start";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // InputSize
            // 
            this.InputSize.DecimalPlaces = 2;
            this.InputSize.Location = new System.Drawing.Point(278, 24);
            this.InputSize.Name = "InputSize";
            this.InputSize.Size = new System.Drawing.Size(120, 20);
            this.InputSize.TabIndex = 13;
            this.InputSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            // 
            // InputWeight
            // 
            this.InputWeight.Location = new System.Drawing.Point(278, 83);
            this.InputWeight.Name = "InputWeight";
            this.InputWeight.Size = new System.Drawing.Size(120, 20);
            this.InputWeight.TabIndex = 14;
            this.InputWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Weight:";
            // 
            // labDistance
            // 
            this.labDistance.AutoSize = true;
            this.labDistance.Location = new System.Drawing.Point(547, 53);
            this.labDistance.Name = "labDistance";
            this.labDistance.Size = new System.Drawing.Size(52, 13);
            this.labDistance.TabIndex = 17;
            this.labDistance.Text = "Distance:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 544);
            this.Controls.Add(this.labDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputWeight);
            this.Controls.Add(this.InputSize);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.InputSpeed);
            this.Controls.Add(this.InputAngle);
            this.Controls.Add(this.InputHeight);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.angle);
            this.Controls.Add(this.height);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label height;
        private System.Windows.Forms.Label angle;
        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown InputHeight;
        private System.Windows.Forms.NumericUpDown InputAngle;
        private System.Windows.Forms.NumericUpDown InputSpeed;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.NumericUpDown InputSize;
        private System.Windows.Forms.NumericUpDown InputWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labDistance;
    }
}

