using System;
using PokemonMaze.Enums;

namespace PokemonMaze.Exercises;

public static class Exercice1 
{
    /// <summary>
    /// Convertit l'argument de type <see cref="char"/> spécifié en valeur de type <see cref="Cell"/>.
    /// </summary>
    /// <param name="c">La valeur de type <see cref="char"/> à convertir.</param>
    /// <returns>La valeur de type <see cref="Cell"/> correspondante.</returns>
    public static Cell ParseCell(char c)
    {
        switch (c)
        {
            case 'C': return Cell.Cliff;
            case 'E': return Cell.Entrance;
            case 'X': return Cell.Exit;
            case 'H': return Cell.Grass;
            case 'G': return Cell.Ground;
            case 'R': return Cell.Rock;
            case 'S': return Cell.Snow;
            default : throw new ArgumentException();
        }
    }

    /// <summary>
    /// Convertit l'argument de type <see cref="Cell"/> spécifié en valeur de type <see cref="char"/>.
    /// </summary>
    /// <param name="cell">La valeur de type <see cref="Cell"/> à convertir.</param>
    /// <returns>La valeur de type <see cref="char"/> correspondante.</returns>
    public static char PrintCell(Cell cell)
    {
        switch (cell)
        {
            case Cell.Cliff   : return 'C';
            case Cell.Entrance: return 'E';
            case Cell.Exit    : return 'X';
            case Cell.Grass   : return 'H';
            case Cell.Ground  : return 'G';
            case Cell.Rock    : return 'R';
            case Cell.Snow    : return 'S';
            default : throw new Exception();
        }
    }
}