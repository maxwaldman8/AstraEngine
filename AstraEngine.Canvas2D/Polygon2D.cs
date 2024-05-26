namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class Polygon2D : Drawable
{

    public int Sides { get; set; }

    public float Radius { get; set; }

    public float Rotation { get; set; }

    /// <summary>The color of this polygon</summary>
    public Color Color { get; set; }

    /// <summary>Draws this polygon using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawPoly(this.Position, Sides, Radius, Rotation, Color);
    }
}