using AstraEngine.View3D;
using AstraEngine.View3D.RaylibAdapter;
using AstraEngine.Core;
using AstraEngine.Canvas2D;

namespace AstraEngine.Examples.ThreeDRendering;

public static class ThreeDRenderingExample
{
    public static void Run()
    {
        // Create a Windowed Game
        WindowedGame3D game = new();
        // Add a box to the game
        game.Root.AddChild(CreateBox());
        // The camera is at position 0, 0, -100
        game.Root.AttachComponent(new Position3D() { X = 0, Y = 0, Z = -100 });
        // Add camera movement controller
        game.Root.AttachComponent(new CameraMovementController());
        // Run the game
        Engine.Run(game);
    }

    private static Entity CreateBox()
    {
        Entity box = new() { Name = "Box" };
        // Attach the box component
        box.AttachComponent(new Box3D() { Width = 50, Height = 50, Length = 50, Color = Color.White });
        // The box is at position 0, 0, 0
        box.AttachComponent(new Position3D { X = 0, Y = 0, Z = 0 });
        return box;
    }
}