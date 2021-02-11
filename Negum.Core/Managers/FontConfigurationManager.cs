namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontConfigurationManager : ConfigurationManager, IFontConfigurationManager
    {
    }

    public class FontConfigurationManagerSection :
        ConfigurationManagerSection,
        IFontConfigurationFontV2,
        IFontConfigurationDef
    {
    }
}