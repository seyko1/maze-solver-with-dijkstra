using System;
using System.Linq;
using PokemonMaze.Enums;
using static PokemonMaze.Utils;

namespace PokemonMaze;

public static class MazeInitializer
{
    /// <summary>
    /// Initialise un tableau à deux dimensions de type <see cref="Cell"/> selon les longueurs spécifiées.
    /// </summary>
    /// <param name="rows">Nombre de lignes d'un tableau à deux dimensions.</param>
    /// <param name="columns">Nombre de colonnes d'un tableau à deux dimensions.</param>
    /// <returns>Un tableau à deux dimensions de type <see cref="Cell"/>.</returns>
    public static Cell[,] Init(int rows, int columns)
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

    /// <summary>
    /// Retourne une position <see cref="(int, int)"/> aléatoire.
    /// </summary>
    /// <param name="rows">Nombre de lignes d'un tableau à deux dimensions.</param>
    /// <param name="columns">Nombre de colonnes d'un tableau à deux dimensions.</param>
    /// <returns>Un tuple <see cref="(int, int)"/> correspondant à une position aléatoire.</returns>
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
} 