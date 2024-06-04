using Raylib_cs;
using System.Numerics;

namespace AstraEngine.Canvas2D;

/// <summary>
/// An implementation of the <see cref="ICanvas2D"/> that is compatible with Raylib-cs.
/// </summary>
public sealed class RaylibCanvas2D : ICanvas2D
{
    /// <inheritdoc/>
    public void BeginDrawing() => Raylib.BeginDrawing();
    /// <inheritdoc/>
    public void Clear(Color backgroundColor) => Raylib.ClearBackground(backgroundColor.ToRayColor());
    /// <inheritdoc/>
    public void DrawRectangle(Position2D topLeft, double width, double height, Color color)
    {
        Raylib.DrawRectangleRec(new Rectangle((float)topLeft.X, (float)topLeft.Y, (float)width, (float)height), color.ToRayColor());
    }
    
    public void Drawtext(Position2D topleft, double fsize, Color color, string text)
    {
        Vector2 vector = new((float)topleft.X, (float)topleft.Y);
        Raylib_cs.Raylib.DrawTextCodepoint(Raylib.LoadFont("Roboto-Regular.ttf"), 7, vector, (int) fsize, color.ToRayColor());
    }

    /// <inheritdoc/>
    public void EndDrawing() => Raylib.EndDrawing();
}