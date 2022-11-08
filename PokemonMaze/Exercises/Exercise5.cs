using System;
using PokemonMaze.Enums;
using PokemonMaze.Exceptions;

namespace PokemonMaze.Exercises;

public static class Exercice5
{
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
}