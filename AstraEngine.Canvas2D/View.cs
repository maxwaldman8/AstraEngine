using AstraEngine.Core;
namespace AstraEngine.Simple2D;

/// <summary>
/// Represents a 2D view port that draws itself and all children each tick. Children components
/// should not call <see cref="ICanvas2D.BeginDrawing"/> or <see cref="ICanvas2D.EndDrawing"/>.
/// </summary>
public class View : Component
{
    /// <summary>The target canvas</summary>
    public required ICanvas2D Canvas { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Color BackgroundColor { get; set; } = Color.Black;

    /// <summary>
    /// Clears the canvas with the specified <see cref="BackgroundColor"/> then draws all children <see
    /// cref="Drawable"/> components.
    /// </summary>
    /// <param name="delta"></param>
    public override void Tick(double delta)
    {
        if (Entity is null) { return; }
        Canvas.BeginDrawing();
        Canvas.Clear(BackgroundColor);
        foreach (var drawable in Entity.GetComponentsInChildren<Drawable>())
        {
            drawable.Draw(Canvas);
        }
        Canvas.EndDrawing();
    }
}