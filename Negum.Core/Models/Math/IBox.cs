namespace Negum.Core.Models.Math;

/// <summary>
/// Represents a 2D Box.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IBox
{
    /// <summary>
    /// In most cases this will be Top-Left.
    /// </summary>
    IPoint Point1 { get; }

    /// <summary>
    /// In most cases this will be Bottom-Right.
    /// </summary>
    IPoint Point2 { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class Box : IBox
{
    public IPoint Point1 { get; }
    public IPoint Point2 { get; }

    public Box(IPoint p1, IPoint p2)
    {
        Point1 = p1;
        Point2 = p2;
    }
}