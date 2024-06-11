using AstraEngine.Canvas2D;

namespace AstraEngine.View3D;

/// <summary>
/// Represents a Box that can be drawn in 3D space
/// </summary>
public class Box3D : Drawable3D
{
    /// <summary>The width of this box</summary>
    public double Width { get; set; }
    /// <summary>The height of this box</summary>
    public double Height { get; set; }
    /// <summary>The length of this box</summary>
    public double Length { get; set; }
    /// <summary>The color of this box</summary>
    public Color Color { get; set; }
    /// <summary>Draws this box using the specified camera</summary>
    /// <param name="camera"></param>
    public override void Draw(ICamera3D camera)
    {
        camera.DrawBox(Position, Width, Height, Length, Color);
    }
}