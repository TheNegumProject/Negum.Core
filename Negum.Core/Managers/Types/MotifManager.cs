using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which provides helper methods for IMotifConfiguration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class MotifManager : Manager, IMotifManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) => new MotifManagerSection(sectionName, configSection);
}

public class MotifManagerSection :
    ManagerSection,
    IMotifInfo,
    IMotifFiles,
    IMotifMusic,
    IMotifTitleInfo,
    IMotifInfobox,
    IMotifSelectInfo,
    IMotifVsScreen,
    IMotifDemoMode,
    IMotifContinueScreen,
    IMotifGameOverScreen,
    IMotifVictoryScreen,
    IMotifWinScreen,
    IMotifDefaultEnding,
    IMotifEndCredits,
    IMotifSurvivalResultsScreen,
    IMotifScreenBg,
    IMotifScreenBgDef
{
    public MotifManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
    }
}