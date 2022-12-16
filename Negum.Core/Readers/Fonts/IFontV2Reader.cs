using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Extensions;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Fonts;

namespace Negum.Core.Readers.Fonts;

/// <summary>
/// Reader which is designed to handle Fonts from ".def" files.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFontV2Reader : IReader<string, IFont>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontV2Reader : CommonFontReader, IFontV2Reader
{
    public async Task<IFont> ReadAsync(string path)
    {
        var config = await NegumContainer.Resolve<IConfigurationReader>().ReadAsync(path);
        var manager = (IFontManager) NegumContainer.Resolve<IFontManager>().UseConfiguration(config);

        var font = new FontV2();

        ProcessConfiguration(font, manager);

        font.Name = manager.FontV2.FontName;
        font.SpriteFile = manager.Def.File;

        var reader = NegumContainer.Resolve<IFilePathReader>();
        var file = new FileInfo(path);

        font.Sprite = manager.Def.File is null ? null : await reader.GetSpriteAsync(file.GetDirectoryNameOrThrow(), manager.Def.File);

        return font;
    }
}