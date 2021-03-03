namespace Negum.Core.Models.Palettes
{
    /// <summary>
    /// Represents a simple color.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IColor
    {
        int Red { get; }
        int Green { get; }
        int Blue { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Color : IColor
    {
        public int Red { get; internal init; }
        public int Green { get; internal init; }
        public int Blue { get; internal init; }
    }
}