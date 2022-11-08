using System;
using PokemonMaze.Enums;

namespace PokemonMaze.Exercises;

public static class Exercice6
{
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
}