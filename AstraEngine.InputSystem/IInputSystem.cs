namespace AstraEngine.InputSystem;

/// <summary>An InputSystem defines how the user interacts with the program.</summary>
public interface IInputSystem
{
    /// <summary>Check if the specified key is pressed.</summary>
    /// <param name="key">The key to check</param>
    /// <returns>true if the key is currently being held and false otherwise</returns>
    public bool IsKeyDown(KeyCode key);
}
