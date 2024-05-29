using System.Numerics;

namespace AstraEngine.Canvas2D;

/// <summary>A <see cref="ICanvas2D"/> provides methods for drawing in 2D space.</summary>
public interface ICanvas2D
{
    /// <summary>This method is called at the start of a render frame.</summary>
    void BeginDrawing();
    /// <summary>Clears the canvas with the specified color</summary>
    /// <param name="color">The color to fill the canvas</param>
    void Clear(Color color);
    /// <summary>
    /// Draws a rectangle
    /// </summary>
    /// <param name="topLeft">The top left corner of the rectangle</param>
    /// <param name="width">The width of the rectangle</param>
    /// <param name="height">The height of the rectangle</param>
    /// <param name="color">The color of the rectangle</param>
    void DrawRectangle(Position2D topLeft, double width, double height, Color color);
    /// <summary>
    /// Draws a triangle
    /// </summary>
    /// <param name="position">The offset for the triangle</param>
    /// <param name="top">The top point of the triangle</param>
    /// <param name="bottomLeft">The lower left point of the triangle</param>
    /// <param name="bottomRight">The lower right point of the triangle</param>
    /// <param name="color">The color of the triangle</param>
    void DrawTriangle(Vector2 top, Vector2 bottomLeft, Vector2 bottomRight, Color color, Position2D position);
    /// <summary>
    /// Draws a decagon (circle)
    /// </summary>
    /// <param name="position">The center position of the decagon</param>
    /// <param name="radius">The radius of the decagon</param>
    /// <param name="color">The color of the decagon</param>
    void DrawCircle(Position2D position, float radius, Color color);
    /// <summary>This method is called at the end of a render frame.</summary>
    void EndDrawing();
}