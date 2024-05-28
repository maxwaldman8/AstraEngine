using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

namespace AstraEngine.Examples.PlayerMovement;

public static class DrawPixelsExample
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame game = new();
        // Add a player to the game
        game.Root.AddChild(CreatePixelDrawer());
        // Run the game
        Engine.Run(game);
    }

    private static Entity CreatePixelDrawer()
    {
        Entity pixelDrawer = new();
        pixelDrawer.AttachComponent(new PixelDrawer());
        return pixelDrawer;
    }
}