namespace AstraEngine.Canvas2D;

/// <summary>Extension methods for converting Colors to Raylib.Color</summary>
public static class ColorExtensions
{
    /// <summary>Converts the specified Color to a Raylib.Color</summary>
    public static Raylib_cs.Color ToRayColor(this Color c) => new(c.R, c.G, c.B, c.A);
}