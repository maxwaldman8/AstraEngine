using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

using System.Numerics;

namespace AstraEngine.Examples.PlayerMovement;

public static class PlayerMovementExample
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
        Vector2 top = new(0, 5);
        Vector2 bottomLeft = new(-20, 50);
        Vector2 bottomRight = new(20, 50);
        Entity player = new();
        // The player is a white triangle
        player.AttachComponent(new Triangle2D { Top = top, BottomLeft = bottomLeft, BottomRight = bottomRight, Color = Color.White});
        // The player starts at position 50, 50
        player.AttachComponent(new Position2D { X = 50, Y = 50 });
        // The player can be controlled using the arrow keys
        player.AttachComponent(new MovementController());
        return player;
    }
}