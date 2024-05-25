using AstraEngine.Core;

namespace AstraEngine.Canvas2D;

/// <summary>
/// Represents a location in 2D space
/// </summary>
public sealed class Position2D : Component
{
    /// <summary>Position along the X axis</summary>
    public double X { get; set; }
    /// <summary>Position along the Y axis</summary>
    public double Y { get; set; }
}