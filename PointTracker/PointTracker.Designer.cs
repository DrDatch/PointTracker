namespace PointTracker
{
    partial class PointTracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointTracker));
            this.button1 = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.camListComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fps = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frames = new System.Windows.Forms.Label();
            this.gainBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.exposureBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fpsBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.contrastBar = new System.Windows.Forms.TrackBar();
            this.brigtnessBar = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.consoleBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brigtnessBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.MaximumSize = new System.Drawing.Size(320, 240);
            this.imageBox1.MinimumSize = new System.Drawing.Size(320, 240);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(320, 240);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // camListComboBox
            // 
            this.camListComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.camListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camListComboBox.Location = new System.Drawing.Point(12, 258);
            this.camListComboBox.Name = "camListComboBox";
            this.camListComboBox.Size = new System.Drawing.Size(225, 21);
            this.camListComboBox.TabIndex = 3;
            this.camListComboBox.SelectedIndexChanged += new System.EventHandler(this.camListComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FPS:";
            // 
            // fps
            // 
            this.fps.AutoSize = true;
            this.fps.BackColor = System.Drawing.Color.Transparent;
            this.fps.Location = new System.Drawing.Point(69, 289);
            this.fps.Name = "fps";
            this.fps.Size = new System.Drawing.Size(13, 13);
            this.fps.TabIndex = 5;
            this.fps.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Frames:";
            // 
            // frames
            // 
            this.frames.AutoSize = true;
            this.frames.BackColor = System.Drawing.Color.Transparent;
            this.frames.Location = new System.Drawing.Point(69, 311);
            this.frames.Name = "frames";
            this.frames.Size = new System.Drawing.Size(13, 13);
            this.frames.TabIndex = 5;
            this.frames.Text = "0";
            // 
            // gainBar
            // 
            this.gainBar.LargeChange = 1;
            this.gainBar.Location = new System.Drawing.Point(366, 51);
            this.gainBar.Maximum = 50;
            this.gainBar.Name = "gainBar";
            this.gainBar.Size = new System.Drawing.Size(210, 45);
            this.gainBar.TabIndex = 6;
            this.gainBar.Scroll += new System.EventHandler(this.gainBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gain";
            // 
            // exposureBar
            // 
            this.exposureBar.LargeChange = 1;
            this.exposureBar.Location = new System.Drawing.Point(366, 102);
            this.exposureBar.Maximum = 50;
            this.exposureBar.Name = "exposureBar";
            this.exposureBar.Size = new System.Drawing.Size(210, 45);
            this.exposureBar.TabIndex = 6;
            this.exposureBar.Scroll += new System.EventHandler(this.exposureBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exposure";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Height";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(405, 147);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(60, 20);
            this.widthBox.TabIndex = 9;
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(515, 147);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(60, 20);
            this.heightBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "FPS";
            // 
            // fpsBox
            // 
            this.fpsBox.Location = new System.Drawing.Point(405, 181);
            this.fpsBox.Name = "fpsBox";
            this.fpsBox.Size = new System.Drawing.Size(60, 20);
            this.fpsBox.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Console";
            // 
            // contrastBar
            // 
            this.contrastBar.LargeChange = 1;
            this.contrastBar.Location = new System.Drawing.Point(604, 51);
            this.contrastBar.Maximum = 50;
            this.contrastBar.Minimum = -50;
            this.contrastBar.Name = "contrastBar";
            this.contrastBar.Size = new System.Drawing.Size(210, 45);
            this.contrastBar.TabIndex = 6;
            this.contrastBar.Scroll += new System.EventHandler(this.contrastBar_Scroll);
            // 
            // brigtnessBar
            // 
            this.brigtnessBar.LargeChange = 1;
            this.brigtnessBar.Location = new System.Drawing.Point(604, 102);
            this.brigtnessBar.Maximum = 50;
            this.brigtnessBar.Minimum = -50;
            this.brigtnessBar.Name = "brigtnessBar";
            this.brigtnessBar.Size = new System.Drawing.Size(210, 45);
            this.brigtnessBar.TabIndex = 6;
            this.brigtnessBar.Scroll += new System.EventHandler(this.brigtnessBar_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(601, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Contrast";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(601, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Brigtness";
            // 
            // consoleBox
            // 
            this.consoleBox.FormattingEnabled = true;
            this.consoleBox.Location = new System.Drawing.Point(364, 266);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(450, 147);
            this.consoleBox.TabIndex = 12;
            // 
            // PointTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(829, 425);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.fpsBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exposureBar);
            this.Controls.Add(this.brigtnessBar);
            this.Controls.Add(this.contrastBar);
            this.Controls.Add(this.gainBar);
            this.Controls.Add(this.frames);
            this.Controls.Add(this.fps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.camListComboBox);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PointTracker";
            this.Text = "PointTracker";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brigtnessBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.ComboBox camListComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label frames;
        private System.Windows.Forms.TrackBar gainBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar exposureBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fpsBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar contrastBar;
        private System.Windows.Forms.TrackBar brigtnessBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox consoleBox;
    }
}

