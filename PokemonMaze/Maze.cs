using PokemonMaze.Enums;
using PokemonMaze.Exceptions;
using PokemonMaze.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonMaze;

public static class Maze
{
    public static Direction[] GetDirections()
	{
		// cf https://stackoverflow.com/questions/105372/how-to-enumerate-an-enum
		return (Direction[])Enum.GetValues(typeof(Direction));
	}

	static Cell[] GetCells()
	{
		return (Cell[])Enum.GetValues(typeof(Cell));
	}

	public static Cell ParseCell(char c)
	{
		switch (c)
		{
			case 'C': return Cell.Cliff;
			case 'E': return Cell.Entrance;
			case 'X': return Cell.Exit;
			case 'H': return Cell.Grass;
			case 'G': return Cell.Ground;
			case 'R': return Cell.Rock;
			case 'S': return Cell.Snow;
			default : throw new ArgumentException();
		}
	}

	public static char PrintCell(Cell cell)
	{
		switch (cell)
		{
			case Cell.Cliff   : return 'C';
			case Cell.Entrance: return 'E';
			case Cell.Exit    : return 'X';
			case Cell.Grass   : return 'H';
			case Cell.Ground  : return 'G';
			case Cell.Rock    : return 'R';
			case Cell.Snow    : return 'S';
			default : throw new Exception();
		}
	}

	public static Cell[,] ConvertMazeToCell(char[,] array)
	{
		var rows           = array.GetLength(0);
		var columns        = array.GetLength(1);
		var convertedArray = new Cell[rows, columns];

		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				Cell cell = ParseCell(array[i, j]);
				convertedArray[i, j] = cell;
			}
		}
		return convertedArray;
	}

	public static void InitArrayValue(bool[,] array, bool b)
	{
		var rows    = array.GetLength(0);
		var columns = array.GetLength(1);

		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				array[i, j] = b;
			}
		}
	}

	public static void PrintMaze(Cell[,] array)
	{
		var rows = array.GetLength(0);
		var columns = array.GetLength(1);
		var output = "";

		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				output += PrintCell(array[i, j]) + " ";
			}
			output += "\n";
		}
		Console.WriteLine(output);
	}

	public static void PrintMap(bool[,] array)
	{
		var rows    = array.GetLength(0);
		var columns = array.GetLength(1);
		var output  = "";

		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				var c = array[i, j] ? "X " : ". " ;
				output += c + " ";
			}
			output += "\n";
		}
		Console.WriteLine(output);
	}

	public static void PrintResolvedMaze(Cell[,] array, List<(int, int)> positions)
	{
		var rows     = array.GetLength(0);
		var columns  = array.GetLength(1);
		var resolved = "";

		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				resolved += positions.Any(p => p == (i, j)) ? "X " : ". ";
			}
			resolved += "\n";
		}
        Console.WriteLine(resolved);
	}

	public static Direction GetOpositeDirection(Direction d)
	{
		switch (d)
		{
			case Direction.North: return Direction.South;
			case Direction.South: return Direction.North;
			case Direction.West: return Direction.East;
			case Direction.East: return Direction.West;
			default: throw new Exception();
		}
	}

	public static (int, int) FindEntrance(Cell[,] array)
	{
		var rows    = array.GetLength(0);
		var columns = array.GetLength(1);

		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				if (array[i, j] == Cell.Entrance) return (i, j);
			}
		}
		throw new EntranceNotFoundException();
	}

	public static bool IsBounded(Cell[,] array, int x, int y)
    {
		var rows    = array.GetLength(0);
		var columns = array.GetLength(1);

		return x >= 0 && x <= --columns && y >= 0 && y <= --rows;
	}

	public static bool IsWalkable(Cell[,] array, int x, int y)
    {
		var cell = array[y, x];
		return cell != Cell.Cliff && cell != Cell.Rock;
    }

	public static bool IsValid(Cell[,] array, int x, int y)
    {
		return IsBounded(array, x, y) && IsWalkable(array, x, y);
    }

	public static (int, int) NextPosition(int x, int y, Direction direction)
    {
		switch (direction)
        {
			case Direction.North: return (--y, x);
			case Direction.South: return (++y, x);
			case Direction.West : return (y, --x);
			case Direction.East : return (y, ++x);
			default : throw new Exception();
		}
	}

	/// <summary>
	/// calcule la position d’arrivée du prochain mouvement du personnage.
	/// </summary>
	/// <param name="array"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="direction"></param>
	/// <returns></returns>
	public static (int, int) NextMove(Cell[,] array, int x, int y, Direction direction, bool sliding = false)
    {		
		(int nextY, int nextX) = NextPosition(x, y, direction);
		if (IsValid(array, nextX, nextY))
        {
			var currentCell = array[y, x];
			var nextCell    = array[nextY, nextX];

			if (nextCell == Cell.Snow)
            {
		        (nextY, nextX) = NextMove(array, nextX, nextY, direction, true);
			}
			
			if (nextCell == Cell.Grass && (!sliding || (currentCell != Cell.Snow && currentCell != Cell.Grass)))
			{
				(nextY, nextX) = NextMove(array, nextX, nextY, direction, true);
			}
			return (nextY, nextX);
        }
		return (y, x);
	}

	/// <summary>
	/// renvoie à partir d'une position le nombre de chemin possible.
	/// </summary>
	/// <param name="array"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public static int CountValidPath(Cell[,] array, int x, int y)
    {
		var counter = 0;

		foreach (var direction in GetDirections())
		{
			(int nextY, int nextX) = NextPosition(x, y, direction);
			if (IsValid(array, nextX, nextY))
			{
				counter++;
			}
		}
		return counter;
	}

	/// <summary>
	/// renvoie vrai si la position indiquée en paramètre ne possède qu'une unique sortie.
	/// </summary>
	/// <param name="array"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public static bool IsDeadEnd(Cell[,] array, int x, int y)
    {
		return CountValidPath(array, x, y) == 1;
    }

	public static bool IsIntersection(Cell[,] array, int x, int y)
	{
		return CountValidPath(array, x, y) > 2;
	}

	public static bool IsExit(Cell[,] array, int x, int y)
	{
		return array[y, x] == Cell.Exit;
	}

	public static Direction GetNextPath(Cell[,] array, int x, int y, Direction from)
    {
		if (!IsDeadEnd(array, x, y) && !IsIntersection(array, x, y))
		{
			foreach (var direction in GetDirections())
			{
				if (direction == from) continue;

				(int nextY, int nextX) = NextPosition(x, y, direction);
				if (IsValid(array, nextX, nextY)) return direction;
			}
		}
		return from;
	}

	public static Cell[,] InitMaze(int rows, int columns)
    {
		var maze   = new Cell[rows, columns];
		var random = new Random();

		var cellDeck = GetCells().Where((c => c != Cell.Entrance && c != Cell.Exit)).ToArray();
		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				var cell = (Cell)cellDeck.GetValue(random.Next(cellDeck.Length));
				maze[i, j] = cell;
			}
		}

		// set entrance
		(int y, int x) entrance = GetRandomSide(rows, columns);
		maze[entrance.y, entrance.x] = Cell.Entrance;		

		// set exit
		(int y, int x) exit;
		while ((exit = GetRandomSide(rows, columns)) == entrance);
		maze[exit.y, exit.x] = Cell.Exit;
		
		return maze;
	}

	static (int, int) GetRandomSide(int rows, int columns)
    {
		var random = new Random();
		return random.Next(4) switch
		{
			0 => (random.Next(0, rows - 1), 0),
			1 => (random.Next(0, rows - 1), columns - 1),
			2 => (0, random.Next(0, columns - 1)),
			3 => (rows - 1, random.Next(0, columns - 1)),
			_ => throw new NotImplementedException()
		};
	}

	public static void PrintSteps(List<Step> steps, Cell[,] array)
	{	
		foreach (var step in steps) 
		{
			Console.WriteLine(step.ToString());
		}
	}

	public static bool[,] GetResolved(Cell[,] array, List<(int, int)> positions)
	{
		var rows           = array.GetLength(0);
		var columns        = array.GetLength(1);
		var convertedArray = new bool[rows, columns];

		for (var i = 0; i < rows; i++)
		{
			for (var j = 0; j < columns; j++)
			{
				convertedArray[i, j] = positions.Any(p => p == (i, j));
			}
		}
		return convertedArray;
	}

	public static (bool[,], int)? ResolveMaze(Cell[,] array)
    {
		var traveled = new List<Step>();
		var toGo = new List<Step>();
		
		(int y, int x) entrance = FindEntrance(array);
		
		toGo.Add(new Step((entrance.y, entrance.x), null, 0));
		bool isExit = false;

		while (toGo.Any())
		{
			Step current = toGo.OrderBy(step => step.distance).First();
			isExit = IsExit(array, current.peak.x, current.peak.y);

			toGo.Remove(current);
			traveled.Add(current);

			if (isExit) break;

			foreach (var direction in GetDirections())
			{
				(int y, int x) nextPeak = NextMove(array, current.peak.x, current.peak.y, direction); 
				
				if (current.peak == nextPeak) continue;
				if (traveled.Any(step => step.peak == nextPeak)) continue;

                var existing = toGo.Find(step => step.peak == nextPeak);

                if (existing is not null)
                {
                    existing.distance = current.distance + 1;
                    existing.from     = current.peak;
                }
                else
                {
				    toGo.Add(new Step(nextPeak, current.peak, current.distance + 1));
                }
			}
		}

		if (!isExit) return null;

		var lastTravel = traveled.Last();
		var totalDistance = lastTravel.distance;
		var peaks = new List<(int y, int x)>() { lastTravel.peak };

		for (int i = 0; i < totalDistance; i++)
		{
			lastTravel = traveled.Find(step => step.peak == lastTravel.from);
			peaks.Add(lastTravel.peak);
		}

		return (GetResolved(array, peaks), totalDistance);
	}
}