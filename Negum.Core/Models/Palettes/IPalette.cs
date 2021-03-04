using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Models.Palettes
{
    /// <summary>
    /// Represents a palette.
    /// Palette is build of a collection of colors.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPalette : IEnumerable<IColor>
    {
        /// <summary>
        /// </summary>
        /// <returns>Copy of a current palette but in reversed order.</returns>
        IPalette Reverse();
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Palette : IPalette
    {
        public Stack<IColor> Colors { get; } = new();

        public IEnumerator<IColor> GetEnumerator() =>
            this.Colors.GetEnumerator();

        public IPalette Reverse()
        {
            var palette = new Palette();

            foreach (var color in this.Colors)
            {
                palette.Colors.Push(color);
            }

            return palette;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}