using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;

namespace AstraEngine.View3D;

/// <summary>
/// Represents a 3D component that can be drawn to a screen. An <see cref="Entity"/> that is Drawable is required to have a
/// <see cref="Position3D"/> component. During initialization, if no <see cref="Position3D"/> is found, a default
/// position is attached.
/// </summary>
public abstract class Drawable3D : Component
{
    /// <summary>The Position of attached Entity.</summary>
    [AllowNull]
    public Position3D Position { get; private set; }

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
    /// Renders this <see cref="Drawable3D"/>. 
    /// </summary>
    /// <param name="camera">The camera to use</param>
    public abstract void Draw(ICamera3D camera);
}