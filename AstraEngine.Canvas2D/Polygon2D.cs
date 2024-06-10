namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class Polygon2D : Drawable
{

    /// <summary>The sides of this polygon</summary>
    public int Sides { get; set; }

    /// <summary>The rotation of this polygon</summary>
    public float Rotation { get; set; }

    /// <summary>The color of this polygon</summary>
    public Color Color { get; set; }

    /// <summary>The verticies of this polygon</summary>
    public required List<Position2D> Verticies { get; set; }

    /// <summary>Draws this polygon using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawPoly(this.Position, Verticies, Color, Rotation);
    }
}