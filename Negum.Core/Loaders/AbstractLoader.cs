using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}