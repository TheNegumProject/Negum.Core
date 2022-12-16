using Negum.Core.Containers;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Fonts;

namespace Negum.Core.Readers.Fonts;

/// <summary>
/// Contains common code for Font readers.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class CommonFontReader
{
    /// <summary>
    /// Method used to parse common properties vor various Font versions.
    /// </summary>
    /// <param name="font"></param>
    /// <param name="manager"></param>
    protected virtual void ProcessConfiguration(Font font, IFontManager manager)
    {
        var pointReader = NegumContainer.Resolve<IPointReader>();

        font.Size = pointReader.ToPointAsync(manager.Def.Size).Result;
        font.Spacing = pointReader.ToPointAsync(manager.Def.Spacing).Result;
        font.Offset = pointReader.ToPointAsync(manager.Def.Offset).Result;
        font.Type = manager.Def.Type;
    }
}