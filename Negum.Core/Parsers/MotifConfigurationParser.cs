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
    public class MotifConfigurationParser : AbstractConfigurationParser, IMotifConfigurationParser
    {
        public async Task<IMotifConfiguration> ParseAsync(IEnumerable<string> input) =>
            await this.ParseConfiguration<IMotifConfiguration>(input);
    }
}