using PokemonMaze.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using static Maze;

public class Program
{
	public static void Main()
	{
		// random
		// var maze = Maze.InitMaze(10, 10);
		
		// no random
		var maze = ConvertMazeToCell(new char[,] 
		{
			{ 'O', 'R', 'H', 'S', 'R', 'S', 'G', 'G', 'G', 'X' },
			{ 'S', 'C', 'G', 'H', 'S', 'C', 'C', 'H', 'C', 'G' },
			{ 'S', 'G', 'C', 'G', 'S', 'G', 'R', 'G', 'G', 'G' },
			{ 'H', 'G', 'C', 'G', 'S', 'S', 'H', 'S', 'G', 'S' },
			{ 'C', 'S', 'S', 'H', 'S', 'S', 'S', 'H', 'H', 'C' },
			{ 'S', 'C', 'R', 'H', 'G', 'G', 'R', 'S', 'S', 'H' },
			{ 'S', 'S', 'R', 'G', 'H', 'G', 'S', 'C', 'G', 'R' },
			{ 'S', 'R', 'S', 'C', 'G', 'S', 'R', 'G', 'S', 'R' },
			{ 'G', 'G', 'S', 'H', 'G', 'H', 'G', 'S', 'R', 'C' },
			{ 'H', 'G', 'S', 'H', 'R', 'R', 'H', 'S', 'R', 'S' },
		});
		Maze.PrintMaze(maze);
		
		ResolveMaze(maze);	
	}

	public class Step 
	{
		public (int, int) peak { get; set; }
		public (int, int)? source { get; set; }
		public int distance { get; set; }
	}

	public static (bool[,], int) ResolveMaze(Cell[,] array)
    {
		throw new NotImplementedException();
	}
}

