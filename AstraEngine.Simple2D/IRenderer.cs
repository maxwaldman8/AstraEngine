namespace AstraEngine.Simple2D;

public interface IRenderer2D
{
    void BeginDrawing();
    void ClearBackground(Color backgroundColor);
    void DrawRectangle(double x, double y, double width, double height, Color color);
    void EndDrawing();
}