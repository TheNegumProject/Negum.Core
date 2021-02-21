using System.Collections.Generic;
using System.Linq;

namespace Negum.Core.Managers.Entries
{
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
        /// </summary>
        string Name { get; }

        /// <summary>
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
        string NameFile { get; }

        /// <summary>
        /// Path to the stage file for the character.
        /// Example: stages/mybg.def
        ///
        /// If you put "random" as the Stage in configuration, then a random stage will be selected for that player.
        /// </summary>
        string StageFile { get; }

        /// <summary>
        /// Set the value to the name of the music file to use as the BGM for that character.
        /// This overrides the bgmusic parameter in the stage's .def file,
        /// so you can re-use the same stage for multiple characters, but have a different BGM playing for each person.
        /// </summary>
        string MusicFile { get; }

        /// <summary>
        /// Set the paramValue to 0 to avoid including this stage in the stage select list (in VS, training modes, etc).
        /// </summary>
        int IncludeStage { get; }

        /// <summary>
        /// Set the paramvalue to the ordering priority to give the character.
        /// Valid values are from 1 to 30.
        /// A smaller value means you will fight the character sooner.
        /// You will never fight an order 2 character before an order 1 character, and never an order 3 character before an order 2 one.
        /// For example, you might want to set your boss character to have order=3.
        /// The default order value is 1 if you omit this param.
        /// See *.maxmatches under [Options] for how to limit the number of matches per order priority.
        /// </summary>
        int Order { get; }

        /// <summary>
        /// You can also add a randomize icon to the select screen.
        /// To do this, put the word "randomselect" on a line of its own, with no extra parameters.
        /// </summary>
        bool IsRandomSelect { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>   
    public class CharacterEntry : ManagerSectionEntry<ICharacterEntry>, ICharacterEntry
    {
        public string Name { get; set; }
        public string NameFile { get; set; }
        public string StageFile { get; set; }
        public string MusicFile { get; set; }
        public int IncludeStage { get; set; }
        public int Order { get; set; }
        public bool IsRandomSelect { get; set; }

        public override ICharacterEntry Get()
        {
            var value = this.Section.GetValue<string>(this.FieldKey);

            var args = value
                .Replace(" ", "")
                .Split(",");

            // Must be filled fields
            this.Name = args[0];
            this.NameFile = args[1];

            // Optional fields
            this.MusicFile = this.GetArg(args, "music");
            this.IncludeStage = int.Parse(this.GetArg(args, "includestage") ?? "-1");
            this.Order = int.Parse(this.GetArg(args, "order") ?? "1");
            this.IsRandomSelect = bool.Parse(this.GetArg(args, "randomselect") ?? "false");

            return this;
        }

        protected virtual string GetArg(IEnumerable<string> args, string key) =>
            args.FirstOrDefault(arg => arg.StartsWith(key + "="))?.Split("=")[1];
    }
}