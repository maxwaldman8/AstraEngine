using AstraEngine.Core;
using AstraEngine.Simple2D;

Entity player = new();
player.AttachComponent(
    new Rectangle2D()
    {
        Position = new Position2D { X = 50, Y = 50 },
        Width = 50,
        Height = 50,
        Color = Color.White,
    }
);
player.AttachComponent(new PlayerController());

WindowedGame game = new();
game.Root.AddChild(player);

Engine.Run(game);