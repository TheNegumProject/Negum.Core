using System.Collections.Generic;
using System.Linq;
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
    public class NegumConfigurationParser : INegumConfigurationParser
    {
        public async Task<INegumConfiguration> ParseAsync(IEnumerable<string> input)
        {
            var configurationParser = NegumContainer.Resolve<IConfigurationParser>();
            var config = await configurationParser.ParseAsync(input);
            var negumConfig = NegumContainer.Resolve<INegumConfiguration>();
            config.Sections.ToList().ForEach(section => negumConfig.Sections.Add(section.Key, section.Value));
            negumConfig.IsInitialized = true;
            return negumConfig;
        }
    }
}