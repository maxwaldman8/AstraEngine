using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;

namespace AstraEngine.Simple2D;

public abstract class Drawable : Component
{
    [AllowNull]
    public Position2D Position { get; set; }
    public override void Initialize()
    {
        if (Entity?.GetComponent<Position2D>() is Position2D position)
        {
            Position = position;
        }
        else
        {
            Position ??= new Position2D();
            Entity?.AttachComponent(Position);
        }
    }
    public abstract void Draw(IRenderer2D renderer);
}