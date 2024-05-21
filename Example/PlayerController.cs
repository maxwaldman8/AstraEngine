using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;
using AstraEngine.InputSystem;

public class PlayerController : Component
{
    [AllowNull]
    private Position2D _position2D;
    public double Speed { get; set; } = 200;
    public override void Initialize()
    {
        base.Initialize();
        _position2D = Entity.GetComponent<Position2D>();
        Debug.Assert(_position2D != null, $"{nameof(PlayerController)} requires a {nameof(Position2D)}");
    }
    public override void Tick(double delta)
    {
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