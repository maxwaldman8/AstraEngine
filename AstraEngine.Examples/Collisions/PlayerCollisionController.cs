using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using AstraEngine.Canvas2D;
using AstraEngine.Core;
using AstraEngine.InputSystem;

namespace AstraEngine.Examples.Collisions;

public sealed class PlayerCollisionController(EnemyController enemy) : Component
{
    /// <summary>A reference to the entity's position</summary>
    [AllowNull]
    private Position2D _position2D;
    private EnemyController _enemy = enemy;
    /// <summary>The speed of the entity</summary>
    public double Speed { get; set; } = 200;
    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position2D = Entity.GetComponent<Position2D>();
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position2D != null, $"{nameof(PlayerCollisionController)} requires a {nameof(Position2D)}");
    }
    public override void Tick(double delta)
    {
        // Check for keys being pressed and move the player
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

        // Entity playerCollider = Collisions.CreateCollisionEntity((int)_position2D.X, (int)_position2D.Y);

        // Check if box is colliding
        if (Entity.GetComponent<BoxCollider2D>()!.CheckCollisions(_enemy.Collider))
        {
            // Do something if they are colliding
            Console.WriteLine("Colliding");
            Entity.GetComponent<Rectangle2D>()!.Color = Color.Green;
            _enemy.Entity.GetComponent<Rectangle2D>()!.Color = Color.Blue;

        }
        else{
            Entity.GetComponent<Rectangle2D>()!.Color = Color.White;
            _enemy.Entity.GetComponent<Rectangle2D>()!.Color = Color.Red;
        }
    }
}
//could create another constructer
public class EnemyController : Component
{
    /// <summary>A reference to the entity's position</summary>
    [AllowNull]
    private Position2D _position2D;
    /// <summary>The speed of the entity</summary>
    public double Speed { get; set; } = 200;
    [AllowNull]
    public BoxCollider2D Collider { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position2D = Entity.GetComponent<Position2D>();
        Collider = Entity.GetComponent<BoxCollider2D>();
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position2D != null, $"{nameof(PlayerCollisionController)} requires a {nameof(Position2D)}");
    }
    public override void Tick(double delta)
    {
        // Check for keys being pressed and move the player
        // based on the speed and amount of time that has passed
        if (Input.Shared.IsKeyDown(KeyCode.A))
        {
            _position2D.X -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.D))
        {
            _position2D.X += Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.W))
        {
            _position2D.Y -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.S))
        {
            _position2D.Y += Speed * delta;
        }
    }
}