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
        byte Red { get; }
        byte Green { get; }
        byte Blue { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Color : IColor
    {
        public byte Red { get; internal init; }
        public byte Green { get; internal init; }
        public byte Blue { get; internal init; }
    }
}