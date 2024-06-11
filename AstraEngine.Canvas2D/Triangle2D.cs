using System.Numerics;

namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class Triangle2D : Drawable
{
    /// <summary>The top point of this triangle</summary>
    public Vector2 Top { get; set; }
    /// <summary>The bottom left point of this rectangle</summary>
    public Vector2 BottomLeft { get; set; }
    /// <summary>The bottom right point of this triangle</summary>
    public Vector2 BottomRight { get; set; }
    /// <summary>The color of this rectangle</summary>
    public Color Color { get; set; }
    /// <summary>Draws this rectangle using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawTriangle(Top, BottomLeft, BottomRight, Color, this.Position);
    }
}