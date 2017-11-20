/***************************************************************************\
File Name:  Cell.cs
Project:    CST-227 MileStone 2
Author:		Aaron Fonseca

Activity Directions: Create a class that models a Game "cell". A Game cell 
should have the following properties: 
	• Its row and column. These should initially be set to -1. 
	• Whether or not it has been visited. This should initially be false. 
	• Whether or not it is "live". This should initially be false. 
	• The number of neighbors that are "live". This should initially be 0. 
	
Additionally, the game cell class should have a constructor and a way to set 
and get any of the properties described above. 

\***************************************************************************/

namespace cst227_milestone2
{

	public class Cell
	{
		private double row;       // cell rowNumber
		private double column;    // cell columnNumber
		private bool visited;     // cell has been visited
		private bool live;        // cell is live
		private double neighbors; // cell live neighbors

		// Constructor
		public Cell()
		{
			this.setRow(-1);
			this.setColumn(-1);
			this.setVisited(false);
			this.setLive(false);
			this.setNeighbors(0);
		}

		public void setRow(double row)
		{
			this.row = row;
		}

		public void setColumn(double column)
		{
			this.column = column;
		}

		public void setVisited(bool visited)
		{
			this.visited = visited;
		}

		public void setLive(bool live)
		{
			this.live = live;
		}

		public void setNeighbors(double neighbors)
		{
			this.neighbors = neighbors;
		}

		public double getRow()
		{
			return this.row;
		}

		public double getCloumn()
		{
			return this.column;
		}

		public bool getVisited()
		{
			return this.visited;
		}

		public bool getLive()
		{
			return this.live;
		}

		public double getNeighbors()
		{
			return this.neighbors;
		}
	}

}