using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Selection configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISelectionNegumManager : INegumManager
    {
        ISelectionNegumCharacters Characters =>
            this.GetSection<ISelectionNegumCharacters>("Characters");

        ISelectionNegumExtraStages Stages => this.GetSection<ISelectionNegumExtraStages>("ExtraStages");
        ISelectionNegumOptions Options => this.GetSection<ISelectionNegumOptions>("Options");
    }

    public interface ISelectionNegumCharacters : INegumManagerSection
    {
        IEnumerable<ICharacterEntry> Characters => Scrapper.GetCharacters();
    }

    public interface ISelectionNegumExtraStages : INegumManagerSection
    {
        IEnumerable<IFileEntry> StageFiles =>
            Scrapper.GetCollection<IFileEntry>(Scrapper.Select(x => x.Key).ToList());
    }

    public interface ISelectionNegumOptions : INegumManagerSection
    {
        /// <summary>
        /// Here you set the maximum number of matches to fight before game ends in Arcade Mode.
        /// The first number is the number of matches against characters with order=1, followed by order=2 and order=3 respectively.
        /// For example, for 4,3,1 you will fight up to 4 randomly-picked characters who have order=1,
        /// followed by 3 with order=2 and 1 with order=3.
        /// </summary>
        IVectorEntry ArcadeMaxMatches => this.GetValue<IVectorEntry>("arcade.maxmatches");

        /// <summary>
        /// Maximum number of matches to fight before game ends in Team Mode.
        /// Like ArcadeMaxMatches, but applies to Team Battle.
        /// </summary>
        IVectorEntry TeamMaxMatches => this.GetValue<IVectorEntry>("team.maxmatches");
    }
}