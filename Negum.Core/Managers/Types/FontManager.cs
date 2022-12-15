using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontManager : Manager, IFontManager
{
    protected override IManagerSection
        GetNewManagerSection(string sectionName, IConfigurationSection configSection) =>
        new FontManagerSection(sectionName, configSection);
}

public class FontManagerSection :
    ManagerSection,
    IFontFontV2,
    IFontDef
{
    public FontManagerSection(string name, IConfigurationSection section) : base(name, section)
    {
    }
}