using PokemonMaze.Enums;
using static PokemonMaze.Utils;
using static PokemonMaze.Exercises.Exercice6;

namespace PokemonMaze.Exercises;

public static class Exercice7
{
    /// <summary>
    /// Renvoie le nombre de chemin possible à partir d'une position.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>Le nombre de chemin possible.</returns>
    public static int CountValidPath(Cell[,] array, int x, int y)
    {
        var counter = 0;

        foreach (var direction in GetDirections())
        {
            (int nextY, int nextX) = NextPosition(x, y, direction);
            if (IsValid(array, nextX, nextY))
            {
                counter++;
            }
        }
        return counter;
    }

    /// <summary>
    /// Renvoie vrai si la position indiquée en paramètre ne possède qu'une unique sortie.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>La valeur booléenne du résultat.</returns>
    public static bool IsDeadEnd(Cell[,] array, int x, int y)
    {
        return CountValidPath(array, x, y) == 1;
    }

    /// <summary>
    /// Renvoie vrai si la position indiquée en paramètre est une intersection à plus de deux sorties.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>La valeur booléenne du résultat.</returns>
    public static bool IsIntersection(Cell[,] array, int x, int y)
    {
        return CountValidPath(array, x, y) > 2;
    }

    /// <summary>
    /// Renvoie vrai si la position indiquée en paramètre est la sortie.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>La valeur booléenne du résultat.</returns>
    public static bool IsExit(Cell[,] array, int x, int y)
    {
        return array[y, x] == Cell.Exit;
    }

    /// <summary>
    /// Renvoie la prochaine direction à prendre sur un chemin unique sans intersection en fonction de la direction d’arrivée.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="from"></param>
    /// <returns>Renvoie la prochaine direction à prendre, ou renvoie la valeur de <paramref name="from"/> s'il n'y en a aucune.</returns>
    public static Direction GetNextPath(Cell[,] array, int x, int y, Direction from)
    {
        if (!IsDeadEnd(array, x, y) && !IsIntersection(array, x, y))
        {
            foreach (var direction in GetDirections())
            {
                if (direction == from) continue;

                (int nextY, int nextX) = NextPosition(x, y, direction);
                if (IsValid(array, nextX, nextY)) return direction;
            }
        }
        return from;
    }
}