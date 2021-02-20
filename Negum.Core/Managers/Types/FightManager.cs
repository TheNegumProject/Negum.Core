namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FightManager : Manager, IFightManager
    {
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
    }
}