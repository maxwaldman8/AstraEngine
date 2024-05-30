using AstraEngine.Canvas2D;

namespace AstraEngine.Examples.PlayerMovement;

public class PolygonDrawer() : Drawable
{
    public override void Draw(ICanvas2D renderer)
    {
        Position2D origin = new(){X = 100, Y = 100};
        List<Position2D> vertices = new(){};

        renderer.DrawPoly(origin, vertices, Color.Red);

        origin = new(){X = 200, Y = 200};
        renderer.DrawPoly(origin, vertices, Color.Blue);


        origin = new(){X = 300, Y = 300};
        renderer.DrawPoly(origin, vertices, Color.Green);
    }
}