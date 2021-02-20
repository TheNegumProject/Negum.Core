using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents general definition of a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationSection : IEnumerable<IConfigurationSectionEntry>
    {
        /// <summary>
        /// Allows for easy accessing entries.
        /// </summary>
        /// <param name="key"></param>
        IConfigurationSectionEntry this[string key] { get; }

        /// <summary>
        /// Name of the current section.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Collection of attributes of the section.
        /// Defined after the section name in single line.
        /// </summary>
        IEnumerable<IConfigurationSectionEntry> Attributes { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationSection : IConfigurationSection
    {
        public IConfigurationSectionEntry this[string key] => this.FirstOrDefault(entry => entry.Key.Equals(key));

        public string Name { get; internal set; }

        public IEnumerable<IConfigurationSectionEntry> Attributes { get; internal set; } =
            new List<IConfigurationSectionEntry>();

        public ICollection<IConfigurationSectionEntry> Entries { get; internal set; } =
            new List<IConfigurationSectionEntry>();

        public IEnumerator<IConfigurationSectionEntry> GetEnumerator() =>
            this.Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}