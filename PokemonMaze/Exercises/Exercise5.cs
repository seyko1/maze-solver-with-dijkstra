using System;
using PokemonMaze.Enums;
using PokemonMaze.Exceptions;

namespace PokemonMaze.Exercises;

public static class Exercice5
{
    /// <summary>
    /// Initialise les valeurs d'un tableau à deux dimensions de type <see cref="bool"/>.
    /// </summary>
    /// <param name="array">Le tableau à deux dimensions dont les valeurs sont à initialiser.</param>
    /// <param name="b">La valeur de type <see cref="bool"/> souhaitée pour initialiser les valeurs de <paramref name="array"/>.</param>
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

    /// <summary>
    /// Affiche dans la sortie console un tableau à deux dimensions de type <see cref="bool"/>.
    /// </summary>
    /// <param name="array">Le tableau à deux dimensions de type <see cref="bool"/> à afficher.</param>
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

    /// <summary>
    /// Recherche une position correspondant à l'entrée <see cref="Cell.Entrance"/> dans un tableau à deux dimensions de type <see cref="Cell"/>.
    /// </summary>
    /// <param name="array">Le tableau de type <see cref="Cell"/> à analyser.</param>
    /// <returns>Un tuple <see cref="(int, int)"/> correspondant à la position de l'entrée.</returns>
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