namespace Negum.Core.Models.Math
{
    /// <summary>
    /// Represents a 2D Point.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPoint
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        int X { get; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        int Y { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Point : IPoint
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}