namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Rectangle that can be drawn in 2D space
/// </summary>
public class DrawText2d : Drawable
{
    /// <summary>The color of this rectangle</summary>
    public Color Color { get; set; }
    /// <summary>The up and down position of the text</summary>
    public int PosY { get; set; }
    /// <summary>The left and right position of the text</summary>

    public int PosX { get; set; }
    /// <summary>The font size of the texrt</summary>

    public double Fsize { get; set; }
    /// <summary>This string is what the text is</summary>
    public string Todraw { get; set; }
    /// <summary>Draws this rectangle using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.Drawtext(new Position2D { X = PosX, Y = PosY }, Fsize, Color, Todraw);
    }
}
