using System.Numerics;

using Raylib_cs;

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
    /// <inheritdoc/>
    public void DrawTriangle(Vector2 top, Vector2 bottomLeft, Vector2 bottomRight, Color color, Position2D position)
    {
        Vector2 newTop = new(top.X + (float)position.X, top.Y + (float)position.Y);
        Vector2 newLeft = new(bottomLeft.X + (float)position.X, bottomLeft.Y + (float)position.Y);
        Vector2 newRight = new(bottomRight.X + (float)position.X, bottomRight.Y + (float)position.Y);
        Raylib.DrawTriangle(newTop, newLeft, newRight, color.ToRayColor());
    }
    /// <inheritdoc/>
    public void DrawCircle(Position2D position, float radius, Color color)
    {
        int sides = 10;
        float angle = 2 * MathF.PI / sides;
        Vector2[] points = new Vector2[sides];
        for (int i = 0; i < sides; i++)
        {
            float x = (float)position.X + radius * MathF.Cos(i * angle);
            float y = (float)position.Y + radius * MathF.Sin(i * angle);
            points[i] = new Vector2(x, y);
        }
        for (int i = 0; i < sides; i++)
        {
            Vector2 current = points[i];
            Vector2 next = points[(i + 1) % sides];
            Raylib.DrawLineV(current, next, color.ToRayColor());
        }
    }
    /// <inheritdoc/>
    public void EndDrawing() => Raylib.EndDrawing();
}