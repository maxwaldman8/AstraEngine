using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using AstraEngine.Canvas2D;
using AstraEngine.Core;

namespace AstraEngine.Examples.Pong;

public sealed class Ball : Component
{
    /// <summary>A reference to the ball's position</summary>
    [AllowNull]
    private Position2D _position2D;
    /// <summary>The speed of the ball</summary>
    public double Speed { get; set; } = 20;
    /// <summary>The direction of the ball</summary>
    public Vector2 Direction { get; set; }
    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position2D = Entity.GetComponent<Position2D>();
        Direction = new(10, 5);
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position2D != null, $"{nameof(Player1Controller)} requires a {nameof(Position2D)}");
    }
    public override void Tick(double delta)
    {
        _position2D.X += Direction.X * Speed * delta;
        _position2D.Y += Direction.Y * -1 * Speed * delta;
    }
}