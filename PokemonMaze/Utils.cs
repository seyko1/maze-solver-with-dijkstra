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

    /// <summary>
    /// Retourne un tableau de type <see cref="bool"/> representant le plus court chemin selon les positions résolues.
    /// </summary>
    /// <param name="array">Le tableau initial.</param>
    /// <param name="positions">Liste des positions résolues.</param>
    /// <returns>Le tableau de type <see cref="bool"/> correspondant</returns>
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
    
    /// <summary>
    /// Affichage d'une liste de valeurs de type <see cref="Step"/>.
    /// </summary>
    /// <param name="steps"></param>
    public static void PrintSteps(List<Step> steps)
    {	
        foreach (var step in steps) 
        {
            Console.WriteLine(step.ToString());
        }
    }
}