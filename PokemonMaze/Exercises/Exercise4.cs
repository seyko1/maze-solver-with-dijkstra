using System;
using PokemonMaze.Enums;

namespace PokemonMaze.Exercises;

public static class Exercice4
{
    /// <summary>
    /// Retourne la direction opposée de celle reçue en paramètre.
    /// </summary>
    /// <param name="d">La direction à analyser de type <see cref="Direction"/>.</param>
    /// <returns>La valeur de type <see cref="Direction"/> correspondante.</returns>
    public static Direction GetOpositeDirection(Direction d)
    {
        switch (d)
        {
            case Direction.North: return Direction.South;
            case Direction.South: return Direction.North;
            case Direction.West: return Direction.East;
            case Direction.East: return Direction.West;
            default: throw new Exception();
        }
    }
}