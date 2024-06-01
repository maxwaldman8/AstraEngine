using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

namespace AstraEngine.Examples.Collisions;

public static class Collisions
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame game = new();
        // Add a player to the game
        game.Root.AddChild(CreateCollisionEntity(0, 0, 5, 5));
        game.Root.AddChild(CreateCollisionEntity(3, 3, 7, 7));
        // Run the game
        Engine.Run(game);
    }

    private static Entity CreateCollisionEntity(int x1, int y1, int x2, int y2)
    {
        Entity player = new();
        // The player is a white rectangle
        player.AttachComponent(new BoxCollider2D() { TopLeft = new Position2D() {X = x1, Y = y1}, BottomRight = new Position2D() {X = x2, Y = y2}});
        // The player starts at position 50, 50
        
        return player;
    }
}