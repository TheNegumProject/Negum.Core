using System.Collections.Generic;

namespace Negum.Core.Cleaners
{
    /// <summary>
    /// Cleaner responsible for cleaning up the configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationCleaner : ICleaner<IEnumerable<string>, IEnumerable<string>>
    {
    }
}