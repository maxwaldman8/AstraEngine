using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;

namespace AstraEngine.Simple2D;

/// <summary>
/// Represents a component that can be drawn to a screen. An <see cref="Entity"/> that is Drawable is required to have a
/// <see cref="Position2D"/> component. During initialization, if no <see cref="Position2D"/> is found, a default
/// position is attached.
/// </summary>
public abstract class Drawable : Component
{
    /// <summary>The Position of attached Entity.</summary>
    [AllowNull]
    public Position2D Position { get; private set; }

    /// <summary>
    /// Initializes <see cref="Drawable.Position"/>. If the associated <see cref="Entity"/> has a Position it is used
    /// otherwise, initializes to (0, 0).
    /// </summary>
    public override void Initialize()
    {
        if (Entity.GetComponent<Position2D>() is Position2D position)
        {
            Position = position;
        }
        else
        {
            Position = new Position2D();
            Entity.AttachComponent(Position);
        }
    }

    /// <summary>
    /// Renders this <see cref="Drawable"/>. 
    /// </summary>
    /// <param name="renderer">The renderer to use</param>
    public abstract void Draw(ICanvas2D renderer);
}