/***************************************************************************\
File Name:  Driver.cs
Project:    CST-227 MileStone 2
Author:		Aaron Fonseca

Milestone 2: Extend the Grid class to model a Minesweeper game object and implement an interface. 

The Driver Class.

Write a driver class that has a main method that instantiates a grid and displays a grid.  

\***************************************************************************/

using System;

namespace cst227_milestone2
{
	public class Driver
	{
		public static void Main(string[] args)
		{
			//Request input
			Console.Write("What size is your grid? ");

			//Get the input
			string input = Console.ReadLine();
			int num = -1;

			//Check to make sure the input is a number
			while (!int.TryParse(input, out num))
			{
				Console.Write("Please only enter numbers.");
				input = Console.ReadLine();
				num = -1;
			}

			//Convert input to double 
			double grid = Convert.ToDouble(input);

			Console.WriteLine();

			MinesweeperGame Game = new MinesweeperGame(Convert.ToInt32(grid));

			Game.revealGrid(Game);

			Game.playGame();

		}
	}
}
