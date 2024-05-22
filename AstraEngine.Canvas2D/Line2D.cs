using AstraEngine.Canvas2D;

namespace AstraEngine.DrawLine;

public class Line2D : Drawable
{
    public double width { get; set; }

    public Color color { get; set; }

    public Position2D start { get; set; }

    public Position2D end { get; set; }

    public override void Draw(ICanvas2D renderer)
    {
        renderer.DrawLine(start, end, width, color);
    }
}