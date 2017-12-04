using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cst227_milestone4
{
    public partial class grid : Form
    {
        // Get difficulty from Menu
        public int difficulty;
        public grid(int difficulty)
        {
            InitializeComponent();
            // Set difficulty
            this.difficulty = difficulty;
        }

        private void Form_Game_Load(object sender, EventArgs e)
        {
            // allow form to automaticlly get size to fit objects inside
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            // use difficulty to set size of game grid
            int size = difficulty * 10;

            // loop through to create game grid
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // create new clickable Cell button
                    clickableCell newButton = new clickableCell();
                    int x = j * 25;
                    int y = i * 25;
                    newButton.Location = new System.Drawing.Point(x, y);
                    newButton.Size = new System.Drawing.Size(25, 25);
                    this.Controls.Add(newButton);
                }
            }
            // Center the form on screen
            this.CenterToScreen();
        }
    }
}
