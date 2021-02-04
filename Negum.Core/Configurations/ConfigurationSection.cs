using System;
using System.Collections.Generic;
using System.Linq;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationSection : IConfigurationSection
    {
        public string this[string key]
        {
            get => this.Entries.FirstOrDefault(entry => entry.Key.Equals(key))?.Value;
            set
            {
                var found = this.Entries.FirstOrDefault(entry => entry.Key.Equals(key)) 
                            ?? throw new ArgumentException("Unknown key", nameof(key));
                found.Value = value;
            }
        }

        public string Name { get; set; }

        public ICollection<IConfigurationSectionEntry> Entries { get; } = 
            new List<IConfigurationSectionEntry>();
    }
}