namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class DrawText2d : Drawable
{
    /// <summary>The color of the text</summary>
    public Color Color { get; set; }
    /// <summary>The Y position of the text</summary>
    public int PosY { get; set; }
    /// <summary>The X position of the text</summary>
    public int PosX { get; set; }
    /// <summary>The font size of the text</summary>
    public int FontSize { get; set; }
    /// <summary>The message of the text</summary>
    public string Message { get; set; } = String.Empty;

    /// <summary>Draws this rectangle using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawText(new Position2D { X = PosX, Y = PosY }, FontSize, Message, Color);
    }
}