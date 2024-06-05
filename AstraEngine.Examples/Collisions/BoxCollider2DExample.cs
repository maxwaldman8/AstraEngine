using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;
using AstraEngine.Core;

namespace AstraEngine.Examples.Collisions;

public static class BoxCollider2DExample
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame game = new();
        // Add a player to the game

        Entity enemy = CreateEnemy(50, 50);
        Entity player = CreatePlayer(150, 150, enemy.GetComponent<EnemyController>()!);


        game.Root.AddChild(enemy);
        game.Root.AddChild(player);


        // Run the game
        Engine.Run(game);
    }

    public static Entity CreateEnemy(int x1, int y1)
    {
        // Entity player = new();
        // // The player is a white rectangle
        // player.AttachComponent(new BoxCollider2D() { TopLeft = new Position2D() {X = x1, Y = y1}, BottomRight = new Position2D() { X = x2, Y = y2 }});
        // // The player starts at position 50, 50
        // return player;
        Entity enemy = new();
        enemy.AttachComponent(new Position2D { X = x1, Y = y1 });
        Rectangle2D rectangle2D = new() { Width = 50, Height = 50, Color = Color.Red, };
        enemy.AttachComponent(new BoxCollider2D() { Box = rectangle2D });
        enemy.AttachComponent(rectangle2D);
        enemy.AttachComponent(new EnemyController());
        return enemy;


    }

    public static Entity CreatePlayer(int x1, int y1, EnemyController enemy)
    {
        // Entity player = new();
        // // The player is a white rectangle
        // player.AttachComponent(new BoxCollider2D() { TopLeft = new Position2D() {X = x1, Y = y1}, BottomRight = new Position2D() { X = x2, Y = y2 }});
        // // The player starts at position 50, 50
        // return player;
        Entity player = new();
        player.AttachComponent(new Position2D { X = x1, Y = y1 });
        Rectangle2D rectangle2D = new() { Width = 50, Height = 50, Color = Color.White, };
        player.AttachComponent(new BoxCollider2D() { Box = rectangle2D });
        player.AttachComponent(rectangle2D);
        player.AttachComponent(new PlayerCollisionController(enemy));
        return player;


    }

}