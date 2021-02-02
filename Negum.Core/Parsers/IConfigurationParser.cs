using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// General parser used for any configuration file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationParser : IParser<IEnumerable<string>, IConfigurationDefinition>
    {
    }
}