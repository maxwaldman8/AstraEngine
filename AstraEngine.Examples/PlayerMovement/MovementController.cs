using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;
using AstraEngine.InputSystem;

namespace AstraEngine.Examples.PlayerMovement;

public sealed class MovementController : Component
{
    /// <summary>A reference to the entity's position</summary>
    [AllowNull]
    private Position2D _position2D;
    /// <summary>The speed of the entity</summary>
    public double Speed { get; set; } = 200;
    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position2D = Entity.GetComponent<Position2D>();
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position2D != null, $"{nameof(MovementController)} requires a {nameof(Position2D)}");
    }
    public override void Tick(double delta)
    {
        // Check for key's being pressed and move the player
        // based on the speed and amount of time that has passed
        if (Input.Shared.IsKeyDown(KeyCode.Left))
        {
            _position2D.X -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Right))
        {
            _position2D.X += Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Up))
        {
            _position2D.Y -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Down))
        {
            _position2D.Y += Speed * delta;
        }
    }
}