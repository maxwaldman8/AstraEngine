using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

namespace AstraEngine.Examples.PlayerMovement;

public static class DrawPolygonsExample
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame game = new();
        // Add a player to the game
        game.Root.AddChild(CreatePolygonDrawer());
        // Run the game
        Engine.Run(game);
    }

    private static Entity CreatePolygonDrawer()
    {
        Entity polygonDrawer = new();
        polygonDrawer.AttachComponent(new PolygonDrawer());
        return polygonDrawer;
    }
}