using AstraEngine.Canvas2D;

namespace AstraEngine.Examples.PlayerMovement;

public class PolygonDrawer() : Drawable
{
    public override void Draw(ICanvas2D renderer)
    {
        Position2D origin = new()
        {X = 100, Y = 100};

        List<Position2D> vertices = new()
        {};

        Color color = default;

        renderer.DrawPoly(origin, vertices, color);
    }
}