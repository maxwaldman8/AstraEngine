namespace AstraEngine.InputSystem;

/// <summary>
/// Extension methods for conversions from KeyCodes to <see cref="ZeroElectric.Vinculum.KeyboardKey"/>
/// </summary>
public static class KeyCodeExtensions
{
    /// <summary>Casts the specified keycode as a <see cref="ZeroElectric.Vinculum.KeyboardKey"/></summary>
    public static ZeroElectric.Vinculum.KeyboardKey AsRayKey(this KeyCode keyCode) => (ZeroElectric.Vinculum.KeyboardKey)keyCode;
}