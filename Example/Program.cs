using AstraEngine.Core;
using AstraEngine.Canvas2D;
using AstraEngine.Canvas2D.RaylibAdapter;

Entity player = new();
player.AttachComponent(
    new Rectangle2D()
    {
        Width = 50,
        Height = 50,
        Color = Color.White,
    }
);
player.AttachComponent(new Position2D { X = 50, Y = 50 });
player.AttachComponent(new PlayerController());

WindowedGame game = new();
game.Root.AddChild(player);

Engine.Run(game);