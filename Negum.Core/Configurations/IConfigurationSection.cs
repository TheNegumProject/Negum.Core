using System.Collections;
using System.Collections.Generic;

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
        /// Name of the current section.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Collection of attributes of the section.
        /// Defined after the section name in single line.
        /// </summary>
        IEnumerable<IConfigurationSectionEntry> Attributes { get; }

        /// <summary>
        /// Collection of inner sections.
        /// Only few files are using it.
        /// </summary>
        IEnumerable<IConfigurationSection> Subsections { get; }

        /// <summary>
        /// Adds new subsection to the current section.
        /// </summary>
        /// <param name="section"></param>
        void AddSubsection(IConfigurationSection section);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationSection : IConfigurationSection
    {
        public string Name { get; internal set; }

        public IEnumerable<IConfigurationSectionEntry> Attributes { get; internal set; } =
            new List<IConfigurationSectionEntry>();

        public IEnumerable<IConfigurationSection> Subsections { get; internal set; } =
            new List<IConfigurationSection>();

        public ICollection<IConfigurationSectionEntry> Entries { get; internal set; } =
            new List<IConfigurationSectionEntry>();

        public void AddSubsection(IConfigurationSection section) =>
            ((List<IConfigurationSection>) this.Subsections).Add(section);

        public IEnumerator<IConfigurationSectionEntry> GetEnumerator() =>
            this.Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}