namespace AstraEngine.Simple2D;

public class Rectangle2D : Drawable
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Color Color { get; set; }
    public override void Draw(IRenderer2D renderer)
    {
        renderer.DrawRectangle(Position.X, Position.Y, Width, Height, Color);
    }
}