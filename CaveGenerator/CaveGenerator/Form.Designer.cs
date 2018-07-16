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
            this.Canvas = new System.Windows.Forms.Panel();
            this.iterationButton = new System.Windows.Forms.Button();
            this.birthRateBox = new System.Windows.Forms.TextBox();
            this.labelBirth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activeLimitBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.deathLimitBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(12, 77);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(510, 510);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // iterationButton
            // 
            this.iterationButton.Location = new System.Drawing.Point(437, 12);
            this.iterationButton.Name = "iterationButton";
            this.iterationButton.Size = new System.Drawing.Size(75, 23);
            this.iterationButton.TabIndex = 1;
            this.iterationButton.Text = "Do Iteration";
            this.iterationButton.UseVisualStyleBackColor = true;
            // 
            // birthRateBox
            // 
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
            this.activeLimitBox.Location = new System.Drawing.Point(80, 45);
            this.activeLimitBox.Name = "activeLimitBox";
            this.activeLimitBox.Size = new System.Drawing.Size(100, 20);
            this.activeLimitBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Death Limit";
            // 
            // deathLimitBox
            // 
            this.deathLimitBox.Location = new System.Drawing.Point(286, 45);
            this.deathLimitBox.Name = "deathLimitBox";
            this.deathLimitBox.Size = new System.Drawing.Size(100, 20);
            this.deathLimitBox.TabIndex = 6;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(437, 41);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 599);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deathLimitBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.activeLimitBox);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.birthRateBox);
            this.Controls.Add(this.iterationButton);
            this.Controls.Add(this.Canvas);
            this.Name = "Form";
            this.Text = "Form";
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
    }
}