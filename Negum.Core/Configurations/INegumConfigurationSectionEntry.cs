namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents abstract definition of an entry in a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationSectionEntry
    {
        /// <summary>
        /// Returns raw content for the current entry.
        /// </summary>
        string Content { get; }
    }
}