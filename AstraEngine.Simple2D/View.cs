using AstraEngine.Core;
namespace AstraEngine.Simple2D;

public class View : Component
{
    public required IRenderer2D Renderer { get; set; }
    public Color BackgroundColor { get; set; } = Color.Black;
    public override void Tick(double delta)
    {
        if (Entity is null) { return; }
        Renderer.BeginDrawing();
        Renderer.ClearBackground(BackgroundColor);
        foreach (var drawable in Entity.GetComponentsInChildren<Drawable>())
        {
            drawable.Draw(Renderer);
        }
        Renderer.EndDrawing();
    }
}