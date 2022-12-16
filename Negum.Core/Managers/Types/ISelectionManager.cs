using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Selection configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISelectionManager : IManager
{
    ISelectionCharacters Characters => GetSection<ISelectionCharacters>("Characters");
    ISelectionExtraStages Stages => GetSection<ISelectionExtraStages>("ExtraStages");
    ISelectionOptions Options => GetSection<ISelectionOptions>("Options");
}

public interface ISelectionCharacters : IManagerSection
{
    IEnumerable<ICharacterEntry> Characters => GetAll<ICharacterEntry>();
}

public interface ISelectionExtraStages : IManagerSection
{
    IEnumerable<string> StageFiles => GetAll<string>();
}

public interface ISelectionOptions : IManagerSection
{
    /// <summary>
    /// Here you set the maximum number of matches to fight before game ends in Arcade Mode.
    /// The first number is the number of matches against characters with order=1, followed by order=2 and order=3 respectively.
    /// For example, for 4,3,1 you will fight up to 4 randomly-picked characters who have order=1,
    /// followed by 3 with order=2 and 1 with order=3.
    /// </summary>
    IVectorEntry? ArcadeMaxMatches => GetValue<IVectorEntry>("arcade.maxmatches");

    /// <summary>
    /// Maximum number of matches to fight before game ends in Team Mode.
    /// Like ArcadeMaxMatches, but applies to Team Battle.
    /// </summary>
    IVectorEntry? TeamMaxMatches => GetValue<IVectorEntry>("team.maxmatches");
}