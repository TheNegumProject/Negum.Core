using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// Parser made specially for core configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationParser : IParser<IEnumerable<string>, IConfigurationDefinition>
    {
    }
}