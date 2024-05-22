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
    /// <param name="vertices">The vertices of the polygon</param>
    /// <param name="color">The color of the polygon</param>
    void DrawPoly(Position2D origin, List<Position2D> Vertices, Color color);

    /// <summary>
    /// Draws text
    /// </summary>
    /// <param name="location">The location of the text</param>
    /// <param name="message">The message in the text</param>
    /// <param name="color">The color of the text</param>
    void DrawText(Position2D location, String message, Color color);


    /// <summary>This method is called at the end of a render frame.</summary>
    void EndDrawing();
}