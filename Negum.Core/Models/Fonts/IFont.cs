using Negum.Core.Managers.Types;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Models.Fonts
{
    /// <summary>
    /// Represents single Font read from appropriate directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFont : IFileReadable
    {
        /// <summary>
        /// Returns true if the current font was read from FNT file.
        /// </summary>
        bool IsRaw { get; }

        /// <summary>
        /// Manager used to read this Font.
        /// Could be null if IsRaw == true.
        /// </summary>
        IFontManager Manager { get; }

        /// <summary>
        /// Sprite which contains information about glyphs used in the file.
        /// Could be null if IsRaw == true OR if the file is TTF.
        /// </summary>
        ISprite Sprite { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Font : FileReadable, IFont
    {
        public bool IsRaw { get; internal set; }
        public IFontManager Manager { get; internal set; }
        public ISprite Sprite { get; internal set; }
    }
}