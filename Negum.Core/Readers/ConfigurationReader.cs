using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Negum.Core.Readers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationReader : IConfigurationReader
    {
        public async Task<IEnumerable<string>> ReadAsync(string path) => 
            await File.ReadAllLinesAsync(path);
    }
}