using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using AstraEngine.Canvas2D;

using Raylib_cs;

namespace AstraEngine.View3D;

/// <summary>
/// An implementation of the <see cref="ICamera3D"/> that is compatible with Raylib-cs.
/// </summary>
public sealed class RaylibCamera3D : ICamera3D
{
    /// <inheritdoc/>
    public float FovY { get; set; } = 45f;

    /// <inheritdoc/>
    [AllowNull]
    public Position3D Position { get; set; }

    /// <inheritdoc/>
    public Position3D Target { get; set; } = new() { X = 0, Y = 0, Z = 0 };

    /// <inheritdoc/>
    public Position3D Up { get; set; } = new() { X = 0, Y = 1, Z = 0 };

    /// <inheritdoc/>
    public bool Orthographic { get; set; } = false;

    internal Camera3D Camera;

    /// <inheritdoc/>
    public void BeginDrawing()
    {
        Camera.FovY = FovY;
        Camera.Position = Position.AsVector3();
        Camera.Target = Target.AsVector3();
        Camera.Up = Up.AsVector3();
        Camera.Projection = Orthographic ? CameraProjection.Orthographic : CameraProjection.Perspective;
        Raylib.BeginDrawing();
        Raylib.BeginMode3D(Camera);
    }
    /// <inheritdoc/>
    public void Clear(Canvas2D.Color backgroundColor) => Raylib.ClearBackground(backgroundColor.ToRayColor());
    /// <inheritdoc/>
    public void DrawBox(Position3D position, double width, double height, double length, Canvas2D.Color color)
    {
        Raylib.DrawCube(new Vector3((float)position.X, (float)position.Y, (float)position.Z), (float)width, (float)height, (float)length, color.ToRayColor());
    }
    /// <inheritdoc/>
    public void EndDrawing()
    {
        Raylib.EndMode3D();
        Raylib.EndDrawing();
    }
}