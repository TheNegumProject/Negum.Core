using System.Collections.Generic;
using System.Threading.Tasks;
using Negum.Core.Configurations;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfigurationParser : AbstractConfigurationParser, INegumConfigurationParser
    {
        public async Task<INegumConfiguration> ParseAsync(IEnumerable<string> input) => 
            await this.ParseConfiguration<INegumConfiguration>(input, config =>
            {
                config.IsInitialized = true;
            });
    }
}