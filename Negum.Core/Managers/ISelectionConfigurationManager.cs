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
        ISelectionConfigurationCharacters Characters =>
            NegumContainer.Resolve<ISelectionConfigurationCharacters>().Setup(this.Scrapper.GetSection("Characters"));

        ISelectionConfigurationExtraStages Stages =>
            NegumContainer.Resolve<ISelectionConfigurationExtraStages>().Setup(this.Scrapper.GetSection("ExtraStages"));

        ISelectionConfigurationOptions Options =>
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
            Scrapper.GetCollection<IFileEntry>(Scrapper.GetAll().Select(x => x.Key).ToList());
    }

    public interface ISelectionConfigurationOptions : IConfigurationManagerSection<ISelectionConfigurationOptions>
    {
        /// <summary>
        /// Here you set the maximum number of matches to fight before game ends in Arcade Mode.
        /// The first number is the number of matches against characters with order=1, followed by order=2 and order=3 respectively.
        /// For example, for 4,3,1 you will fight up to 4 randomly-picked characters who have order=1,
        /// followed by 3 with order=2 and 1 with order=3.
        /// </summary>
        IVectorEntry ArcadeMaxMatches => Scrapper.GetVector("arcade.maxmatches");

        /// <summary>
        /// Maximum number of matches to fight before game ends in Team Mode.
        /// Like ArcadeMaxMatches, but applies to Team Battle.
        /// </summary>
        IVectorEntry TeamMaxMatches => Scrapper.GetVector("team.maxmatches");
    }
}