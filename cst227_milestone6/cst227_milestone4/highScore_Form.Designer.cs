namespace cst227_milestone6
{
    partial class highScore_Form
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
            this.highscore_btn = new System.Windows.Forms.Button();
            this.initials_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yourScore_label = new System.Windows.Forms.Label();
            this.highscore_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top 5 HighScores";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(94, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 2);
            this.label2.TabIndex = 1;
            // 
            // highscore_btn
            // 
            this.highscore_btn.Location = new System.Drawing.Point(197, 226);
            this.highscore_btn.Name = "highscore_btn";
            this.highscore_btn.Size = new System.Drawing.Size(75, 23);
            this.highscore_btn.TabIndex = 3;
            this.highscore_btn.Text = "submit";
            this.highscore_btn.UseVisualStyleBackColor = true;
            this.highscore_btn.Click += new System.EventHandler(this.highscore_btn_Click);
            // 
            // initials_textbox
            // 
            this.initials_textbox.Location = new System.Drawing.Point(12, 226);
            this.initials_textbox.Name = "initials_textbox";
            this.initials_textbox.Size = new System.Drawing.Size(89, 20);
            this.initials_textbox.TabIndex = 4;
            this.initials_textbox.TextChanged += new System.EventHandler(this.initials_textbox_TextChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 2);
            this.label3.TabIndex = 6;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter Your Initials";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Your Score:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // yourScore_label
            // 
            this.yourScore_label.Location = new System.Drawing.Point(194, 197);
            this.yourScore_label.Name = "yourScore_label";
            this.yourScore_label.Size = new System.Drawing.Size(80, 13);
            this.yourScore_label.TabIndex = 8;
            this.yourScore_label.Text = "Your Score:";
            this.yourScore_label.Click += new System.EventHandler(this.yourScore_label_Click);
            // 
            // highscore_label
            // 
            this.highscore_label.Location = new System.Drawing.Point(75, 34);
            this.highscore_label.Name = "highscore_label";
            this.highscore_label.Size = new System.Drawing.Size(150, 154);
            this.highscore_label.TabIndex = 9;
            this.highscore_label.Text = "label6";
            this.highscore_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // highScore_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.highscore_label);
            this.Controls.Add(this.yourScore_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.initials_textbox);
            this.Controls.Add(this.highscore_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "highScore_Form";
            this.Text = "highScore_Form";
            this.Load += new System.EventHandler(this.highScore_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button highscore_btn;
        private System.Windows.Forms.TextBox initials_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label yourScore_label;
        private System.Windows.Forms.Label highscore_label;
    }
}