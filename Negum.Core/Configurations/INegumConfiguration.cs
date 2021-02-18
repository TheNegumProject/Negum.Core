using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents abstract definition for configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfiguration<out TSection, TEntry> : IEnumerable<TSection>
        where TSection : INegumConfigurationSection<TEntry>
        where TEntry : INegumConfigurationSectionEntry
    {
        /// <summary>
        /// Returns section from the specified key.
        /// </summary>
        /// <param name="sectionName"></param>
        TSection this[string sectionName] { get; }

        /// <summary>
        /// </summary>
        /// <returns>Collection of names for registered sections.</returns>
        IEnumerable<string> GetSectionNames();
    }
}