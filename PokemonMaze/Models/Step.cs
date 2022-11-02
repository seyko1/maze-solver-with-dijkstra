namespace PokemonMaze.Models;

public class Step
{
    public (int y, int x) peak { get; set; }
    public (int y, int x)? from { get; set; }
    public int distance { get; set; }

    public Step((int y, int x) peak, (int y, int x)? from, int distance)
    {
        this.peak = peak;
        this.from = from;
        this.distance = distance;
    }

    public override string ToString()
    {
        return $"{this.distance} moves -> {GetPositionString(this.peak)} from {GetPositionString(this.from)}";
    }

    public static string GetPositionString((int y, int x)? position)
    {
        return $"({position?.y},{position?.x})";
    } 
}