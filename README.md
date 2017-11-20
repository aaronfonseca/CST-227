# CST227 Milestone 2

## Aaron Fonseca Grand Canyon University

Project:    CST-227 MileStone 2
Author:		Aaron Fonseca

Milestone 2: Extend the Grid class to model a Minesweeper game object and implement an interface. 
Activity Directions: Change the Grid class to abstract class. Write an interface, IPlayable, that has a single method: 

void playGame(); 

Write a MinesweeperGame class that extends the Grid class and implements IPlayable. The MinesweeperGame class should over-ride the reveal grid method in the Grid class. The MinesweeperGame version of the method should display a c?' if a cell has not been visited. If a cell has been visited, then the method should display a '—' if the cell has no live neighbors and display a numeral if the cell has more than 0 live neighbors. 