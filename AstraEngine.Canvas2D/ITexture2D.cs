namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a 2D texture of a sprite
/// </summary>
public interface ITexture2D
{
    /// <summary>Loads an image into this texture</summary>
    /// <param name="filePath">Path to image to be loaded</param>
    public void LoadTexture(string filePath);
}