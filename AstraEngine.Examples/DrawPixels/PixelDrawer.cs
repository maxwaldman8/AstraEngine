using AstraEngine.Canvas2D;

namespace AstraEngine.Examples.PlayerMovement;

public class PixelDrawer() : Drawable
{
    public override void Draw(ICanvas2D renderer)
    {
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                renderer.DrawPixel(new Position2D() { X = x, Y = y }, new Color((byte)x, (byte)y, (byte)(x + y), 255));
            }
        }
    }
}