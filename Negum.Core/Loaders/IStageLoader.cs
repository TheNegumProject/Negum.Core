using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Exceptions;
using Negum.Core.Extensions;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Stages;
using Negum.Core.Readers;

namespace Negum.Core.Loaders;

/// <summary>
/// Loader used to get all currently available Stages.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IStageLoader : IEngineModuleLoader<IEnumerable<IStage>>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class StageLoader : AbstractLoader, IStageLoader
{
    public async Task<IEnumerable<IStage>> LoadAsync(IEngine engine)
    {
        var stagePaths = engine.Data?.SelectionManager?.Characters.Characters
            .Select(character => character.StageFile)
            .Distinct()
            .ToList();

        var extraStages = engine.Data?.SelectionManager?.Stages.StageFiles
            .Distinct()
            .ToList();

        if (extraStages is not null)
        {
            stagePaths?.AddRange(extraStages);
        }

        if (stagePaths is null)
        {
            return Array.Empty<IStage>();
        }

        var sources = stagePaths
            .Select(stagePath =>
            {
                if (engine.Path is null || stagePath is null)
                {
                    return null;
                }
                
                var path = Path.Combine(engine.Path, stagePath);
                var file = new FileInfo(path);
                return file;
            })
            .Where(fi => fi is not null)
            .Where(file => file?.Exists ?? false)
            .ToList();

        return await LoadMultipleAsync(sources, GetStageAsync);
    }

    protected virtual async Task<IStage> GetStageAsync(FileInfo? defFile)
    {
        if (defFile is null)
        {
            throw new NegumException($"Null file passed when parsing stages.");
        }
        
        var reader = NegumContainer.Resolve<IFilePathReader>();
            
        var stage = new Stage();

        stage.File = defFile;
        stage.Manager = await ReadManagerAsync<IStageManager>(defFile);
        stage.Sprite = await reader.GetSpriteAsync(defFile.GetDirectoryNameOrThrow(), stage.Manager?.BackgroundDef.SpriteFile);

        return stage;
    }
}