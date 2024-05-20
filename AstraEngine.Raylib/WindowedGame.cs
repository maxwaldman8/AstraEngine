using AstraEngine.Core;

using Raylib_cs;
namespace AstraEngine.RaylibRenderer;

public sealed class WindowedGame : IGame
{
    public int Width { get; init; } = 640;
    public int Height { get; init; } = 480;
    public string Title { get; init; } = "Untitled Game";
    public Entity Root { get; } = new Entity() { Components = [new View()] };
    public bool IsRunning => !Raylib.WindowShouldClose();
    public double CurrentTime => Raylib.GetTime();
    public void Initialize()
    {
        Raylib.InitWindow(Width, Height, Title);
    }
}