using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Models.Fonts;
using Negum.Core.Readers;

namespace Negum.Core.Loaders;

/// <summary>
/// Loader used to get all currently available Fonts.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFontLoader : IEngineModuleLoader<IEnumerable<IFont>>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontLoader : AbstractLoader, IFontLoader
{
    public async Task<IEnumerable<IFont>> LoadAsync(IEngine engine)
    {
        var sources = GetFiles(engine, "font")
            .Where(file => file.Extension.Equals(".fnt") || file.Extension.Equals(".def"));

        return await LoadMultipleAsync(sources, GetFontAsync);
    }

    protected virtual async Task<IFont> GetFontAsync(FileInfo file)
    {
        var reader = NegumContainer.Resolve<IFontPathReader>();
        return await reader.ReadAsync(file.FullName);
    }
}