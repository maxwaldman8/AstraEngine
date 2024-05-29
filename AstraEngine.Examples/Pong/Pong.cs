using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

namespace AstraEngine.Examples.Pong;

public static class PongExample
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame game = new();
        // Add player 1 to the game
        game.Root.AddChild(CreatePlayer1());
        // Add player 2 to the game
        game.Root.AddChild(CreatePlayer2());
        // Run the game
        Engine.Run(game);
    }

    private static Entity CreatePlayer1()
    {
        Entity player = new();
        // The player is a white rectangle
        player.AttachComponent(new Rectangle2D() { Width = 25, Height = 125, Color = Color.White, });
        // The player starts at the left
        player.AttachComponent(new Position2D { X = 25, Y = 50 });
        // The player can be controlled
        player.AttachComponent(new Player2Controller());
        return player;
    }
    private static Entity CreatePlayer2()
    {
        Entity player = new();
        // The player is a white rectangle
        player.AttachComponent(new Rectangle2D() { Width = 25, Height = 125, Color = Color.White, });
        // The player starts at the right
        player.AttachComponent(new Position2D { X = 590, Y = 50 });
        // The player can be controlled
        player.AttachComponent(new Player1Controller());
        return player;
    }
}