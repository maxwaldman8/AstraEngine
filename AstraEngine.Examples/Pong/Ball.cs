using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using AstraEngine.Canvas2D;
using AstraEngine.Core;

namespace AstraEngine.Examples.Pong;

public sealed class Ball(Rectangle2D paddle1, Rectangle2D paddle2) : Component
{
    /// <summary>A reference to the ball's position</summary>
    [AllowNull]
    private Position2D _position2D;
    /// <summary>The speed of the ball</summary>
    public double Speed { get; set; } = 25;
    /// <summary>The direction of the ball</summary>
    public Vector2 Direction { get; set; }
    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position2D = Entity.GetComponent<Position2D>();
        Direction = new(-5, 5);
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position2D != null, $"{nameof(Player1Controller)} requires a {nameof(Position2D)}");
    }
    public bool IsColliding(Rectangle2D box1, Rectangle2D box2)
    {
        if (box1.Position.X + box1.Width < box2.Position.X || box2.Position.X + box2.Width < box1.Position.X)
        {
            return false;
        }

        if (box1.Position.Y + box1.Height < box2.Position.Y || box2.Position.Y + box2.Height < box1.Position.Y)
        {
            return false;
        }

        return true;
    }

    public override void Tick(double delta)
    {
        if (IsColliding(paddle1, Entity.GetComponent<Rectangle2D>()!) || IsColliding(paddle2, Entity.GetComponent<Rectangle2D>()!))
        {
            Direction = new Vector2(-Direction.X, -Direction.Y);
        }
        // if (frames % 60 == 0)
        // {
        //     Console.WriteLine("X1: " + (int)(_position2D.X + 25 - paddle1.Position.X));
        //     Console.WriteLine("Y1: " + (int)(_position2D.Y - paddle1.Position.Y));
        //     Console.WriteLine("X2: " + (int)(_position2D.X + 25 - paddle2.Position.X));
        //     Console.WriteLine("Y2: " + (int)(_position2D.Y - paddle2.Position.Y));
        // }
        // frames += 1;
        if (_position2D.Y >= 455 || _position2D.Y <= 0)
        {
            Direction = new Vector2(Direction.X, -Direction.Y);
        }
        if (_position2D.X >= 615)
        {
            paddle2.Entity.GetComponent<ScoreComponent>()!.Score += 1;
            Entity.GetComponent<Position2D>()!.X = 320;
            Entity.GetComponent<Position2D>()!.Y = 240;
            Console.WriteLine("hit right");
        }

        _position2D.X += Direction.X * Speed * delta;
        _position2D.Y += Direction.Y * -1 * Speed * delta;
        paddle2.Entity.GetComponent<Position2D>()!.Y = _position2D.Y - paddle2.Height / 5;
    }
}