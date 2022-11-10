using System;
using PokemonMaze.Enums;

namespace PokemonMaze.Exercises;

public static class Exercice6
{
    /// <summary>
    /// Permet de savoir si une coordonnée ne dépasse pas les limites du tableau.
    /// </summary>
    /// <param name="array">Tableau de type <see cref="Cell"/> à analyser.</param>
    /// <param name="x">La position x actuelle du personnage.</param>
    /// <param name="y">La position y actuelle du personnage.</param>
    /// <returns><c>true</c> si la position ne dépasse pas les limites du tableau analysé.</returns>
    public static bool IsBounded(Cell[,] array, int x, int y)
    {
        var rows    = array.GetLength(0);
        var columns = array.GetLength(1);

        return x >= 0 && x <= --columns && y >= 0 && y <= --rows;
    }

    /// <summary>
    /// Permet de savoir si une coordonnée est une valeur <see cref="Cell"/> praticable.
    /// </summary>
    /// <param name="array">Tableau de type <see cref="Cell"/> à analyser.</param>
    /// <param name="x">La position x actuelle du personnage.</param>
    /// <param name="y">La position y actuelle du personnage.</param>
    /// <returns><c>true</c> si la position est une valeur <see cref="Cell"/> praticable.</returns>
    public static bool IsWalkable(Cell[,] array, int x, int y)
    {
        var cell = array[y, x];
        return cell != Cell.Cliff && cell != Cell.Rock;
    }

    /// <summary>
    /// Permet de savoir si une coordonnée est une valeur <see cref="Cell"/> praticable et ne dépasse pas les limites du tableau.
    /// </summary>
    /// <param name="array">Tableau de type <see cref="Cell"/> à analyser.</param>
    /// <param name="x">La position x actuelle du personnage.</param>
    /// <param name="y">La position y actuelle du personnage.</param>
    /// <returns><c>true</c> si la position est valide.</returns>
    public static bool IsValid(Cell[,] array, int x, int y)
    {
        return IsBounded(array, x, y) && IsWalkable(array, x, y);
    }

    /// <summary>
    /// Renvoie un tuple <see cref="(int, int)"/> représentant la prochaine position du personnage en fonction de sa direction.
    /// </summary>
    /// <param name="x">La position x actuelle du personnage.</param>
    /// <param name="y">La position y actuelle du personnage.</param>
    /// <param name="direction">La direction de type <see cref="Direction"/> du prochain mouvement du personnage.</param>
    /// <returns>Un tuple <see cref="(int, int)"/> correspondant à la prochaine position.</returns>
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
    /// Calcule la position d’arrivée <see cref="(int, int)"/> du prochain mouvement du personnage.
    /// </summary>
    /// <param name="array">Le tableau de type <see cref="Cell"/> à analyser.</param>
    /// <param name="x">La position x actuelle du personnage.</param>
    /// <param name="y">La position y actuelle du personnage.</param>
    /// <param name="direction">La direction de type <see cref="Direction"/> du prochain mouvement du personnage.</param>
    /// <returns>La position d'arrivée <see cref="(int, int)"/> du personnage.</returns>
    public static (int, int) NextMove(Cell[,] array, int x, int y, Direction direction)
    {
        // Ici, nous exposons volontairement NextMove() en public pour masquer le paramètre sliding.
        // C'est une fonction "vide" qui se contente d'appeler la fonction récursive avec un paramètre d'initialisation pour l'accumulateur sliding.
        return NextMove(array, x , y, direction, false);
    }

    // Fonction récursive utilisant l'accumulateur sliding pour gérer le cas où le personnage passe sur une case glissante du labyrinthe.
    private static (int, int) NextMove(Cell[,] array, int x, int y, Direction direction, bool sliding)
    {
        (int nextY, int nextX) = NextPosition(x, y, direction);
        
        if (IsValid(array, nextX, nextY))
        {
            var currentCell = array[y, x];
            var nextCell    = array[nextY, nextX];

            if (nextCell == Cell.Snow || (nextCell == Cell.Grass && !sliding))
            {
                (nextY, nextX) = NextMove(array, nextX, nextY, direction, true);
            }

            return (nextY, nextX);
        }
        return (y, x);
    }
}