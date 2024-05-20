using AstraEngine.Core;
using AstraEngine.RaylibRenderer;

using Raylib_cs;

Rectangle2D sq = new()
{
    Position = new Position2D { X = 50, Y = 50 },
    Width = 50,
    Height = 50,
    Color = Color.White,
};
Entity entity = new() { Components = [sq] };
WindowedGame game = new();

entity.Parent = game.Root;

Engine.Run(game);