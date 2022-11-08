using System.Collections.Generic;
using System.Linq;
using PokemonMaze.Enums;
using PokemonMaze.Models;
using static PokemonMaze.Utils;
using static PokemonMaze.Exercises.Exercice5;
using static PokemonMaze.Exercises.Exercice6;
using static PokemonMaze.Exercises.Exercice7;

namespace PokemonMaze.Exercises;

public static class Exercice8
{
    /// <summary>
    /// Renvoie le plus court chemin d'un tableau à deux dimensions de cellule.
    /// </summary>
    /// <param name="array"></param>
    /// <returns>Un tuple contenant le plus court chemin et la distance parcourue.</returns>
    public static (bool[,], int) ResolveMaze(Cell[,] array)
    {
        var traveled = new List<Step>();
        var toGo = new List<Step>();
        
        (int y, int x) entrance = FindEntrance(array);
        
        toGo.Add(new Step
        {
            Position = (entrance.y, entrance.x),
            Distance = 0
        });

        bool isExit = false;
        while (toGo.Any())
        {
            Step current = toGo.OrderBy(step => step.Distance).First();
            isExit = IsExit(array, current.Position.x, current.Position.y);

            toGo.Remove(current);
            traveled.Add(current);

            if (isExit) break;

            foreach (var direction in GetDirections())
            {
                (int y, int x) nextPosition = NextMove(array, current.Position.x, current.Position.y, direction); 
                
                if (current.Position == nextPosition) continue;
                if (traveled.Any(step => step.Position == nextPosition)) continue;

                var existing = toGo.Find(step => step.Position == nextPosition);

                if (existing is not null)
                {
                    existing.Distance = current.Distance + 1;
                    existing.Previous = current;
                }
                else
                {
                    toGo.Add(new Step
                    {
                        Position = nextPosition,
                        Previous = current,
                        Distance = current.Distance + 1
                    });
                }
            }
        }

        if (!isExit)
        {
            var resolved = new bool[array.GetLength(0), array.GetLength(1)];
            InitArrayValue(resolved, false);
            return (resolved, 0);
        }

        var lastTravel = traveled.Last();
        var totalDistance = lastTravel.Distance;
        var positions = new List<(int y, int x)>();

        while (lastTravel is not null)
        {
            positions.Add(lastTravel.Position);
            lastTravel = lastTravel.Previous;
        }

        return (GetResolved(array, positions), totalDistance);
    }
}