using AstraEngine.Canvas2D;
using AstraEngine.Core;

using Raylib_cs;

namespace AstraEngine.Examples.Pong;

public sealed class ScoreComponent : Component
{
    /// <summary>The score.</summary>
    public double Score { get; set; } = 0;
    public override void Tick(double delta)
    {
        if (Score == 0)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number0";
        }
        else if (Score == 1)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number1";
        }
        else if (Score == 2)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number2";
        }

        else if (Score == 3)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number3";
        }

        else if (Score == 4)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number4";
        }
        else if (Score == 5)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number5";
        }
        else if (Score == 6)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number6";
        }
        else if (Score == 7)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number7";
        }

        else if (Score == 8)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number8";
        }

        else if (Score == 9)
        {
            Entity.GetComponent<DrawText2d>()!.Todraw = "Number9";
        }
        else if (Score == 10)
        {
            Raylib.CloseWindow();
        }
    }



}