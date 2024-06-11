namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Sprite that can be drawn in 2D space
/// </summary>
public class Sprite2D : Drawable
{
    /// <summary>The file path to this sprite</summary>
    public string FileName { get; set; } = String.Empty;
    /// <summary>The tint color of this sprite</summary>
    public Color Tint { get; set; }

    /// <summary>Draws this sprite using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawSprite(FileName, Position, Tint);
    }
}