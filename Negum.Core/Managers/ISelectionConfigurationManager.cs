using System.Collections.Generic;
using System.Linq;
using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Selection configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISelectionConfigurationManager : IConfigurationManager<ISelectionConfigurationManager>
    {
        public ISelectionConfigurationCharacters Characters =>
            NegumContainer.Resolve<ISelectionConfigurationCharacters>().Setup(this.Scrapper.GetSection("Characters"));

        public ISelectionConfigurationExtraStages Stages =>
            NegumContainer.Resolve<ISelectionConfigurationExtraStages>().Setup(this.Scrapper.GetSection("ExtraStages"));

        public ISelectionConfigurationOptions Options =>
            NegumContainer.Resolve<ISelectionConfigurationOptions>().Setup(this.Scrapper.GetSection("Options"));
    }

    public interface ISelectionConfigurationCharacters : IConfigurationManagerSection<ISelectionConfigurationCharacters>
    {
        IEnumerable<ICharacterEntry> Characters => Scrapper.GetCharacters();
    }

    public interface
        ISelectionConfigurationExtraStages : IConfigurationManagerSection<ISelectionConfigurationExtraStages>
    {
        IEnumerable<IFileEntry> Stages =>
            Scrapper.GetFiles(Scrapper.GetAll().Select(x => x.Key).ToList());
    }

    public interface ISelectionConfigurationOptions : IConfigurationManagerSection<ISelectionConfigurationOptions>
    {
        string ArcadeMaxMatches => Scrapper.GetString("arcade.maxmatches");
        string TeamMaxMatches => Scrapper.GetString("team.maxmatches");
    }
}