namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Pixel that can be drawn in 2D space
/// </summary>
public class Pixel2D : Drawable
{
    public Color Color { get; set; }
    /// <summary>Draws this pixel using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawPixel(this.Position, Color);
    }
}