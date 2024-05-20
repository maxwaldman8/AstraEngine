namespace AstraEngine.Core;

/// <summary>
/// The Engine executes the core game loop propagating the amount of time passed between calls to tick.
/// </summary>
public interface IGame
{
    /// <summary> The root component of the game.</summary>
    public Entity Root { get; }
    /// <summary>Returns true if the game is running </summary>
    public bool IsRunning { get; }

    /// <summary>Returns the current time in seconds since the game started </summary>
    public double CurrentTime { get; }

    /// <summary>
    /// Initializes the game. This method is called exactly once before the main game loop.
    /// </summary>
    public void Initialize();
}