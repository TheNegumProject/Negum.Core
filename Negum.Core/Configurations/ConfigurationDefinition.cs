using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationDefinition : IConfigurationDefinition
    {
        public IConfigurationSection this[string sectionName] => this.Sections[sectionName];

        public IDictionary<string, IConfigurationSection> Sections { get; } =
            new Dictionary<string, IConfigurationSection>();
    }
}