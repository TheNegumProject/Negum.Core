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
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        ICharacterConfigurationFiles IConfigurationManagerSection<ICharacterConfigurationFiles>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        ICharacterConfigurationPaletteKeymap IConfigurationManagerSection<ICharacterConfigurationPaletteKeymap>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        ICharacterConfigurationArcade IConfigurationManagerSection<ICharacterConfigurationArcade>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}