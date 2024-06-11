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
    /// <summary> the font to use. Default Roboto. </summary>
    private static Font s_font = LoadFontAgain();

    private static Font LoadFontAgain()
    {
        return Raylib.LoadFont(Path.Combine(Environment.CurrentDirectory, "resources", "Roboto-Regular.ttf"));
    }

    /// <inheritdoc/>
    public void Clear(Color backgroundColor) => Raylib.ClearBackground(backgroundColor.ToRayColor());

    /// <summary>
    /// Represents a Line that can be drawn in 2D space
    /// </summary>
    public void DrawLine(Position2D start, Position2D end, double width, Color color)
    {
        Raylib.DrawLine((int)start.X, (int)start.Y, (int)end.X, (int)end.Y, color.ToRayColor());
    }

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
    ///<inheritdoc/>
    public void Drawtext(Position2D topleft, double fsize, Color color, string text)
    {

        // produces a lot of errors
        Vector2 vector = new((float)topleft.X, (float)topleft.Y);
        Raylib_cs.Raylib.DrawTextCodepoint(s_font, Enum.Parse(typeof(Alphabet), text).GetHashCode(), vector, (int)fsize, color.ToRayColor());
    }

    /// <inheritdoc/>
    public void EndDrawing() => Raylib.EndDrawing();
}