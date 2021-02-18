using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents abstract definition of a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationSection<out TEntry> : IEnumerable<TEntry>
        where TEntry : INegumConfigurationSectionEntry
    {
        /// <summary>
        /// Allows for easy accessing entries.
        /// </summary>
        /// <param name="key"></param>
        TEntry this[string key] { get; }
        
        /// <summary>
        /// Name of the current section.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Collection of attributes of the section.
        /// Defined after the section name in single line.
        /// </summary>
        IEnumerable<string> Attributes { get; }
    }
}