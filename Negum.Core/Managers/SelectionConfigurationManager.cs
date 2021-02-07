using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SelectionConfigurationManager : ConfigurationManager<ISelectionConfigurationManager>,
        ISelectionConfigurationManager
    {
    }

    public class SelectionConfigurationManagerSection :
        ConfigurationManagerSection<SelectionConfigurationManagerSection>,
        ISelectionConfigurationCharacters,
        ISelectionConfigurationExtraStages,
        ISelectionConfigurationOptions
    {
        ISelectionConfigurationCharacters IConfigurationManagerSection<ISelectionConfigurationCharacters>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        ISelectionConfigurationExtraStages IConfigurationManagerSection<ISelectionConfigurationExtraStages>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        ISelectionConfigurationOptions IConfigurationManagerSection<ISelectionConfigurationOptions>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}