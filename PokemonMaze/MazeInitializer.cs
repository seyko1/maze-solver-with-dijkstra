using System;
using System.Linq;
using PokemonMaze.Enums;
using static PokemonMaze.Utils;

namespace PokemonMaze;

public static class MazeInitializer
{
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