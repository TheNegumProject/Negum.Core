using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers;
using Negum.Core.Readers;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Contains common code for all loaders.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class AbstractLoader
    {
        protected virtual async Task<IEnumerable<TOutput>> LoadMultipleAsync<TOutput, TEntry>(
            IEnumerable<TEntry> sources,
            Func<TEntry, Task<TOutput>> parseFunction)
        {
            var tasks = sources
                .Select(parseFunction)
                .ToArray();

            Task.WaitAll(tasks);

            var entities = tasks
                .Select(task => task.Result)
                .ToList();

            return entities;
        }
        
        protected virtual async Task<TManager> ReadManagerAsync<TManager>(FileInfo file, string path)
            where TManager : IManager
        {
            var fullPath = Path.Combine(file.DirectoryName, path);
            return await this.ReadManagerAsync<TManager>(fullPath);
        }

        protected virtual async Task<TManager> ReadManagerAsync<TManager>(FileInfo file)
            where TManager : IManager => 
            await this.ReadManagerAsync<TManager>(file.FullName);

        protected virtual async Task<TManager> ReadManagerAsync<TManager>(string path)
            where TManager : IManager
        {
            var configReader = NegumContainer.Resolve<IConfigurationWithSubsectionReader>();
            var configuration = await configReader.ReadAsync(path);
        
            return (TManager) NegumContainer.Resolve<TManager>().UseConfiguration(configuration);
        }
    }
}