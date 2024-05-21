using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;

using Raylib_cs;

namespace AstraEngine.Simple2D;

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
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            _position2D.X -= Speed * delta;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            _position2D.X += Speed * delta;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            _position2D.Y -= Speed * delta;
        }
        if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            _position2D.Y += Speed * delta;
        }
    }
}