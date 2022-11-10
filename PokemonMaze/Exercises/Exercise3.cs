using System;
using PokemonMaze.Enums;
using static PokemonMaze.Exercises.Exercice1;

namespace PokemonMaze.Exercises;

public static class Exercice3 
{
    /// <summary>
    /// Affiche dans la console un tableau à deux dimensions de type <see cref="Cell"/>.
    /// </summary>
    /// <param name="array">Tableau de type <see cref="Cell"/> à afficher.</param>
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
}