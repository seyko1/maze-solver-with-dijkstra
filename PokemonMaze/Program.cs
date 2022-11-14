using System;
using PokemonMaze;
using static PokemonMaze.Exercises.Exercice3;
using static PokemonMaze.Exercises.Exercice5;
using static PokemonMaze.Exercises.Exercice8;

var maze = MazeInitializer.Init(10, 10); 

PrintMaze(maze);

(bool[,] array, int moves) resolved = ResolveMaze(maze);

Console.WriteLine($"Moves : {resolved.moves}");
PrintMap(resolved.array);