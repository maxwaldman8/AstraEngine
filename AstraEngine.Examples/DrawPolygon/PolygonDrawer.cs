using AstraEngine.Canvas2D;

namespace AstraEngine.Examples.PlayerMovement;

public class PolygonDrawer() : Drawable
{
    public override void Draw(ICanvas2D renderer)
    {
        Position2D origin = null;

        List<Position2D> vertices = null;

        Color color = default;

        renderer.DrawPoly(origin, vertices, color);
    }
}