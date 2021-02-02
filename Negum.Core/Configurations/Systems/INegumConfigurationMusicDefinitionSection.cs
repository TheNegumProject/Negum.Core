namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationMusicDefinitionSection : INegumConfigurationSection
    {
        /// <summary>
        /// Name of the file.
        /// </summary>
        string Filename { get; }

        /// <summary>
        /// Volume scaling factor in percent.
        /// 100 is default.
        /// </summary>
        int Volume { get; }

        /// <summary>
        /// Set to true to allow looping.
        /// Set to false to prevent looping.
        /// </summary>
        bool Loop { get; }

        int LoopStart { get; }
        
        int LoopEnd { get; }
    }
}