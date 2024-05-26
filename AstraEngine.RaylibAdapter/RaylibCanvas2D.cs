﻿using System.Numerics;

using Raylib_cs;

namespace AstraEngine.Canvas2D;

/// <summary>
/// An implementation of the <see cref="ICanvas2D"/> that is compatible with Raylib-cs.
/// </summary>
public sealed class RaylibCanvas2D : ICanvas2D
{
    /// <inheritdoc/>
    public void BeginDrawing() => Raylib.BeginDrawing();
    /// <inheritdoc/>
    public void Clear(Color backgroundColor) => Raylib.ClearBackground(backgroundColor.ToRayColor());

    public void DrawPoly(Position2D origin, int sides, float radius, float rotation, Color color)
    {
        Vector2 center = new Vector2((float)origin.X, (float)origin.Y);
        Raylib.DrawPoly(center, sides, radius, rotation, color.ToRayColor());
    }

    /// <inheritdoc/>
    public void DrawRectangle(Position2D topLeft, double width, double height, Color color)
    {
        Raylib.DrawRectangleRec(new Rectangle((float)topLeft.X, (float)topLeft.Y, (float)width, (float)height), color.ToRayColor());
    }

    public void DrawText(Position2D location, string message, Color color)
    {
        Raylib.DrawText(message, (int)location.X, (int)location.Y, 12, color.ToRayColor());
    }

    public void DrawPixel(Position2D location, Color color)
    {
        Raylib.DrawPixel((int)location.X, (int)location.Y, color.ToRayColor());
    }

    /// <inheritdoc/>
    public void EndDrawing() => Raylib.EndDrawing();
}