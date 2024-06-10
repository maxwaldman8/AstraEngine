using System.Diagnostics.CodeAnalysis;

using AstraEngine.Canvas2D;

namespace AstraEngine.View3D;

/// <summary>A <see cref="ICamera3D"/> provides methods for rendering 3D space.</summary>
public interface ICamera3D
{
    /// <summary>The FOV on the Y axis of the camera.</summary>
    public float FovY { get; set; }

    /// <summary>The position of the camera.</summary>
    [AllowNull]
    public Position3D Position { get; set; }

    /// <summary>The target that the camera looks at.</summary>
    public Position3D Target { get; set; }

    /// <summary>The up vector of the camera.</summary>
    public Position3D Up { get; set; }

    /// <summary>Whether or not the camera is orthographic.</summary>
    public bool Orthographic { get; set; }

    /// <summary>This method is called at the start of a render frame.</summary>
    void BeginDrawing();
    /// <summary>Clears the view with the specified color</summary>
    /// <param name="color">The color to fill the view</param>
    void Clear(Color color);
    /// <summary>
    /// Draws a box
    /// </summary>
    /// <param name="position">The position of the box</param>
    /// <param name="width">The width of the box</param>
    /// <param name="height">The height of the box</param>
    /// <param name="length">The length of the box</param>
    /// <param name="color">The color of the box</param>
    void DrawBox(Position3D position, double width, double height, double length, Color color);
    /// <summary>This method is called at the end of a render frame.</summary>
    void EndDrawing();
}