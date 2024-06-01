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

        Entity test1 = CreateCollisionEntity(0, 0);
        Entity test2 = CreateCollisionEntity(7, 7);

        
        game.Root.AddChild(test1);
        game.Root.AddChild(test2);

        test1.GetComponent<BoxCollider2D>().CheckCollisions(test2.GetComponent<BoxCollider2D>());

        // Run the game
        Engine.Run(game);
    }

    private static Entity CreateCollisionEntity(int x1, int y1)
    {
        // Entity player = new();
        // // The player is a white rectangle
        // player.AttachComponent(new BoxCollider2D() { TopLeft = new Position2D() {X = x1, Y = y1}, BottomRight = new Position2D() { X = x2, Y = y2 }});
        // // The player starts at position 50, 50
        // return player;
        Entity player = new();
        player.AttachComponent(new Position2D { X = x1, Y = y1 });
        Rectangle2D rectangle2D = new Rectangle2D() { Width = 50, Height = 50, Color = Color.White, };
        player.AttachComponent(new BoxCollider2D() { Box = rectangle2D });
        player.AttachComponent(rectangle2D);
        return player;
    }
}