using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents general definition for configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfiguration : IEnumerable<IConfigurationSection>
    {
        /// <summary>
        /// Returns section from the specified key.
        /// </summary>
        /// <param name="sectionName"></param>
        IConfigurationSection this[string sectionName] { get; }

        /// <summary>
        /// Adds new section to the current configuration.
        /// </summary>
        /// <param name="section"></param>
        void AddSection(IConfigurationSection section);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Configuration : IConfiguration
    {
        public IConfigurationSection this[string sectionName] => this.Sections[sectionName];

        public IDictionary<string, IConfigurationSection> Sections { get; } =
            new Dictionary<string, IConfigurationSection>();

        public void AddSection(IConfigurationSection section) =>
            this.Sections.Add(section.Name, section);

        public IEnumerator<IConfigurationSection> GetEnumerator() =>
            this.Sections.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}