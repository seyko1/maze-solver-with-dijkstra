# Introduction

Le monde Pokémon est un monde vaste et rempli de mystères. Il arrive aux aventuriers
de perdre leur chemin dans cet environnement, mais heureusement que vous êtes là pour les aider. =)

Grâce à votre sens de l’orientation et votre réflexion, vous devrez
implémenter un algorithme que les aventuriers utiliseront s’ils se perdent. <3

# Objectif

L’objectif du sujet est de résoudre le plus court chemin d'un labyrinthe possèdant une unique entrée et une unique sortie.

Des éléments du décor peuvent être sur le chemin et influenceront ainsi l'avancé vers la sortie.

Le personnage commence sa route par la case de départ et doit arriver à la case d’arrivée.

  Vous devrez implémenter les fonctions demandées, puis identifier le meilleur chemin possible pour sortir l'aventurier en herbe de cette situation
périlleuse.


# Implémentation

## Cellules

Une cellule est une case du labyrinthe pouvant être de différents types :
| Valeur   | Description                                                       |
| -------- | ----------------------------------------------------------------- |
| Cliff    | Falaise ne pouvant être traversée.                                |
| Entrance | Entrée du labyrinthe, point de départ du personnage.              |
| Exit     | Sortie du labyrinthe, le personnage doit l’atteindre pour sortir. |
| Grass    | Herbe glissante faisant avancer le personnage de deux cases au lieu d’une lorsqu'il marche dessus.                                                                 |
| Ground   | Sol, le personnage marche dessus normalement.                     |
| Rock     | Rocher bloquant le passage, il ne peut pas être traversé.         |
| Snow     | Neige très glissante. Quand le personnage marche dessus il ne peut être arrêté que par une autre cellule ou le bord du labyrinthe.                                |

## Exercice 1 - Identification des cases

### 1.1 Cell
Tout d'abord, ajoutez au projet une énumération identifiant les différentes cases du labyrinthe !

### 1.2 ParseCell

Implémentez la fonction ParseCell qui prend en argument un caractère et renvoie la cellule correspondante.

```csharp
static Cell ParseCell(char c);
```

| Caractère | Valeur   |
| :-------: | :------: |
| C         | Cliff    |    
| E         | Entrance | 
| X         | Exit     |     
| H         | Grass    |    
| G         | Ground   |   
| R         | Rock     |     
| S         | Snow     |

### 1.3 PrintCell

Implémentez la fonction PrintCell qui a pour but de faire l’inverse. 
Elle prend en entrée une cellule et retourne le caractère correspondant :

```csharp
static char PrintCell(Cell c);
```

## Exercice 2 - Convertion

### ConvertMazeToCell

Implémentez une fonction permettant de traduire un tableau à deux dimensions
de caractère en tableau à deux dimensions de cellules :

```csharp
static Cell[,] ConvertMazeToCell(char[,] array);
```

## Exercice 3 - Affichage du labyrinthe

### PrintMaze

Implémentez une fonction qui affichera dans la console le tableau à deux
dimensions en entrée de façon lisible (espaces et sauts de ligne) :

```csharp
static void PrintMaze(Cell[,] array);
```

```csharp
PrintMaze(new Cell[,]
{
  { Cell.Entrance, Cell.Snow, Cell.Cliff },
  { Cell.Rock, Cell.Snow, Cell.Ground },
  { Cell.Grass, Cell.Snow, Cell.Exit }
});

// output :
// E S C
// R S G
// H S X
```

## Exercice 4 - Directions

Une direction est l’orientation du déplacement que va subir le personnage. Elle est de quatre types possibles :

* North
* South
* East
* West

### 4.1 Directions

Ajoutez au projet une énumération pour lister les différentes directions.

### 4.2 GetOpositeDirection

Ensuite, implémentez une fonction qui retourne simplement la direction opposée de la direction
que l’on lui donne. Cela risque de nous être utile plus tard.

```csharp
static Direction GetOpositeDirection(Direction d);
```

## Exercice 5 - General Helpers

Implémentez les trois fonctions suivantes :

### 5.1 InitArrayValue

Initialise le contenu d’un tableau à deux dimensions avec la valeur précisé en argument.

```csharp
static void InitArrayValue(bool[,] array, bool b);
```

### 5.2 PrintMap

Affiche le caractère X pour chaque case vrai et . pour chaque case fausse.

```csharp
static void PrintMap(bool[,] array);
```

```csharp
PrintMap(new bool[,]
{
  { true, false, false },
  { true, false, false },
  { true, true, true }
});
// output :
// X . .
// X . .
// X X X
```

### 5.3 FindEntrance

Retourne un tuple représentant la position initiale de l’entrée du labyrinthe.

```csharp
static (int, int) FindEntrance(Cell[,] array);
```

## Exercice 6 - Movement Helpers

Implémentez les fonctions suivantes :

### 6.1 IsBounded

Retourne faux si une coordonnée est en dehors du tableau et vrai si elle est dedans.

```csharp
static bool IsBounded(Cell[,] array, int x, int y);
```

### 6.2 IsWalkable

Renvoie vrai s'il est possible de marcher sur la coordonnée passée en argument
(*on suppose que la position donnée est valide dans le tableau*)

```csharp
static bool IsWalkable(Cell[,] array, int x, int y);
```

### 6.3 IsValid

Retournant vrai si une coordonnée est dans le tableau et que le personnage peut marcher dessus, faux dans le cas contraire.

```csharp
static bool IsValid(Cell[,] array, int x, int y);
```

### 6.4 NextPosition

Renvoie un tuple représentant la prochaine position du personnage en fonction de sa direction.

```csharp
static (int, int) NextPosition(int x, int y, Direction direction);
```

``` csharp
NextPosition(0, 0, Direction.South);
// output : 
// (1, 0)

NextPosition(0, 0, Direction.North);
// output : 
// (0, 0)
```

### 6.5 NextMove

Calcule la position d’arrivée du prochain mouvement du personnage.
(*Attention, le mouvement dépend de la prochaine position mais aussi du type de cellule*)

```csharp
static (int, int) NextMove(Cell[,] array, int x, int y, Direction direction);
```

## Exercice 7 - Decision Helpers

Implémentez les fonctions suivantes :

### 7.1 CountValidPath

Renvoie le nombre de chemin possible à partir d'une position.

```csharp
static int CountValidPath(Cell[,] array, int x, int y);
```

```csharp
CountValidPath(new Cell[,]
{
  {Cell.Ground, Cell.Snow, Cell.Ground},
  {Cell.Rock, Cell.Snow, Cell.Ground},
  {Cell.Grass, Cell.Snow, Cell.Cliff}
}, 1, 1);

// output :
// 3
```

### 7.2 IsDeadEnd

Renvoie vrai si la position indiquée en argument ne possède qu'une unique sortie.
(*On appelle une sortie une direction que le personnage peut prendre*)

```csharp
static bool IsDeadEnd(Cell[,] array, int x, int y);
```

### 7.3 IsIntersection

Renvoie vrai si la position indiquée en argument possède plus de deux sorties, c’est-à-dire une intersection.

```csharp
static bool IsIntersection(Cell[,] array, int x, int y);
```

### 7.4 IsExit

Renvoie vrai si la position indiquée en paramètre est la sortie.

```csharp
static bool IsExit(Cell[,] array, int x, int y);
```

### 7.5 GetNextPath

Renvoie la prochaine direction à prendre sur un chemin unique sans intersection en fonction de la direction d’arrivée.

```csharp
static Direction GetNextPath(Cell[,] array, int x, int y, Direction from);
```

## Exercice 8 - Resolver

Implémentez la fonction finale qui résout le labyrinthe à l'aide des fonctions implémentées dans ce TP et d'autres fonctions intermédiaires selon vos besoins.

### ResolveMaze

Retourne un tuple contenant :
* Un tableau de booléen de même taille que celui des cellules avec vrai pour les cases
où le personnage doit effectuer une action et false pour les autres.
* Un entier indiquant le nombre de déplacements que le personnage doit effectuer avant
d’atteindre la sortie.

Cette implémentation dépend de votre logique et réflexion, sur certaines cartes plusieurs
meilleurs chemins sont possibles, pour d’autres qu’un seul. Dans le cas où il n’y en a
pas, renvoyez un tableau de faux et 0.

```csharp
static (bool[,], int) ResolveMaze(Cell[,] array);
```
