/*
using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

namespace AstraEngine.Examples.DrawingPolygon;

public static class DrawPolygonExample
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame game = new();
        // Add a player to the game
        game.Root.AddChild(CreatePlayer());
        // Run the game
        Engine.Run(game);
    }

    private static Entity CreatePlayer()
    {
        Entity player = new();
        // The player is a white rectangle
        player.AttachComponent(new Polygon2D() { Sides = 3, Radius = 1, Rotation = 0, Color = Color.Red });
        // The player starts at position 50, 50
        player.AttachComponent(new Position2D { X = 50, Y = 50 });

        return player;
    }
}
*/