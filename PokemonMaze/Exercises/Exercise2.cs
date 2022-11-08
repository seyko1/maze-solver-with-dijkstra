using PokemonMaze.Enums;
using static PokemonMaze.Exercises.Exercice1;

namespace PokemonMaze.Exercises;

public static class Exercice2 
{
    /// <summary>
    /// Convertit un tableau à deux dimensions de caractère en tableau à deux dimensions de cellules.
    /// </summary>
    /// <param name="array">Tableau de caractère à convertir.</param>
    /// <returns>Nouvelle instance d'un tableau à deux dimensions de cellules.</returns>
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
}