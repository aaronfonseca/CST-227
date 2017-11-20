/***************************************************************************\
File Name:  Grid.cs
Project:    CST-227 MileStone 2
Author:		Aaron Fonseca

The Grid Class.
	• A constructor that allocates space for the grid and initializes the grid with cells 
	• A method that activates some of the cells. Use a random number for this. 15 - 20% "live" cells is a good range. 
	• A method that sets the count of each cell's live neighbors. If a cell is "live", then the count should be set to 9. 
	• A method that reveals the grid. If a cell is live, then an asterisk should be displayed. If a cell isn't livel, then the number of live neighbors should be displayed.  

\***************************************************************************/

using System;
using System.Linq;

namespace cst227_milestone2
{

	abstract class Grid
	{
		public Cell[,] square;

		public Grid(int grid)
		{
			// Create Array of Cells
			square = new Cell[grid, grid];

			for (int i = 0; i < square.GetLength(0); i++)
			{
				for (int j = 0; j < square.GetLength(0); j++)
				{
					square[i, j] = new Cell();
					square[i, j].setRow(i);
					square[i, j].setColumn(j);
				}
			}

			// Number of Cells
			double cellNumber = grid * grid;

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
				else {
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
						//Console.WriteLine("Cell {0} is live", liveCounter);
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
							{ neighborsCounter++; }
						}

						// rightNeighbor
						if (i < square.GetLength(0) - 1)
						{
							bool val = square[i + 1, j].getLive();
							if (val)
							{ neighborsCounter++; }
						}

						// topNeighbor
						if (j > 0)
						{
							bool val = square[i, j - 1].getLive();
							if (val)
							{ neighborsCounter++; }
						}

						// bottomNeighbor
						if (j < square.GetLength(0) - 1)
						{
							bool val = square[i, j + 1].getLive();
							if (val)
							{ neighborsCounter++; }
						}

						// topLeftNeighbor
						if ((i > 0) && (j > 0))
						{
							bool val = square[i - 1, j - 1].getLive();
							if (val)
							{ neighborsCounter++; }
						}

						// topRightNeighbor
						if ((i < square.GetLength(0) - 1) && (j > 0))
						{
							bool val = square[i + 1, j - 1].getLive();
							if (val)
							{ neighborsCounter++; }
						}

						// bottomLeftNeighbor
						if ((i > 0) && (j < square.GetLength(0) - 1))
						{
							bool val = square[i - 1, j + 1].getLive();
							if (val)
							{ neighborsCounter++; }
						}

						// bottomRightNeighbor
						if ((i < square.GetLength(0) - 1) && (j < square.GetLength(0) - 1))
						{
							bool val = square[i + 1, j + 1].getLive();
							if (val)
							{ neighborsCounter++; }
						}
						// setNeighbors
						square[i, j].setNeighbors(neighborsCounter);
					}
					else { 
						// if live setNeighbors to 9 
						square[i, j].setNeighbors(9);
					}
				}
			}
		}

		public virtual void revealGrid(Grid Grid1)
		{

			// For each Cell in the Square
			for (int i = 0; i < Grid1.square.GetLength(0); i++)
			{
				// Create counter for number of Cells in row
				int counter = 0;
				for (int j = 0; j < Grid1.square.GetLength(0); j++)
				{
					counter++;
					// If not last cell in row
					if (counter < Grid1.square.GetLength(0))
					{
						bool val = Grid1.square[i, j].getLive();
						if (val)
						{
							Console.Write("|*");
						}
						else {
							Console.Write("|{0}", Grid1.square[i, j].getNeighbors());
						}
					}
					// If last cell in row Writeline to start new row
					else {
						bool val = Grid1.square[i, j].getLive();
						if (val)
						{
							Console.WriteLine("|*|");
						}
						else {
							Console.WriteLine("|{0}|", Grid1.square[i, j].getNeighbors());
						}
					}
				}
			}
		}
	}
}