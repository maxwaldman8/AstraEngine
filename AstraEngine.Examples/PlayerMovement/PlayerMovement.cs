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
        Entity circle = new();
        circle.AttachComponent(new Circle2D { Radius = 20, Color = Color.White });
        circle.AttachComponent(new Position2D { X = 100, Y = 100 });
        circle.AttachComponent(new MovementController());
        return circle;
    }
}