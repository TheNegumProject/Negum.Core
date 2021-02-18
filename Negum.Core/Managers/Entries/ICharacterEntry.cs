namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Character entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterEntry : INegumManagerSectionEntry<ICharacterEntry>
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
        IFileEntry NameFile { get; }

        /// <summary>
        /// Path to the stage file for the character.
        /// Example: stages/mybg.def
        ///
        /// If you put "random" as the Stage in configuration, then a random stage will be selected for that player.
        /// </summary>
        IFileEntry StageFile { get; }

        /// <summary>
        /// Set the value to the name of the music file to use as the BGM for that character.
        /// This overrides the bgmusic parameter in the stage's .def file,
        /// so you can re-use the same stage for multiple characters, but have a different BGM playing for each person.
        /// </summary>
        IFileEntry MusicFile { get; }

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
    public class CharacterEntry : NegumManagerSectionEntry<ICharacterEntry>, ICharacterEntry
    {
        public string Name { get; private set; }
        public IFileEntry NameFile { get; private set; }
        public IFileEntry StageFile { get; private set; }
        public IFileEntry MusicFile { get; private set; }
        public int IncludeStage { get; private set; }
        public int Order { get; private set; }
        public bool IsRandomSelect { get; private set; }

        public override ICharacterEntry Get()
        {
            // TODO: Config file -> select.def; Section -> Character;
            // TODO: Add appropriate parsing each line. IDEA: Add unique parser for that ???
            
            this.Name = this.Section.GetValue<string>(this.FieldKey);
            this.NameFile = this.Section.GetValue<IFileEntry>(this.FieldKey);
            this.StageFile = this.Section.GetValue<IFileEntry>(this.FieldKey);
            this.MusicFile = this.Section.GetValue<IFileEntry>(this.FieldKey);
            this.IncludeStage = this.Section.GetValue<int>(this.FieldKey);
            this.Order = this.Section.GetValue<int>(this.FieldKey);
            this.IsRandomSelect = this.Section.GetValue<bool>(this.FieldKey);

            return this;
        }
    }
}