using System.Diagnostics.CodeAnalysis;

using AstraEngine.Canvas2D;
using AstraEngine.Core;

namespace AstraEngine.View3D;

/// <summary>
/// Represents a 3D view port that draws itself and all children each tick. Children components
/// should not call <see cref="ICamera3D.BeginDrawing"/> or <see cref="ICamera3D.EndDrawing"/>.
/// </summary>
public class View3D : Component
{
    /// <summary>The Position of attached Entity.</summary>
    [AllowNull]
    public Position3D Position { get; private set; }

    /// <summary>The target camera</summary>
    public required ICamera3D Camera { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Color BackgroundColor { get; set; } = Color.Black;

    /// <summary>
    /// Initializes <see cref="Position"/>. If the associated <see cref="Entity"/> has a Position it is used
    /// otherwise, initializes to (0, 0, 0).
    /// </summary>
    public override void Initialize()
    {
        if (Entity.GetComponent<Position3D>() is Position3D position)
        {
            Position = position;
        }
        else
        {
            Position = new Position3D();
            Entity.AttachComponent(Position);
        }
    }

    /// <summary>
    /// Clears the view with the specified <see cref="BackgroundColor"/> then draws all children <see
    /// cref="Drawable3D"/> components.
    /// </summary>
    /// <param name="delta"></param>
    public override void Tick(double delta)
    {
        if (Entity is null) { return; }
        Camera.Position = Position;
        Camera.BeginDrawing();
        Camera.Clear(BackgroundColor);
        foreach (Drawable3D drawable in Entity.GetComponentsInChildren<Drawable3D>())
        {
            drawable.Draw(Camera);
        }
        Camera.EndDrawing();
    }
}