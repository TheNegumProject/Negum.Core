using System.Collections.Generic;
using System.Linq;
using Negum.Core.Containers;
using Negum.Core.Readers;

namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Character entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ICharacterEntry : IManagerSectionEntry<ICharacterEntry>
{
    /// <summary>
    /// Name / Nick of the Character.
    /// Example: kfm
    ///
    /// If you want to load a different def file, you can enter it as a directory plus the def file.
    /// Example: kfm/alt-kfm.def
    ///
    /// Zipped characters are also supported.
    /// Place the ZIP file in the "chars/" directory.
    /// Example: zipname.zip:defname.def
    ///
    /// If your def file has the same name as the zip file (eg. suave.def in suave.zip), you can just put the name of the zip file alone.
    /// Example: suave.zip
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// Path to the stage file for the character.
    /// Example: stages/mybg.def
    ///
    /// If you put "random" as the Stage in configuration, then a random stage will be selected for that player.
    /// </summary>
    string? StageFile { get; }

    /// <summary>
    /// Set the value to the name of the music file to use as the BGM for that character.
    /// This overrides the bgmusic parameter in the stage's .def file,
    /// so you can re-use the same stage for multiple characters, but have a different BGM playing for each person.
    /// </summary>
    string? MusicFile { get; }

    /// <summary>
    /// Set the paramValue to 0 to avoid including this stage in the stage select list (in VS, training modes, etc).
    /// </summary>
    int? IncludeStage { get; }

    /// <summary>
    /// Set the paramvalue to the ordering priority to give the character.
    /// Valid values are from 1 to 30.
    /// A smaller value means you will fight the character sooner.
    /// You will never fight an order 2 character before an order 1 character, and never an order 3 character before an order 2 one.
    /// For example, you might want to set your boss character to have order=3.
    /// The default order value is 1 if you omit this param.
    /// See *.maxmatches under [Options] for how to limit the number of matches per order priority.
    /// </summary>
    int? Order { get; }

    /// <summary>
    /// You can also add a randomize icon to the select screen.
    /// To do this, put the word "randomselect" on a line of its own, with no extra parameters.
    /// </summary>
    bool? IsRandomSelect { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>   
public class CharacterEntry : ManagerSectionEntry<ICharacterEntry>, ICharacterEntry
{
    public string? Name { get; private set; }
    public string? StageFile { get; private set; }
    public string? MusicFile { get; private set; }
    public int? IncludeStage { get; private set; }
    public int? Order { get; private set; }
    public bool? IsRandomSelect { get; private set; }

    public override ICharacterEntry Read()
    {
        var value = Section?.GetValue<string>(FieldKey);
        var reader = NegumContainer.Resolve<IStringVectorReader>();
        var vector = reader.ReadAsync(value).Result;

        // Fields which must be filled
        Name = vector[0];
        StageFile = vector[1];

        // Optional fields
        MusicFile = GetArg(vector, "music");
        IncludeStage = int.Parse(GetArg(vector, "includestage") ?? "-1");
        Order = int.Parse(GetArg(vector, "order") ?? "1");
        IsRandomSelect = bool.Parse(GetArg(vector, "randomselect") ?? false.ToString());

        return this;
    }

    protected virtual string? GetArg(IEnumerable<string> args, string key) =>
        args.FirstOrDefault(arg => arg.StartsWith(key + "="))?.Split("=")[1];
}