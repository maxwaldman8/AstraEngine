using AstraEngine.Simple2D;

namespace AstraEngine.RaylibRenderer;

public static class ColorExtensions
{
    public static Raylib_cs.Color ToRayColor(this Color c) => new(c.R, c.G, c.B, c.A);
}