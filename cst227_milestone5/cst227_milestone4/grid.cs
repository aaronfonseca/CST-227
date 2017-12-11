/***************************************************************************\
File Name:  grid.cs
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
using System.Diagnostics;
using System.Threading;

namespace cst227_milestone5
{
    public partial class Grid : Form
    {
        public clickableCell[,] square;
        int size;

        // create stopwatch
        Stopwatch stopWatch = new Stopwatch();

        // Get difficulty from Menu
        public int difficulty;

        public Grid(int difficulty)
        {
            InitializeComponent();
            // Set difficulty
            this.difficulty = difficulty;
        }

        private void Form_Game_Load(object sender, EventArgs e)
        {
            // start timer
            stopWatch.Start();

            // allow form to automaticlly get size to fit objects inside
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // use difficulty to set size of game Grid
            size = difficulty * 10;

            // create array of clickableCells
            square = new clickableCell[size, size];

            // loop through to create game Grid
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // create new clickable Cell button
                    square[i, j] = new clickableCell();
                    int x = j * 25;
                    int y = i * 25;
                    square[i, j].Location = new System.Drawing.Point(x, y);
                    square[i, j].Size = new System.Drawing.Size(25, 25);
                    square[i, j].setRow(i);
                    square[i, j].setColumn(j);
                    square[i, j].createGrid(this);
                    this.Controls.Add(square[i, j]);
                }
            }

            // Number of Cells
            double cellNumber = size * size;

            // Get random percentage between 15-20
            Random rnd = new Random();
            double ranPercent = rnd.Next(15, 20);

            // Use random percentage to find number of cells that will be live
            ranPercent = ranPercent / 100;
            double randomCount = Math.Round(cellNumber * ranPercent, 0);

            int[] randomLive = new int[Convert.ToInt32(randomCount)];

            // Create Array of random cells to turn live
            for (int i = 0; i < randomCount; i++)
            {
                double cellLive = rnd.Next(0, Convert.ToInt32(cellNumber));

                int pos = Array.IndexOf(randomLive, cellLive);
                if (pos > -1)
                {
                    // check randomLive array, is number is present do not add to array
                    return;
                }
                else
                {
                    randomLive[i] = Convert.ToInt32(cellLive);
                    //Console.WriteLine(cellLive);
                }
            }

            // Loop through and make cells live.
            int liveCounter = 0;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(0); j++)
                {
                    if (randomLive.Contains(liveCounter))
                    {
                        square[i, j].setLive(true);
                    }
                    liveCounter++;
                }
            }

            // Loop through and set neighbors count.
            int neighborsCounter = 0;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(0); j++)
                {
                    neighborsCounter = 0;
                    bool cellVal = square[i, j].getLive();
                    if (cellVal == false)
                    {
                        // leftNeighbor
                        if (i > 0)
                        {
                            bool val = square[i - 1, j].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // rightNeighbor
                        if (i < square.GetLength(0) - 1)
                        {
                            bool val = square[i + 1, j].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // topNeighbor
                        if (j > 0)
                        {
                            bool val = square[i, j - 1].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // bottomNeighbor
                        if (j < square.GetLength(0) - 1)
                        {
                            bool val = square[i, j + 1].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // topLeftNeighbor
                        if ((i > 0) && (j > 0))
                        {
                            bool val = square[i - 1, j - 1].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // topRightNeighbor
                        if ((i < square.GetLength(0) - 1) && (j > 0))
                        {
                            bool val = square[i + 1, j - 1].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // bottomLeftNeighbor
                        if ((i > 0) && (j < square.GetLength(0) - 1))
                        {
                            bool val = square[i - 1, j + 1].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }

                        // bottomRightNeighbor
                        if ((i < square.GetLength(0) - 1) && (j < square.GetLength(0) - 1))
                        {
                            bool val = square[i + 1, j + 1].getLive();
                            if (val)
                            {
                                neighborsCounter++;
                            }
                        }
                        // setNeighbors
                        square[i, j].setNeighbors(neighborsCounter);
                    }
                    else
                    {
                        // if live setNeighbors to 9 
                        square[i, j].setNeighbors(9);
                    }
                }
            }
            // Center the form on screen
            this.CenterToScreen();
        }

        public virtual void revealGrid()
        {

            // For each Cell in the Square
            for (int i = 0; i < square.GetLength(0); i++)
            {
                // Create counter for number of Cells in row
                int counter = 0;
                for (int j = 0; j < square.GetLength(0); j++)
                {
                    if (counter < square.GetLength(0))
                    {
                        bool val = square[i, j].getLive();
                        if (val)
                        {
                            square[i, j].revealLive();
                        }
                        else
                        {
                            square[i, j].revealNeighbors();
                        }

                    }
                }
            }
        }

        // Recursive algorithm that reveals blocks of cells with no live neighbors
        public void revealZeros(int i, int j)
        {

            bool cellVal = square[i, j].getLive();
            if (cellVal == false)
            {
                // leftNeighbor
                if (i > 0)
                {
                    // Get Neighbors
                    double val = square[i - 1, j].getNeighbors();
                    bool visited = square[i - 1, j].getVisited();

                    // if neighbor 0
                    if ((Convert.ToInt32(val) == 0) && (!visited))
                    {
                        // turn neighbor to visited
                        square[i - 1, j].setVisited(true);
                        square[i - 1, j].revealNeighbors();
                        revealZeros(i - 1, j);
                    }
                    else if ((Convert.ToInt32(val) < 9) && (!visited))
                    {
                        square[i - 1, j].setVisited(true);
                        square[i - 1, j].revealNeighbors();
                    }
                }

                // rightNeighbor
                if (i < square.GetLength(0) - 1)
                {
                    // Get Neighbors
                    double val = square[i + 1, j].getNeighbors();
                    bool visited = square[i + 1, j].getVisited();

                    // if neighbor 0
                    if ((Convert.ToInt32(val) == 0) && (!visited))
                    {
                        // turn neighbor to visited
                        square[i + 1, j].setVisited(true);
                        square[i + 1, j].revealNeighbors();
                        revealZeros(i + 1, j);
                    }
                    else if ((Convert.ToInt32(val) < 9) && (!visited))
                    {
                        square[i + 1, j].setVisited(true);
                        square[i + 1, j].revealNeighbors();
                    }
                }

                // topNeighbor
                if (j > 0)
                {
                    // Get Neighbors
                    double val = square[i, j - 1].getNeighbors();
                    bool visited = square[i, j - 1].getVisited();

                    // if neighbor 0
                    if ((Convert.ToInt32(val) == 0) && (!visited))
                    {
                        // turn neighbor to visited
                        square[i, j - 1].setVisited(true);
                        square[i, j - 1].revealNeighbors();
                        revealZeros(i, j - 1);
                    }
                    else if ((Convert.ToInt32(val) < 9) && (!visited))
                    {
                        square[i, j - 1].setVisited(true);
                        square[i, j - 1].revealNeighbors();
                    }
                }

                // bottomNeighbor
                if (j < square.GetLength(0) - 1)
                {
                    double val = square[i, j + 1].getNeighbors();
                    bool visited = square[i, j + 1].getVisited();

                    // if neighbor 0
                    if ((Convert.ToInt32(val) == 0) && (!visited))
                    {
                        // turn neighbor to visited
                        square[i, j + 1].setVisited(true);
                        square[i, j + 1].revealNeighbors();
                        revealZeros(i, j + 1);
                    }
                    else if ((Convert.ToInt32(val) < 9) && (!visited))
                    {
                        square[i, j + 1].setVisited(true);
                        square[i, j + 1].revealNeighbors();
                    }
                }
            }
            return;
        }

        public void checkWin()
        {
            // Check if game has been won
            int cellsVisited = 0;
            int visitedcounter = size * size;

            for (int i = 0; i < size; i++)
            {
                // Create counter for number of Cells in row
                for (int j = 0; j < size; j++)
                {
                    // Check all cells is they have been visited
                    if (square[i, j].getVisited())
                    {
                        cellsVisited++;
                    }
                    // Check all cells if they are a mine
                    if (square[i, j].getLive())
                    {
                        cellsVisited++;
                    }
                }
            }
            // If you have won the game
            if (cellsVisited == visitedcounter)
            {
                // stop timer
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                string text = "Congratulations, your have Won!" + Environment.NewLine + "Time elapsed: " + elapsedTime + "seconds.";
                MessageBox.Show(text);
            }
        }
                        
    }
}
