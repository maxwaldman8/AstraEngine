using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using AstraEngine.Canvas2D;
using AstraEngine.Core;
using AstraEngine.InputSystem;

namespace AstraEngine.Examples.ColorSwapExample;

public sealed class ColorSwapController : Component
{
    /// <summary>A reference to the entity's position</summary>
    [AllowNull]
    private Position2D _position2D;
    [AllowNull]
    private Rectangle2D _rectangle2D;
    /// <summary>The speed of the entity</summary>
    public double Speed { get; set; } = 200;
    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position2D = Entity.GetComponent<Position2D>();
        _rectangle2D = Entity.GetComponent<Rectangle2D>();
        // Assert that the entity has a rectangle 
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position2D != null, $"{nameof(ColorSwapController)} requires a {nameof(Position2D)}");
    }
    public override void Tick(double delta)
    {
        // Check for keys being pressed and move the player
        // based on the speed and amount of time that has passed
        if (Input.Shared.IsKeyDown(KeyCode.One))
        {
            _rectangle2D.Color = Color.Blue;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Two))
        {
            _rectangle2D.Color = Color.Red;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Three))
        {
            _rectangle2D.Color = Color.Green;
        }
    }
}