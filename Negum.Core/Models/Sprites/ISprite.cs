namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents general definition of a single sprite file (.sff)
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISprite
    {
        string Signature { get; }
        string Version { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Sprite : ISprite
    {
        public string Signature { get; internal set; }
        public string Version { get; internal set; }
    }
}