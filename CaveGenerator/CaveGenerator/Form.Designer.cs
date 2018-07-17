namespace CaveGenerator
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.Canvas = new System.Windows.Forms.Panel();
            this.iterationButton = new System.Windows.Forms.Button();
            this.birthRateBox = new System.Windows.Forms.TextBox();
            this.labelBirth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activeLimitBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deathLimitBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.iterationBox = new System.Windows.Forms.TextBox();
            this.singleIterationButton = new System.Windows.Forms.Button();
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(12, 77);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(760, 760);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // iterationButton
            // 
            this.iterationButton.Location = new System.Drawing.Point(405, 8);
            this.iterationButton.Name = "iterationButton";
            this.iterationButton.Size = new System.Drawing.Size(75, 23);
            this.iterationButton.TabIndex = 1;
            this.iterationButton.Text = "Do Iterations";
            this.iterationButton.UseVisualStyleBackColor = true;
            this.iterationButton.Click += new System.EventHandler(this.iterationButton_Click);
            // 
            // birthRateBox
            // 
            this.birthRateBox.Enabled = false;
            this.birthRateBox.Location = new System.Drawing.Point(80, 10);
            this.birthRateBox.Name = "birthRateBox";
            this.birthRateBox.Size = new System.Drawing.Size(100, 20);
            this.birthRateBox.TabIndex = 2;
            // 
            // labelBirth
            // 
            this.labelBirth.AutoSize = true;
            this.labelBirth.Location = new System.Drawing.Point(19, 13);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(54, 13);
            this.labelBirth.TabIndex = 3;
            this.labelBirth.Text = "Birth Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Active Limit";
            // 
            // activeLimitBox
            // 
            this.activeLimitBox.Enabled = false;
            this.activeLimitBox.Location = new System.Drawing.Point(80, 45);
            this.activeLimitBox.Name = "activeLimitBox";
            this.activeLimitBox.Size = new System.Drawing.Size(100, 20);
            this.activeLimitBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Death Limit";
            // 
            // deathLimitBox
            // 
            this.deathLimitBox.Enabled = false;
            this.deathLimitBox.Location = new System.Drawing.Point(275, 45);
            this.deathLimitBox.Name = "deathLimitBox";
            this.deathLimitBox.Size = new System.Drawing.Size(100, 20);
            this.deathLimitBox.TabIndex = 6;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(405, 43);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Birth Rate";
            // 
            // iterationBox
            // 
            this.iterationBox.Enabled = false;
            this.iterationBox.Location = new System.Drawing.Point(275, 10);
            this.iterationBox.Name = "iterationBox";
            this.iterationBox.Size = new System.Drawing.Size(100, 20);
            this.iterationBox.TabIndex = 9;
            // 
            // singleIterationButton
            // 
            this.singleIterationButton.Location = new System.Drawing.Point(487, 7);
            this.singleIterationButton.Name = "singleIterationButton";
            this.singleIterationButton.Size = new System.Drawing.Size(25, 25);
            this.singleIterationButton.TabIndex = 11;
            this.singleIterationButton.Text = "+";
            this.singleIterationButton.UseVisualStyleBackColor = true;
            this.singleIterationButton.Click += new System.EventHandler(this.singleIterationButton_Click);
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Location = new System.Drawing.Point(624, 10);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(120, 21);
            this.algorithmComboBox.TabIndex = 12;
            this.algorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.algorithmComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Algorithm";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 841);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.algorithmComboBox);
            this.Controls.Add(this.singleIterationButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iterationBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deathLimitBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.activeLimitBox);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.birthRateBox);
            this.Controls.Add(this.iterationButton);
            this.Controls.Add(this.Canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "Cave Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Button iterationButton;
        private System.Windows.Forms.TextBox birthRateBox;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox activeLimitBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox deathLimitBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox iterationBox;
        private System.Windows.Forms.Button singleIterationButton;
        private System.Windows.Forms.ComboBox algorithmComboBox;
        private System.Windows.Forms.Label label4;
    }
}