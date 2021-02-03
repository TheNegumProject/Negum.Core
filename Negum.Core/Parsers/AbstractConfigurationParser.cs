using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// Provides various common methods for parsers.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class AbstractConfigurationParser
    {
        protected async Task<TConfiguration> ParseConfiguration<TConfiguration>(IEnumerable<string> input, Action<TConfiguration> postProcessAction = null!)
            where TConfiguration : IConfigurationDefinition
        {
            var configurationParser = NegumContainer.Resolve<IConfigurationParser>();
            var configDef = await configurationParser.ParseAsync(input);
            var configuration = NegumContainer.Resolve<TConfiguration>();
            configDef.Sections.ToList().ForEach(section => configuration.Sections.Add(section.Key, section.Value));
            postProcessAction?.Invoke(configuration);
            return configuration;
        }
    }
}