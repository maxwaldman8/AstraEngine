namespace AstraEngine.InputSystem;

/// <summary>
/// Extension methods for conversions from KeyCodes to Raylib_cs.KeyboardKey
/// </summary>
public static class KeyCodeExtensions
{
    /// <summary>Casts the specified keycode as a <see cref="Raylib_cs.KeyboardKey"/></summary>
    public static Raylib_cs.KeyboardKey AsRayKey(this KeyCode keyCode) => (Raylib_cs.KeyboardKey)keyCode;
}