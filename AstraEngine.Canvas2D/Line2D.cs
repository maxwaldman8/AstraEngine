using AstraEngine.Canvas2D;

namespace AstraEngine.DrawLine;
/// <summary>
/// Represents a Line that can be drawn in 2D space
/// </summary>
public class Line2D : Drawable
{
    /// <summary>The width of this line</summary>
    public double Width { get; set; }
    /// <summary>The color of this line</summary>
    public Color Color { get; set; }
    /// <summary>The start of this line</summary>
    public required Position2D Start { get; set; }
    /// <summary>The End of this line</summary>
    public required Position2D End { get; set; }
    /// <inheritdoc/>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawLine(Start, End, Width, Color);
    }
}