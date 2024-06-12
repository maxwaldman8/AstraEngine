using Raylib_cs;

namespace AstraEngine.Canvas2D;

/// <summary>
/// An implementation of the <see cref="ITexture2D"/> that is compatible with Raylib-cs.
/// </summary>
public sealed class RaylibTexture2D : ITexture2D
{
    /// <summary>Cached <see cref="Texture2D"/></summary>
    public Texture2D Texture { get; private set; }

    /// <inheritdoc/>
    public void LoadTexture(string filePath)
    {
        Texture = Raylib.LoadTexture(filePath);
    }
}