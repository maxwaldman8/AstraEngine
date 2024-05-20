using System.Diagnostics.CodeAnalysis;

namespace AstraEngine.Core;

/// <summary>
/// An <see cref="Component"/> is a modular piece of data that represents a single aspect of an entity's behavior or
/// characteristics, such as position, health, or rendering properties. 
/// </summary>
public abstract class Component
{
    /// <summary>
    /// The <see cref="Entity"/> that this <see cref="Component"/> is attached to.
    /// </summary>
    [AllowNull]
    public Entity Entity { get; internal set; }

    /// <summary>
    /// Executed when this component enters the game for the first time
    /// </summary>
    public virtual void Initialize()
    {

    }

    /// <summary>
    /// Apply's a time based changes
    /// </summary>
    /// <param name="delta">The amount of time in seconds that has passed</param>
    public virtual void Tick(double delta)
    {

    }
}