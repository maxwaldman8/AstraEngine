using AstraEngine.Core;
using AstraEngine.RaylibRenderer;

using Raylib_cs;
namespace AstraEngine.Simple2D;

public sealed class WindowedGame : IGame
{
    public int Width { get; init; } = 640;
    public int Height { get; init; } = 480;
    public string Title { get; init; } = "Untitled Game";
    public Entity Root { get; } = new Entity() { Components = [new View() { Renderer = new RaylibRenderer2D() }] };
    public bool IsRunning => !Raylib.WindowShouldClose();
    public double CurrentTime => Raylib.GetTime();
    public void Initialize()
    {
        Raylib.InitWindow(Width, Height, Title);
        Raylib.SetTargetFPS(60);
    }
}