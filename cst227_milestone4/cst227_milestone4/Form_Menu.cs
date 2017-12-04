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
    public partial class MINESWEEPER : Form
    {
        public MINESWEEPER()
        {
            InitializeComponent();
            // center from on screen
            this.CenterToScreen();
        }

        // When play game btn is clicked
        private void play_Click(object sender, EventArgs e)
        {
            if (easy_btn.Checked)
            {
                // create new from and pass difficulty
                grid game = new grid(1);
                // show game form
                game.Show();
            }
            else if (moderate_btn.Checked)
            {
                // create new from and pass difficulty
                grid game = new grid(2);
                // show game form
                game.Show();
            } else if (difficult_btn.Checked)
            {
                // create new from and pass difficulty
                grid game = new grid(3);
                // show game form
                game.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
