using Raylib_cs;
using AstraEngine.Simple2D;

using Color = AstraEngine.Simple2D.Color;

namespace AstraEngine.RaylibRenderer;

public class RaylibRenderer2D : IRenderer2D
{
    public void BeginDrawing() => Raylib.BeginDrawing();
    public void ClearBackground(Color backgroundColor) => Raylib.ClearBackground(backgroundColor.ToRayColor());
    public void DrawRectangle(double x, double y, double width, double height, Color color) =>
        Raylib.DrawRectangleRec(new Rectangle((float)x, (float)y, (float)width, (float)height), color.ToRayColor());
    public void EndDrawing() => Raylib.EndDrawing();
}
