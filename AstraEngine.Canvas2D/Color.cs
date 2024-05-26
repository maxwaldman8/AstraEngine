namespace AstraEngine.Canvas2D;

/// <summary>Represents an RGBA color</summary>
public record struct Color(byte R, byte G, byte B, byte A)
{
    public static Color FromHexString(string hex)
    {
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        if (hex.Length == 8)
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            byte a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color(r, g, b, a);
        }
        else if (hex.Length == 6)
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color(r, g, b, 1);
        }
        return new Color(1, 0, 1, 1);
    }

    /// <summary>Black</summary>
    public readonly static Color Black = new(0, 0, 0, 255);
    /// <summary>White</summary>
    public readonly static Color White = new(255, 255, 255, 255);
    /// <summary>Red</summary>
    public readonly static Color Red = new(255, 0, 0, 255);
    /// <summary>Green</summary>
    public readonly static Color Green = new(255, 255, 0, 255);
    /// <summary>Blue</summary>
    public readonly static Color Blue = new(255, 0, 255, 255);
}