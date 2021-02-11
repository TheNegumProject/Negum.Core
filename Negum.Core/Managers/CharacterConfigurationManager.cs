using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterConfigurationManager : ConfigurationManager<ICharacterConfigurationManager>,
        ICharacterConfigurationManager
    {
    }

    public class CharacterConfigurationManagerSection :
        ConfigurationManagerSection<CharacterConfigurationManagerSection>,
        ICharacterConfigurationInfo,
        ICharacterConfigurationFiles,
        ICharacterConfigurationPaletteKeymap,
        ICharacterConfigurationArcade
    {
        ICharacterConfigurationInfo IConfigurationManagerSection<ICharacterConfigurationInfo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        ICharacterConfigurationFiles IConfigurationManagerSection<ICharacterConfigurationFiles>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        ICharacterConfigurationPaletteKeymap IConfigurationManagerSection<ICharacterConfigurationPaletteKeymap>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        ICharacterConfigurationArcade IConfigurationManagerSection<ICharacterConfigurationArcade>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);
    }
}