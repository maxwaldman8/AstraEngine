using AstraEngine.Core;

namespace AstraEngine.View3D;

/// <summary>
/// Represents a location in 3D space
/// </summary>
public sealed class Position3D : Component
{
    /// <summary>Position along the X axis</summary>
    public double X { get; set; }
    /// <summary>Position along the Y axis</summary>
    public double Y { get; set; }
    /// <summary>Position along the Z axis</summary>
    public double Z { get; set; }
}