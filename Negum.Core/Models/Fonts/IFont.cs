using Negum.Core.Models.Math;

namespace Negum.Core.Models.Fonts
{
    /// <summary>
    /// Represents single Font read from appropriate directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFont
    {
        /// <summary>
        /// Size of font: width, height.
        /// Width is used for spaces.
        /// </summary>
        IPoint Size { get; }

        /// <summary>
        /// Spacing between font glyphs: width, height.
        /// </summary>
        IPoint Spacing { get; }

        /// <summary>
        /// Drawing offset: x, y.
        /// </summary>
        IPoint Offset { get; }

        /// <summary>
        /// Type of font.
        /// I.e.: bitmap, Fixed, etc.
        /// </summary>
        string Type { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Font : IFont
    {
        public IPoint Size { get; internal set; }
        public IPoint Spacing { get; internal set; }
        public IPoint Offset { get; internal set; }
        public string Type { get; internal set; }
    }
}