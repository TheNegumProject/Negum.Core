using System.Collections.Generic;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Represents a reader used to get data from main configuration file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationReader : IReader<string, IEnumerable<string>>
    {
    }
}