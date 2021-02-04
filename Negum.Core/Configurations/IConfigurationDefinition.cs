using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Describes a configuration with multiple configuration sections.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationDefinition
    {
        /// <summary>
        /// Returns section from the specified key.
        /// </summary>
        /// <param name="sectionName"></param>
        IConfigurationSection this[string sectionName] { get; }
        
        /// <summary>
        /// Sections available in the current configuration.
        ///
        /// Key - Name of the section.
        /// Value - Section object.
        /// </summary>
        IDictionary<string, IConfigurationSection> Sections { get; }
    }
}