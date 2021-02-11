namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SelectionConfigurationManager : ConfigurationManager, ISelectionConfigurationManager
    {
    }

    public class SelectionConfigurationManagerSection :
        ConfigurationManagerSection,
        ISelectionConfigurationCharacters,
        ISelectionConfigurationExtraStages,
        ISelectionConfigurationOptions
    {
    }
}