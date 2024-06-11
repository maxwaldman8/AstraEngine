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
    /// Draws a polygon
    /// </summary>
    /// <param name="origin">The first vertex of the polygon</param>
    /// <param name="sides">The number of sides of the polygon</param>
    /// <param name="radius">The radius of the polygon</param>
    /// <param name="rotation">The rotation of the polygon</param>
    /// <param name="color">The color of the polygon</param>
    void DrawPoly(Position2D origin, int sides, float radius, float rotation, Color color);

    /// <summary>
    /// Draws text
    /// </summary>
    /// <param name="location">The location of the text</param>
    /// <param name="message">The message in the text</param>
    /// <param name="color">The color of the text</param>
    void DrawText(Position2D location, String message, Color color);

    /// <summary>
    /// Draws pixel
    /// </summary>
    /// <param name="location">The location of the pixel</param>
    /// <param name="color">The color of the pixel</param>
    void DrawPixel(Position2D location, Color color);

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

    /// <param name="start">The start of the line</param>
    /// <param name="width">The width of the line</param>
    /// <param name="end">The end of the line</param>
    /// <param name="color">The color of the line</param>
    void DrawLine(Position2D start, Position2D end, double width, Color color);

    /// <summary>
    /// Draws a sprite
    /// </summary>
    /// <param name="fileName">The path to the sprite to draw</param>
    /// <param name="topLeft">The top left corner of the sprite</param>
    /// <param name="tint">The tint color of the sprite</param>
    void DrawSprite(string fileName, Position2D topLeft, Color tint);

    /// <summary>This method is called at the end of a render frame.</summary>
    /// <summary>Ends the drawing</summary>
    void EndDrawing();
}