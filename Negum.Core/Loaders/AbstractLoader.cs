using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Exceptions;
using Negum.Core.Extensions;
using Negum.Core.Managers;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Data;
using Negum.Core.Readers;

namespace Negum.Core.Loaders;

/// <summary>
/// Contains common code for all loaders.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public abstract class AbstractLoader
{
    protected virtual async Task<IStoryboard?> ReadStoryboardAsync(string dirName, string? fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return null;
        }

        var reader = NegumContainer.Resolve<IFilePathReader>();

        var defFilePath = reader.FindFile(dirName, fileName);

        var storyboard = new Storyboard
        {
            Manager = await ReadManagerAsync<IStoryboardManager>(defFilePath),
            Animation = await ReadManagerAsync<IAnimationManager, IAnimationReader>(defFilePath)
        };

        storyboard.Sprite = storyboard.Manager?.SceneDef.SpriteFile is null 
            ? null 
            : await reader.GetSpriteAsync(dirName, storyboard.Manager.SceneDef.SpriteFile);

        return storyboard;
    }

    protected virtual IEnumerable<FileInfo> GetFiles(IEngine engine, string subdirectoryName) =>
        GetDirectory(engine, subdirectoryName).GetFiles();

    protected virtual DirectoryInfo GetDirectory(IEngine engine, string subdirectoryName)
    {
        if (engine.Path is null)
        {
            throw new NegumException($"Engine path is null.");
        }
        
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

    protected virtual Task<IEnumerable<TOutput>> LoadMultipleAsync<TOutput, TEntry>(
        IEnumerable<TEntry> sources,
        Func<TEntry, Task<TOutput>> parseFunction)
    {
        var tasks = sources
            .Select(parseFunction)
            .ToArray();

        Task.WaitAll(tasks);

        var entities = tasks
            .Select(task => task.Result)
            .Where(result => result is not null)
            .ToList();

        return Task.FromResult(entities.AsEnumerable());
    }

    protected virtual async Task<TManager?> ReadManagerAsync<TManager>(FileInfo file, string? path)
        where TManager : IManager
    {
        if (path is null)
        {
            return default;
        }
        
        var fullPath = Path.Combine(file.GetDirectoryNameOrThrow(), path);
        return await ReadManagerAsync<TManager>(fullPath);
    }

    protected virtual async Task<TManager?> ReadManagerAsync<TManager>(FileInfo? file)
        where TManager : IManager =>
        await ReadManagerAsync<TManager>(file?.FullName);

    protected virtual async Task<TManager?> ReadManagerAsync<TManager, TReader>(FileInfo? file)
        where TManager : IManager
        where TReader : IConfigurationReader =>
        await ReadManagerAsync<TManager, TReader>(file?.FullName);

    protected virtual async Task<TManager?> ReadManagerAsync<TManager>(string? path)
        where TManager : IManager =>
        await ReadManagerAsync<TManager, IConfigurationWithSubsectionReader>(path);

    protected virtual async Task<TManager?> ReadManagerAsync<TManager, TReader>(string? path)
        where TManager : IManager
        where TReader : IConfigurationReader
    {
        if (path is null)
        {
            return default;
        }
        
        var reader = NegumContainer.Resolve<TReader>();
        var configuration = await reader.ReadAsync(path);

        return (TManager) NegumContainer.Resolve<TManager>().UseConfiguration(configuration);
    }

    protected virtual async Task<TManager?> FindManagerAsync<TManager>(string dirName, string? filePath)
        where TManager : IManager
    {
        if (filePath is null)
        {
            return default;
        }
        
        var reader = NegumContainer.Resolve<IFilePathReader>();

        var file = reader.FindFile(dirName, filePath);

        if (file is null)
        {
            throw new NegumException($"Cannot find file in: [{nameof(dirName)}: {dirName}, {nameof(filePath)}: {filePath}]");
        }
            
        var manager = await ReadManagerAsync<TManager>(file);

        return manager;
    }
}