namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for INegumConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumNegumManager : NegumManager, INegumNegumManager
    {
    }

    public class NegumNegumManagerSection :
        NegumManagerSection,
        INegumNegumOptions,
        INegumNegumRules,
        INegumNegumConfig,
        INegumNegumDebug,
        INegumNegumVideo,
        INegumNegumSound,
        INegumNegumMisc,
        INegumNegumArcade,
        INegumNegumInput,
        INegumNegumKeys
    {
    }
}