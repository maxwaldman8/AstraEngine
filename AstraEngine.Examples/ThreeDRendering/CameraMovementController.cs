using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;
using AstraEngine.InputSystem;
using AstraEngine.View3D;

namespace AstraEngine.Examples.ThreeDRendering;

public sealed class CameraMovementController : Component
{
    /// <summary>A reference to the camera's position</summary>
    [AllowNull]
    private Position3D _position3D;
    /// <summary>The speed of the camera</summary>
    public double Speed { get; set; } = 200;

    public override void Initialize()
    {
        base.Initialize();
        // Cache the entity's position
        _position3D = Entity.GetComponent<Position3D>();
        // Assert that the entity had a position (Debug.Assert is removed during a production release)
        Debug.Assert(_position3D != null, $"{nameof(CameraMovementController)} requires a {nameof(Position3D)}");
    }
    public override void Tick(double delta)
    {
        // Check for keys being pressed and move the camera
        // based on the speed and amount of time that has passed
        if (Input.Shared.IsKeyDown(KeyCode.Right))
        {
            _position3D.X -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Left))
        {
            _position3D.X += Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Space))
        {
            _position3D.Y += Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.LeftShift))
        {
            _position3D.Y -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Down))
        {
            _position3D.Z -= Speed * delta;
        }
        if (Input.Shared.IsKeyDown(KeyCode.Up))
        {
            _position3D.Z += Speed * delta;
        }

        // Update camera target to keep rotation constant
        Entity.GetComponent<View3D.View3D>()!.Camera.Target = new() { X = _position3D.X, Y = _position3D.Y, Z = _position3D.Z + 1 };
    }
}