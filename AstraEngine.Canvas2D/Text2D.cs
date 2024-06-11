namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class Text2D : Drawable
{
    /// <summary>The string of text</summary>
    public String Message { get; set; }


    /// <summary>The color of this text</summary>
    public Color Color { get; set; }
    /// <summary>Draws this text using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawText(this.Position, Message, Color);
    }
}