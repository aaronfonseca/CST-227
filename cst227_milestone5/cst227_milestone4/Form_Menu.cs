/***************************************************************************\
File Name:  Form_Menu.cs
Project:    CST-227 MileStone 5
Author:		Aaron Fonseca

Milestone 5: Combine GUI and Game Logic for the Minesweeper application and 
incorporate a stop watch to record time elapsed. 

Activity Directions: Add the game play logic to your GUI application. 
Use the logic you developed in the console application version of the project. 
Your goal is to be able to play a game to completion. There are several "expected" 
features in the classic Minesweeper game. Be sure to implement these into your project. 

• If a user clicks on a mine, the entire game board is revealed with "bomb" 
pictures on the mines and a "Game Over" message displays. 

• If a user successfully exposes all squares without clicking on a mine, 
the entire game board is revealed with "flag" pictures on the mines and a 
"You Win" message displays • If a user right-clicks on a square, a "flag" 
picture is placed on the square.

• Add a stop watch to your application and record the length of time it takes
a player to win the game. Display the elapsed time with the "You Win" message. 
 

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cst227_milestone5
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
                Grid game = new Grid(1);
                // show game form
                game.Show();
            }
            else if (moderate_btn.Checked)
            {
                // create new from and pass difficulty
                Grid game = new Grid(2);
                // show game form
                game.Show();
            } else if (difficult_btn.Checked)
            {
                // create new from and pass difficulty
                Grid game = new Grid(3);
                // show game form
                game.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MINESWEEPER_Load(object sender, EventArgs e)
        {

        }
    }
}
