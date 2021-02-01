using Negum.Core.Configurations.Selections;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Selection element.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumSelection : INegumConfigurationElement
    {
        /// <summary>
        /// Characters section.
        /// </summary>
        INegumConfigurationCharactersSection Characters { get; }

        /// <summary>
        /// Extra Stages section.
        /// </summary>
        INegumConfigurationExtraStagesSection ExtraStages { get; }

        /// <summary>
        /// Options section.
        /// </summary>
        INegumConfigurationSelectionOptionsSection Options { get; }
    }
}