using System.Collections.Generic;
using Negum.Core.Configurations.Systems;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// System element.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumSystem : INegumConfigurationElement
    {
        /// <summary>
        /// Info section.
        /// </summary>
        INegumConfigurationInfoSection Info { get; }

        /// <summary>
        /// Files section.
        /// </summary>
        INegumConfigurationFilesSection Files { get; }

        /// <summary>
        /// Music section.
        /// </summary>
        INegumConfigurationSystemMusicSection Music { get; }

        /// <summary>
        /// Title Info section.
        /// </summary>
        INegumConfigurationTitleInfoSection TitleInfo { get; }

        /// <summary>
        /// Title BG Def section.
        /// </summary>
        INegumConfigurationTitleBgDefSection TitleBgDef { get; }
        
        /// <summary>
        /// Title BG section parts.
        /// </summary>
        IEnumerable<INegumConfigurationTitleBgSection> TitleBgs { get; }

        /// <summary>
        /// Select Info section.
        /// </summary>
        INegumConfigurationSelectInfoSection SelectInfo { get; }

        /// <summary>
        /// Begin Action section parts.
        /// </summary>
        IEnumerable<INegumConfigurationBeginActionSection> BeginActions { get; }

        /// <summary>
        /// Select BG Def section.
        /// </summary>
        INegumConfigurationSelectBgDefSection SelectBgDef { get; }

        /// <summary>
        /// Select BG section parts.
        /// </summary>
        IEnumerable<INegumConfigurationSelectBgSection> SelectBgs { get; }

        /// <summary>
        /// VS Screen section.
        /// </summary>
        INegumConfigurationVsScreenSection VsScreen { get; }

        /// <summary>
        /// Versus BG section parts.
        /// </summary>
        IEnumerable<INegumConfigurationVersusBgSection> VersusBgs { get; }

        /// <summary>
        /// Demo Mode section.
        /// </summary>
        INegumConfigurationDemoModeSection DemoMode { get; }

        /// <summary>
        /// Continue Screen section.
        /// </summary>
        INegumConfigurationContinueScreenSection ContinueScreen { get; }

        /// <summary>
        /// Game Over Screen section.
        /// </summary>
        INegumConfigurationGameOverScreenSection GameOverScreen { get; }

        /// <summary>
        /// Victory Screen section.
        /// </summary>
        INegumConfigurationVictoryScreenSection VictoryScreen { get; }

        /// <summary>
        /// Victory BG section parts.
        /// </summary>
        IEnumerable<INegumConfigurationVictoryBgSection> VictoryBgs { get; }

        /// <summary>
        /// Win Screen section.
        /// </summary>
        INegumConfigurationWinScreenSection WinScreen { get; }

        /// <summary>
        /// Default Ending section.
        /// </summary>
        INegumConfigurationDefaultEndingSection DefaultEnding { get; }

        /// <summary>
        /// End Credits section.
        /// </summary>
        INegumConfigurationEndCreditsSection EndCredits { get; }

        /// <summary>
        /// Survival Results Screen section.
        /// </summary>
        INegumConfigurationSurvivalResultsScreenSection SurvivalResultsScreen { get; }

        /// <summary>
        /// Option Info section.
        /// </summary>
        INegumConfigurationOptionInfoSection OptionInfo { get; }

        /// <summary>
        /// Option BG section parts.
        /// </summary>
        IEnumerable<INegumConfigurationOptionBgSection> OptionBgs { get; }
    }
}