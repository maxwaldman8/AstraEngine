namespace AstraEngine.Canvas2D;

/// <summary>A <see cref="ICanvas2D"/> provides methods for drawing in 2D space.</summary>
public interface ICanvas2D
{
    // public static ICanvas2D 
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
    /// <summary>This method is called at the end of a render frame.</summary>
    void EndDrawing();
}