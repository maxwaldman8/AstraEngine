namespace AstraEngine.Simple2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class Rectangle2D : Drawable
{
    /// <summary>The width of this rectangle</summary>
    public double Width { get; set; }
    /// <summary>The height of this rectangle</summary>
    public double Height { get; set; }
    /// <summary>The color of this rectangle</summary>
    public Color Color { get; set; }
    /// <summary>Draws this rectangle using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawRectangle(this.Position, Width, Height, Color);
    }
}