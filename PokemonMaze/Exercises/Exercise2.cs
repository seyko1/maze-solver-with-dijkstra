using PokemonMaze.Enums;
using static PokemonMaze.Exercises.Exercice1;

namespace PokemonMaze.Exercises;

public static class Exercice2 
{
    /// <summary>
    /// Convertit un tableau à deux dimensions de type <see cref="char"/> en tableau à deux dimensions de type <see cref="Cell"/>.
    /// </summary>
    /// <param name="array">Tableau de type <see cref="char"/> à convertir.</param>
    /// <returns>Nouvelle instance d'un tableau à deux dimensions de type <see cref="Cell"/>.</returns>
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