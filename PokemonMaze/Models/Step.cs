namespace PokemonMaze.Models;

public class Step
{
    public (int y, int x) Position { get; set; }
    public Step? Previous { get; set; }
    public int Distance { get; set; }

    /// <summary>
    /// Retourne une chaîne string affichant la position d'un sommet, la distance parcourue pour l'atteindre et la position du sommet précédent. 
    /// </summary>
    /// <returns>La chaîne string correspondante.</returns>
    public override string ToString()
    {
        return $"{this.Distance} moves -> {GetPositionString(this.Position)} from {GetPositionString(this.Previous?.Position)}";
    }

    public static string GetPositionString((int y, int x)? position)
    {
        return $"({position?.y},{position?.x})";
    } 
}