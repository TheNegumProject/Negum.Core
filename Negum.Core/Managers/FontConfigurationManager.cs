using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontConfigurationManager : ConfigurationManager<IFontConfigurationManager>, IFontConfigurationManager
    {
    }

    public class FontConfigurationManagerSection :
        ConfigurationManagerSection<FontConfigurationManagerSection>,
        IFontConfigurationFontV2,
        IFontConfigurationDef
    {
        IFontConfigurationFontV2 IConfigurationManagerSection<IFontConfigurationFontV2>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFontConfigurationDef IConfigurationManagerSection<IFontConfigurationDef>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}