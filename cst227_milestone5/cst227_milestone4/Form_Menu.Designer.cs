namespace cst227_milestone5
{
    partial class MINESWEEPER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MINESWEEPER));
            this.playGame_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.difficult_btn = new System.Windows.Forms.RadioButton();
            this.moderate_btn = new System.Windows.Forms.RadioButton();
            this.easy_btn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playGame_btn
            // 
            this.playGame_btn.Location = new System.Drawing.Point(197, 226);
            this.playGame_btn.Name = "playGame_btn";
            this.playGame_btn.Size = new System.Drawing.Size(75, 23);
            this.playGame_btn.TabIndex = 0;
            this.playGame_btn.Text = "Play Game";
            this.playGame_btn.UseVisualStyleBackColor = true;
            this.playGame_btn.Click += new System.EventHandler(this.play_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.difficult_btn);
            this.groupBox1.Controls.Add(this.moderate_btn);
            this.groupBox1.Controls.Add(this.easy_btn);
            this.groupBox1.Location = new System.Drawing.Point(45, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 196);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // difficult_btn
            // 
            this.difficult_btn.AutoSize = true;
            this.difficult_btn.Location = new System.Drawing.Point(66, 144);
            this.difficult_btn.Name = "difficult_btn";
            this.difficult_btn.Size = new System.Drawing.Size(60, 17);
            this.difficult_btn.TabIndex = 2;
            this.difficult_btn.TabStop = true;
            this.difficult_btn.Text = "Difficult";
            this.difficult_btn.UseVisualStyleBackColor = true;
            // 
            // moderate_btn
            // 
            this.moderate_btn.AutoSize = true;
            this.moderate_btn.Location = new System.Drawing.Point(66, 89);
            this.moderate_btn.Name = "moderate_btn";
            this.moderate_btn.Size = new System.Drawing.Size(70, 17);
            this.moderate_btn.TabIndex = 1;
            this.moderate_btn.TabStop = true;
            this.moderate_btn.Text = "Moderate";
            this.moderate_btn.UseVisualStyleBackColor = true;
            // 
            // easy_btn
            // 
            this.easy_btn.AutoSize = true;
            this.easy_btn.Location = new System.Drawing.Point(66, 34);
            this.easy_btn.Name = "easy_btn";
            this.easy_btn.Size = new System.Drawing.Size(48, 17);
            this.easy_btn.TabIndex = 0;
            this.easy_btn.TabStop = true;
            this.easy_btn.Text = "Easy";
            this.easy_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Level";
            // 
            // MINESWEEPER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.playGame_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MINESWEEPER";
            this.Text = "MINESWEEPER";
            this.Load += new System.EventHandler(this.MINESWEEPER_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playGame_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton difficult_btn;
        private System.Windows.Forms.RadioButton moderate_btn;
        private System.Windows.Forms.RadioButton easy_btn;
        private System.Windows.Forms.Label label1;
    }
}

