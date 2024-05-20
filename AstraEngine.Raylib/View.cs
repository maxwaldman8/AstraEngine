using System.Diagnostics.CodeAnalysis;

using AstraEngine.Core;

using Raylib_cs;

namespace AstraEngine.RaylibRenderer;

public class View : Component
{
    public override void Tick(double delta)
    {
        if (Entity is null) { return; }
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        foreach (var renderer in Entity.GetComponentsInChildren<Renderer2D>())
        {
            renderer.Render();
        }
        Raylib.EndDrawing();
    }
}