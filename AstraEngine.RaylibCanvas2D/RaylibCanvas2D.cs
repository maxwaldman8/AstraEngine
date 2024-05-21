using AstraEngine.Core;
using AstraEngine.Simple2D;

using Raylib_cs;

using Color = AstraEngine.Simple2D.Color;

namespace AstraEngine.RaylibRenderer;

/// <summary>
/// An implementation of the <see cref="ICanvas2D"/> that is compatible with Raylib-cs.
/// </summary>
public class RaylibCanvas2D : ICanvas2D
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

    /// <inheritdoc/>
    public void EndDrawing() => Raylib.EndDrawing();
}