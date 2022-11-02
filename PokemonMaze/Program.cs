using PokemonMaze.Enums;
using PokemonMaze.Models;
using System;
using System.Collections.Generic;
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
			{ 'E', 'R', 'H', 'S', 'R', 'S', 'G', 'G', 'G', 'S' },
			{ 'H', 'C', 'G', 'H', 'S', 'C', 'C', 'H', 'C', 'G' },
			{ 'H', 'G', 'C', 'G', 'S', 'G', 'R', 'G', 'G', 'G' },
			{ 'H', 'G', 'C', 'G', 'S', 'S', 'H', 'S', 'G', 'S' },
			{ 'C', 'S', 'S', 'H', 'S', 'S', 'S', 'H', 'H', 'C' },
			{ 'S', 'C', 'R', 'H', 'G', 'G', 'R', 'S', 'S', 'H' },
			{ 'S', 'S', 'R', 'G', 'H', 'G', 'S', 'C', 'G', 'R' },
			{ 'S', 'R', 'S', 'C', 'G', 'S', 'S', 'G', 'S', 'R' },
			{ 'G', 'G', 'S', 'H', 'G', 'H', 'G', 'X', 'S', 'C' },
		});

		Maze.PrintMaze(maze);
		
		(bool[,] array, int moves)? resolved = ResolveMaze(maze);

		if (resolved is null) 
		{
			Console.WriteLine("Unable to resolve this maze.");
		}
		else
		{
			Console.WriteLine($"Moves : {resolved?.moves}");
			PrintMap(resolved?.array);
		}
	}
}