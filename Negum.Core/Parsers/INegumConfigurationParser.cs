using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// Parser used to handle core configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationParser : IParser<IEnumerable<string>, INegumConfiguration>
    {
    }
}