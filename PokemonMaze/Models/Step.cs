namespace PokemonMaze.Models;

public class Step
{
    public (int y, int x) Position { get; set; }
    public Step? Previous { get; set; }
    public int Distance { get; set; }

    public override string ToString()
    {
        return $"{this.Distance} moves -> {GetPositionString(this.Position)} from {GetPositionString(this.Previous?.Position)}";
    }

    public static string GetPositionString((int y, int x)? position)
    {
        return $"({position?.y},{position?.x})";
    } 
}