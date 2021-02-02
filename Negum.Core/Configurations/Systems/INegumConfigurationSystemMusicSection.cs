namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// Music section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationSystemMusicSection : INegumConfigurationSection
    {
        /// <summary>
        /// Music to play at title screen.
        /// </summary>
        INegumConfigurationMusicDefinitionSection Title { get; }

        /// <summary>
        /// Music to play at char select screen.
        /// </summary>
        INegumConfigurationMusicDefinitionSection Select { get; }

        /// <summary>
        /// Music to play at versus screen.
        /// </summary>
        INegumConfigurationMusicDefinitionSection Vs { get; }

        /// <summary>
        /// Music to play at victory screen.
        /// </summary>
        INegumConfigurationMusicDefinitionSection Victory { get; }
    }
}