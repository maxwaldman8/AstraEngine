using Raylib_CsLo;

namespace AstraEngine.InputSystem;

/// <summary>An implementation of the InputSystem using Raylib-cs</summary>
public sealed class Input : IInputSystem
{
    /// <summary>A shared instance of the input system.</summary>
    public static Input Shared { get; } = new();
    /// <inheritdoc/>
    public bool IsKeyDown(KeyCode key) => Raylib.IsKeyDown(key.AsRayKey());
}