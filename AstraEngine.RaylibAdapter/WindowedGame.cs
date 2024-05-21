using AstraEngine.Core;

using Raylib_cs;

namespace AstraEngine.Canvas2D.RaylibAdapter;

/// <summary>
/// Creates a simple game window.
/// </summary>
public sealed class WindowedGame : IGame
{
    /// <summary>Window Width</summary>
    public int Width { get; init; } = 640;
    /// <summary>Window Height</summary>
    public int Height { get; init; } = 480;
    /// <summary>Window Title</summary>
    public string Title { get; init; } = "Untitled Game";
    /// <summary>The Root element which has a <see cref="View"/>.</summary>
    public Entity Root { get; } = new Entity() { Components = [new View() { Canvas = new RaylibCanvas2D() }] };
    /// <summary>
    /// The game is running if the window has not closed
    /// </summary>
    public bool IsRunning => !Raylib.WindowShouldClose();
    /// <inheritdoc/>
    public double CurrentTime => Raylib.GetTime();
    /// <summary>
    /// Opens the window
    /// </summary>
    public void Initialize()
    {
        Raylib.InitWindow(Width, Height, Title);
        Raylib.SetTargetFPS(60);
    }
}