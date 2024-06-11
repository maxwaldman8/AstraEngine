using AstraEngine.Canvas2D;

using AstraEngine.Canvas2D.RaylibAdapter;

using AstraEngine.Core;


namespace AstraEngine.Examples.PlayerMovement;

public static class PlayerMovementExample
{
    public static void Run()
    {
        WindowedGame game = new();
        game.Root.AddChild(CreateCircle());
        Engine.Run(game);
    }

    private static Entity CreateCircle()
    {
        Entity player = new() { Name = "Player" };
        // The player is a white rectangle
        // player.AttachComponent(new Rectangle2D() { Width = 50, Height = 50, Color = Color.White, });
        player.AttachComponent(new Circle2D { Radius = 20, Color = Color.White });
        // The player starts at position 50, 50
        player.AttachComponent(new Position2D { X = 50, Y = 50 });
        // The player can be controlled using the arrow keys
        player.AttachComponent(new MovementController());
        return player;
    }
}