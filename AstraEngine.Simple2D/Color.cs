namespace AstraEngine.Simple2D;

public record struct Color(byte R, byte G, byte B, byte A)
{
    public readonly static Color Black = new(0, 0, 0, 255);
    public readonly static Color White = new(255, 255, 255, 255);
    public readonly static Color Red = new(255, 0, 0, 255);
    public readonly static Color Green = new(255, 255, 0, 255);
    public readonly static Color Blue = new(255, 0, 255, 255);
}