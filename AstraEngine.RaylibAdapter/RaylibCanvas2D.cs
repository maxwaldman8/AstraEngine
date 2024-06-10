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
    /// <summary> the font to use. Default Roboto. </summary>
    private static Font s_font = LoadFontAgain();

    private static Font LoadFontAgain()
    {
        return Raylib.LoadFont(Path.Combine(Environment.CurrentDirectory, "resources", "Roboto-Regular.ttf"));
    }

    /// <inheritdoc/>
    public void Clear(Color backgroundColor) => Raylib.ClearBackground(backgroundColor.ToRayColor());
    /// <inheritdoc/>
    public void DrawRectangle(Position2D topLeft, double width, double height, Color color)
    {
        Raylib.DrawRectangleRec(new Rectangle((float)topLeft.X, (float)topLeft.Y, (float)width, (float)height), color.ToRayColor());
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