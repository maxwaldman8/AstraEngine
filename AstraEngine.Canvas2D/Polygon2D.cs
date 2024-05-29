namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class Polygon2D : Drawable
{
    /// <summary>The width of this rectangle</summary>
    public List<Position2D> Vertices { get; set; } = [];


    /// <summary>The color of this rectangle</summary>
    public Color Color { get; set; }
    /// <summary>Draws this rectangle using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawPoly(Position, Vertices, Color);
    }
}