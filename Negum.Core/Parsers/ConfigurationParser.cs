using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationParser : IConfigurationParser
    {
        public async Task<IConfigurationDefinition> ParseAsync(IEnumerable<string> config)
        {
            return await Task.FromResult(Parse(config));
        }

        private static IConfigurationDefinition Parse(IEnumerable<string> config)
        {
            var configuration = NegumContainer.Resolve<IConfigurationDefinition>();
            ProcessInput(config, configuration);
            return configuration;
        }

        private static void ProcessInput(IEnumerable<string> config, IConfigurationDefinition configuration)
        {
            IConfigurationSection section = null;

            foreach (var line in config)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    var sectionName = line
                        .Substring(1, line.Length - 2)
                        .Trim();

                    section = NegumContainer.Resolve<IConfigurationSection>();

                    configuration.Sections.Add(sectionName, section);
                }
                else
                {
                    AddSectionEntry(line, section);
                }
            }
        }

        private static void AddSectionEntry(string line, IConfigurationSection section)
        {
            const string equalsChar = "=";

            var entry = NegumContainer.Resolve<IConfigurationSectionEntry>();

            if (line.Contains(equalsChar))
            {
                var index = line.IndexOf(equalsChar, StringComparison.Ordinal);
                entry.Key = line.Substring(0, index).Trim();
                entry.Value = line.Substring(index + 1, line.Length - index - 1).Trim();
            }
            else
            {
                entry.Key = section.Entries.Count.ToString();
                entry.Value = line;
            }
            
            section.Entries.Add(entry);
        }
    }
}