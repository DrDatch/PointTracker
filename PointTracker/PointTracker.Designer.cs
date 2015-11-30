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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fpsBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.consoleBox = new System.Windows.Forms.ListBox();
            this.trackVal = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackValMax = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackValMax)).BeginInit();
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Height";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(397, 12);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(60, 20);
            this.widthBox.TabIndex = 9;
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(507, 12);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(60, 20);
            this.heightBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "FPS";
            // 
            // fpsBox
            // 
            this.fpsBox.Location = new System.Drawing.Point(397, 46);
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
            // consoleBox
            // 
            this.consoleBox.FormattingEnabled = true;
            this.consoleBox.Location = new System.Drawing.Point(364, 266);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(450, 147);
            this.consoleBox.TabIndex = 12;
            // 
            // trackVal
            // 
            this.trackVal.LargeChange = 20;
            this.trackVal.Location = new System.Drawing.Point(359, 95);
            this.trackVal.Maximum = 255;
            this.trackVal.Name = "trackVal";
            this.trackVal.Size = new System.Drawing.Size(208, 45);
            this.trackVal.TabIndex = 13;
            this.trackVal.Value = 180;
            this.trackVal.Scroll += new System.EventHandler(this.trackVal_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Value";
            // 
            // trackValMax
            // 
            this.trackValMax.LargeChange = 20;
            this.trackValMax.Location = new System.Drawing.Point(359, 146);
            this.trackValMax.Maximum = 255;
            this.trackValMax.Name = "trackValMax";
            this.trackValMax.Size = new System.Drawing.Size(208, 45);
            this.trackValMax.TabIndex = 13;
            this.trackValMax.Value = 200;
            this.trackValMax.Scroll += new System.EventHandler(this.trackValMax_Scroll);
            // 
            // PointTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(829, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackValMax);
            this.Controls.Add(this.trackVal);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.fpsBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frames);
            this.Controls.Add(this.fps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.camListComboBox);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PointTracker";
            this.Text = "PointTracker";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackValMax)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fpsBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox consoleBox;
        private System.Windows.Forms.TrackBar trackVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackValMax;
    }
}

