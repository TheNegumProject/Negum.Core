namespace Negum.Core.Models.Sprites.Png
{
    /// <summary>
    /// PNG chunk header.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngChunkHeader
    {
        /// <summary>
        /// Length of the chunk header.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Name of the chunk.
        /// </summary>
        string Name { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkHeader : ISffPngChunkHeader
    {
        public int Length { get; internal set; }
        public string Name { get; internal set; }
    }
}