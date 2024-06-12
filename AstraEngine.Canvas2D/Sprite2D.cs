using System.Diagnostics.CodeAnalysis;

namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a Sprite that can be drawn in 2D space
/// </summary>
public abstract class Sprite2D : Drawable
{
    private string _fileName = String.Empty;
    /// <summary>The file path to this sprite</summary>
    public string FileName
    {
        get => _fileName;
        set
        {
            _fileName = value;
            Texture.LoadTexture(value);
        }
    }
    /// <summary>The texture that this sprite uses</summary>
    [AllowNull]
    public ITexture2D Texture { get; set; }
    /// <summary>The tint color of this sprite</summary>
    public Color Tint { get; set; }

    /// <summary>Draws this sprite using the specified renderer</summary>
    /// <param name="renderer"></param>
    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawSprite(Texture, Position, Tint);
    }
}