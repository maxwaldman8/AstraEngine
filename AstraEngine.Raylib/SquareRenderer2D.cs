using Raylib_cs;

namespace AstraEngine.RaylibRenderer;

public class Rectangle2D : Renderer2D
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Color Color { get; set; }
    public override void Render()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height, Color);
    }
}