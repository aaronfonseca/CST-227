/***************************************************************************\
File Name:  clickableCell.cs
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace cst227_milestone5
{
    // Extend button Class
   public class clickableCell : Button
    {
        private double row;       // cell rowNumber
        private double column;    // cell columnNumber
        private bool visited;     // cell has been visited
        private bool live;        // cell is live
        private double neighbors; // cell live neighbors

        // Set initial count to 0
        public int count = 0;

        // On initialize
        public clickableCell()
        {
            // set starting paramaters
            this.BackColor = Color.LightBlue;
            this.Text = "";
            this.setRow(-1);
            this.setColumn(-1);
            this.setVisited(false);
            this.setLive(false);
            this.setNeighbors(0);
        }

        // get cell count
        public int getCount()
        {
            return this.count;
        }

        // set cell count
        public void setCount()
        {
            this.count = this.count + 1;
        }

        // set cell row
        public void setRow(double row)
        {
            this.row = row;
        }

        // set cell column
        public void setColumn(double column)
        {
            this.column = column;
        }

        // set cell visited
        public void setVisited(bool visited)
        {
            this.visited = visited;
        }

        // set cell live value
        public void setLive(bool live)
        {
            this.live = live;
        }

        // set cell neighbors
        public void setNeighbors(double neighbors)
        {
            this.neighbors = neighbors;
        }

        // get cell row
        public double getRow()
        {
            return this.row;
        }

        // get cell column
        public double getCloumn()
        {
            return this.column;
        }

        // get cell visited value
        public bool getVisited()
        {
            return this.visited;
        }

        // get cell live value
        public bool getLive()
        {
            return this.live;
        }

        // get cell neighbors
        public double getNeighbors()
        {
            return this.neighbors;
        }

        // override base onclick method for button class
        protected override void OnClick(EventArgs e)
        {
            
        }

        // Set Grid class for each cell
        public Grid Grid;

        // Have Current Grid class
        public void createGrid(Grid form)
        {
            Grid = form;
        }

        // Control the grid class
        public void ControlGrid(Grid form)
        {
            form.revealGrid();
        }

        // use grind class to check in your have won the game
        public void winGrid(Grid form)
        {
            form.checkWin();
        }

        // reveal the 0's if a 0 value is clicked
        public void revealZerosGrid(Grid form)
        {
            form.revealZeros(Convert.ToInt32(this.getRow()), Convert.ToInt32(this.getCloumn()));
        }

        // Mouse controls
        protected override void OnMouseDown(MouseEventArgs e)
        {
            switch (MouseButtons)
            {
                // On Left Mouse Click
                case MouseButtons.Left:

                    // if you hit a bomb
                    if(this.getNeighbors() == 9)
                    {
                        ControlGrid(Grid);
                        string text = "Game Over";
                        MessageBox.Show(text);
                    }
                    else if (this.getNeighbors() == 0)
                    { 
                    // if you hit an 0
                    this.BackColor = Color.LightGray;
                    this.Image = null;
                    revealZerosGrid(Grid);
                    }
                    // if you hit anything else
                    else if (this.getNeighbors() > 0)
                    {
                        this.BackColor = Color.LightGray;
                        this.Image = null;
                        this.Text = Convert.ToString(this.getNeighbors());
                    }
                    this.setVisited(true);
                    winGrid(Grid);
                    break;

                // On Right Mouse Click
                case MouseButtons.Right:
                    // change text
                    this.Text = "";
                    // Assign an image to the button.
                    this.BackColor = Color.LightGray;
                    this.Image = Properties.Resources.flag;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                break;
            }
        }

        // reveal the bomb in cell is live
        public void revealLive()
        {
            // change text
            this.Text = "";
            // Assign an image to the button.
            this.BackColor = Color.LightGray;
            this.Image = Properties.Resources.bomb;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // reveal the Neighbors for each cell
        public void revealNeighbors()
        {
            // if button has neighbors
            if (this.getNeighbors() > 0) { 
                this.Text = Convert.ToString(this.getNeighbors());
            } else
            {
                this.Text = "";
            }
            // Assign an image to the button.
            this.BackColor = Color.LightGray;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

    }

}
