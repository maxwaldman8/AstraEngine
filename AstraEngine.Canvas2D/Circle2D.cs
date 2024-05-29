
namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Decagon (Circle) that can be drawn in 2D space
/// </summary>
public class Circle2D : Drawable
{
    /// <summary>The radius of the decagon</summary>
    public float Radius { get; set; }
    /// <summary>The color of the decagon</summary>
    public Color Color { get; set; }

    /// <summary>Draws this decagon using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawCircle(this.Position, this.Radius, this.Color);
    }
}