using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FightManager : Manager, IFightManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) => new FightManagerSection(sectionName, configSection);
}

public class FightManagerSection :
    ManagerSection,
    IFightFiles,
    IFightFightFx,
    IFightLifebar,
    IFightSimulLifebar,
    IFightTurnsLifebar,
    IFightPowerbar,
    IFightFace,
    IFightSimulFace,
    IFightTurnsFace,
    IFightName,
    IFightSimulName,
    IFightTurnsName,
    IFightTime,
    IFightCombo,
    IFightRound,
    IFightWinIcon
{
    public FightManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
    }
}