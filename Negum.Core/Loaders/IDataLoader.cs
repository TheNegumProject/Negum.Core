using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Extensions;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Data;
using Negum.Core.Models.Sounds;
using Negum.Core.Models.Sprites;
using Negum.Core.Readers;

namespace Negum.Core.Loaders;

/// <summary>
/// Loader used to read everything from "data" directory.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IDataLoader : IEngineModuleLoader<IData>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class DataLoader : AbstractLoader, IDataLoader
{
    public async Task<IData> LoadAsync(IEngine engine)
    {
        const string configFileName = "mugen.cfg";

        var dir = GetDirectory(engine, "data").FullName;
        var data = new NegumData();

        data.ConfigManager = await FindManagerAsync<IConfigurationManager>(dir, configFileName);
            
        var reader = NegumContainer.Resolve<IFilePathReader>();

        var motifFileName = data.ConfigManager?.Options.MotifFile;
        
        if (motifFileName == null)
        {
            throw new FileNotFoundException($"Cannot find motif file name: {motifFileName}");
        }
        
        var motifFile = reader.FindFile(dir, motifFileName);
        
        if (motifFile == null)
        {
            throw new FileNotFoundException($"Cannot find motif file: {motifFileName}");
        }

        var motifDirFullName = motifFile.GetDirectoryOrThrow().FullName;

        data.MotifManager = await FindManagerAsync<IMotifManager>(dir, data.ConfigManager?.Options.MotifFile);
        data.MotifSprite = await GetSpriteAsync(reader, motifDirFullName, data.MotifManager?.Files.SpriteFile);
        data.MotifSound = await GetSoundAsync(reader, motifDirFullName, data.MotifManager?.Files.SoundFile);
        data.SelectionManager = await FindManagerAsync<ISelectionManager>(motifDirFullName, data.MotifManager?.Files.SelectionFile);
        data.FightManager = await FindManagerAsync<IFightManager>(motifDirFullName, data.MotifManager?.Files.FightFile);
        data.Logo = await ReadStoryboardAsync(motifDirFullName, data.MotifManager?.Files.LogoStoryboardDefinition);
        data.Intro = await ReadStoryboardAsync(motifDirFullName, data.MotifManager?.Files.IntroStoryboardDefinition);

        return data;
    }

    protected virtual async Task<ISprite?> GetSpriteAsync(IFilePathReader reader, string dirName, string? fileName)
    {
        fileName = CleanupFileName(fileName);
        return await reader.GetSpriteAsync(dirName, fileName);
    }

    protected virtual async Task<ISound?> GetSoundAsync(IFilePathReader reader, string dirName, string? fileName)
    {
        fileName = CleanupFileName(fileName);
        return await reader.GetSoundAsync(dirName, fileName);
    }

    protected virtual string? CleanupFileName(string? fileName)
    {
        if (fileName is null)
        {
            return null;
        }
        
        if (fileName.StartsWith("data/"))
        {
            fileName = fileName.Replace("data/", "");
        }

        return fileName;
    }
}