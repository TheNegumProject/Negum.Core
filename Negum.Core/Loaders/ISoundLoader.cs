using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Models.Sounds;
using Negum.Core.Readers;

namespace Negum.Core.Loaders;

/// <summary>
/// Loader used to get all currently available Sounds.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISoundLoader : IEngineModuleLoader<IEnumerable<ISound>>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SoundLoader : AbstractLoader, ISoundLoader
{
    public async Task<IEnumerable<ISound>> LoadAsync(IEngine engine) =>
        await LoadMultipleAsync(GetFiles(engine, "sound"), GetSoundAsync);

    protected virtual async Task<ISound> GetSoundAsync(FileInfo file)
    {
        var reader = NegumContainer.Resolve<ISoundPathReader>();
        return await reader.ReadAsync(file.FullName);
    }
}