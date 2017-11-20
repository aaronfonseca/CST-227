/***************************************************************************\
File Name:  MinesweeperGame.cs
Project:    CST-227 MileStone 2
Author:		Aaron Fonseca

MinesweeperGame

Write a MinesweeperGame class that extends the Grid class and implements IPlayable.
The MinesweeperGame class should over-ride the reveal grid method in the Grid class. 
The MinesweeperGame version of the method should display a c?' if a cell has not 
been visited. If a cell has been visited, then the method should display a '—' 
if the cell has no live neighbors and display a numeral if the cell has more than 
0 live neighbors. 

\***************************************************************************/

using System;


namespace cst227_milestone2
{
	class MinesweeperGame: Grid, IPlayable
	{
		Grid game;

		public MinesweeperGame(int grid) : base(grid)
		{ 
		
		}

		// Get Game
		public Grid getGame() 
		{ 
			return this.game; 
		}

		// Set Game
		public void setGame(Grid game)
		{
			this.game = game;
		}

		public override void revealGrid(Grid Grid1)
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
						// If the cell has not been visited
						bool visited = Grid1.square[i, j].getVisited();
						if (!visited)
						{
							Console.Write("|?");
						}
						else {
							if (Convert.ToInt32(Grid1.square[i, j].getNeighbors()) == 0)
							{
								Console.Write("|~");
							}
							else {
								Console.Write("|{0}", Grid1.square[i, j].getNeighbors());
							}
						}
					}
					// If last cell in row Writeline to start new row
					else {

						// If the cell has not been visited
						bool visited = Grid1.square[i, j].getVisited();
						if (!visited)
						{
							Console.WriteLine("|?|");
						}
						else {
							// If the cell has been visited
							if (Convert.ToInt32(Grid1.square[i, j].getNeighbors()) == 0)
							{
								Console.WriteLine("|~|");
							}
							else {
								Console.WriteLine("|{0}|", Grid1.square[i, j].getNeighbors());
							}
						}
					}
				}
			}
			// Update the game grid
			this.setGame(Grid1);
		}

		public void playGame() 
		{
			bool gameRunning = true;

			// While the game is running
			while (gameRunning)
			{
				//Request input
				Console.WriteLine();
				Console.WriteLine("Please select a Cell.");
				Console.Write("Cell Row: ");

				//Get the input
				string row = Console.ReadLine();
				int num = -1;

				//Check to make sure the input is a number
				while (!int.TryParse(row, out num))
				{
					Console.Write("Please only enter numbers.");
					row = Console.ReadLine();
					num = -1;
				}

				// Check if entered row is valid
				while ((Convert.ToInt32(row) > game.square.GetLength(0)) || (Convert.ToInt32(row) < 1))
				{
					Console.Write("Please enter a row on the grid.");
					row = Console.ReadLine();
				}

				Console.Write("Cell Column: ");

				//Get the input
				string column = Console.ReadLine();
				num = -1;

				//Check to make sure the input is a number
				while (!int.TryParse(column, out num))
				{
					Console.Write("Please only enter numbers.");
					column = Console.ReadLine();
					num = -1;
				}

				// Check if entered colum is valid
				while ((Convert.ToInt32(column) > game.square.GetLength(0)) || (Convert.ToInt32(column) < 1))
				{
					Console.Write("Please enter a column on the grid.");
					column = Console.ReadLine();
				}

				Console.WriteLine();

				int y = Convert.ToInt32(row) - 1;
				int x = Convert.ToInt32(column) - 1;

				// if bomb end game
				if ((game.square[y, x].getLive()) && (Convert.ToInt32(game.square[y, x].getNeighbors()) == 9))
				{
					Console.Clear();
					// Reveal game board
					base.revealGrid(game);
					// End of game message
					Console.WriteLine("Your hit a mine, Game Over!");
					gameRunning = false;
				}
				else {
					// Set cell to visited
					this.square[y, x].setVisited(true);
					Console.Clear();
					this.revealGrid(game);

					int cellsVisited = 0;
					int visitedcounter = game.square.GetLength(0) * game.square.GetLength(0);

					for (int i = 0; i < game.square.GetLength(0); i++)
					{
						// Create counter for number of Cells in row
						for (int j = 0; j < game.square.GetLength(0); j++)
						{
							// Check all cells is they have been visited
							if (game.square[i, j].getVisited())
							{
								cellsVisited++;
							}
							// Check all cells if they are a mine
							if (game.square[i, j].getLive())
							{
								cellsVisited++;
							}
						}
					}
					// If you have won the game
					if (cellsVisited == visitedcounter)
					{
						Console.WriteLine("Congratulations, your have Won!");
						gameRunning = false;
					}

				}

			}
		}
	}

}