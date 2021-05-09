using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Managers;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Data;
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
        protected virtual async Task<IStoryboard> ReadStoryboardAsync(string dirName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }

            var reader = NegumContainer.Resolve<IFilePathReader>();

            var defFilePath = reader.FindFile(dirName, fileName);
            var storyboard = new Storyboard();

            storyboard.Manager = await this.ReadManagerAsync<IStoryboardManager>(defFilePath);
            storyboard.Animation = await this.ReadManagerAsync<IAnimationManager, IAnimationReader>(defFilePath);
            storyboard.Sprite = await reader.GetSpriteAsync(dirName, storyboard.Manager.SceneDef.SpriteFile);

            return storyboard;
        }

        protected virtual IEnumerable<FileInfo> GetFiles(IEngine engine, string subdirectoryName) =>
            this.GetDirectory(engine, subdirectoryName).GetFiles();

        protected virtual DirectoryInfo GetDirectory(IEngine engine, string subdirectoryName)
        {
            var rootDir = new DirectoryInfo(engine.Path);

            if (string.IsNullOrWhiteSpace(subdirectoryName))
            {
                return rootDir;
            }

            var subDir = rootDir
                             .GetDirectories()
                             .FirstOrDefault(dir => dir.Name.ToLower().Equals(subdirectoryName.ToLower()))
                         ?? throw new DirectoryNotFoundException($"Cannot find directory \"{subdirectoryName}\" in path \"{rootDir.FullName}\"");

            return subDir;
        }

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

        protected virtual async Task<TManager> ReadManagerAsync<TManager, TReader>(FileInfo file)
            where TManager : IManager
            where TReader : IConfigurationReader =>
            await this.ReadManagerAsync<TManager, TReader>(file.FullName);

        protected virtual async Task<TManager> ReadManagerAsync<TManager>(string path)
            where TManager : IManager =>
            await this.ReadManagerAsync<TManager, IConfigurationWithSubsectionReader>(path);

        protected virtual async Task<TManager> ReadManagerAsync<TManager, TReader>(string path)
            where TManager : IManager
            where TReader : IConfigurationReader
        {
            var reader = NegumContainer.Resolve<TReader>();
            var configuration = await reader.ReadAsync(path);

            return (TManager) NegumContainer.Resolve<TManager>().UseConfiguration(configuration);
        }

        protected virtual async Task<TManager> FindManagerAsync<TManager>(string dirName, string filePath)
            where TManager : IManager
        {
            var reader = NegumContainer.Resolve<IFilePathReader>();

            var file = reader.FindFile(dirName, filePath);
            var manager = await this.ReadManagerAsync<TManager>(file);

            return manager;
        }
    }
}