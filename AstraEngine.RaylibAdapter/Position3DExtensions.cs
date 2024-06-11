namespace AstraEngine.View3D;

/// <summary>
/// Extension methods for conversions from <see cref="Position3D"/> to <see cref="System.Numerics.Vector3"/>
/// </summary>
public static class Position3DExtensions
{
    /// <summary>Casts the specified <see cref="Position3D"/> as a <see cref="System.Numerics.Vector3"/></summary>
    public static System.Numerics.Vector3 AsVector3(this Position3D position) => new((float)position.X, (float)position.Y, (float)position.Z);
}