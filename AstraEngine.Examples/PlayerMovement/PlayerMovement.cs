using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;
using AstraEngine.DrawLine;

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
        Entity player = new();
        // The player is a white rectangle
        // player.AttachComponent(new Rectangle2D() { Width = 50, Height = 50, Color = Color.White, });
        player.AttachComponent(new Line2D() { Start = new Position2D { X = 0, Y = 0 }, End = new Position2D() { X = 50, Y = 50 }, Color = Color.Red });
        // The player starts at position 50, 50
        player.AttachComponent(new Position2D { X = 50, Y = 50 });
        // The player can be controlled using the arrow keys
        player.AttachComponent(new MovementController());
        return player;
    }
}