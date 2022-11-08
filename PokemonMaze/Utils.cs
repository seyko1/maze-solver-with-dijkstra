using System;
using System.Collections.Generic;
using System.Linq;
using PokemonMaze.Enums;
using PokemonMaze.Models;

namespace PokemonMaze;

public static class Utils 
{
    public static Direction[] GetDirections()
    {
        // cf https://stackoverflow.com/questions/105372/how-to-enumerate-an-enum
        return (Direction[])Enum.GetValues(typeof(Direction));
    }

    public static Cell[] GetCells()
    {
        return (Cell[])Enum.GetValues(typeof(Cell));
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

    public static void PrintSteps(List<Step> steps, Cell[,] array)
    {	
        foreach (var step in steps) 
        {
            Console.WriteLine(step.ToString());
        }
    }
}