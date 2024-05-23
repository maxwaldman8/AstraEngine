namespace AstraEngine.Core;

/// <summary>
/// Utility methods for the AstraEngine
/// </summary>
public static class Engine
{
    /// <summary>
    /// Runs the specified game.
    /// </summary>
    /// <param name="game"></param>
    public static void Run(IGame game)
    {
        game.Initialize();
        double lastTime = game.CurrentTime;
        while (game.IsRunning)
        {
            double start = game.CurrentTime;
            double delta = start - lastTime;
            game.Root.Tick(delta);
            lastTime = start;
        }
        game.Root.Exit();
        game.OnExit();
    }
}