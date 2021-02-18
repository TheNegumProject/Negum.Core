namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FightNegumManager : NegumManager, IFightNegumManager
    {
    }

    public class FightNegumManagerSection :
        NegumManagerSection,
        IFightNegumFiles,
        IFightNegumFightFx,
        IFightNegumLifebar,
        IFightNegumSimulLifebar,
        IFightNegumTurnsLifebar,
        IFightNegumPowerbar,
        IFightNegumFace,
        IFightNegumSimulFace,
        IFightNegumTurnsFace,
        IFightNegumName,
        IFightNegumSimulName,
        IFightNegumTurnsName,
        IFightNegumTime,
        IFightNegumCombo,
        IFightNegumRound,
        IFightNegumWinIcon
    {
    }
}