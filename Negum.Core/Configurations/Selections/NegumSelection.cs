namespace Negum.Core.Configurations.Selections
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumSelection : INegumSelection
    {
        public INegumConfigurationCharactersSection Characters { get; } =
            NegumContainer.Resolve<INegumConfigurationCharactersSection>();

        public INegumConfigurationExtraStagesSection ExtraStages { get; } =
            NegumContainer.Resolve<INegumConfigurationExtraStagesSection>();

        public INegumConfigurationSelectionOptionsSection Options { get; } =
            NegumContainer.Resolve<INegumConfigurationSelectionOptionsSection>();
    }
}