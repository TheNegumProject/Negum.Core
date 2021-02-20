using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Character configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterManager : IManager
    {
        ICharacterInfo Info => this.GetSection<ICharacterInfo>("Info");
        ICharacterFiles Files => this.GetSection<ICharacterFiles>("Files");

        ICharacterPaletteKeymap Keymap =>
            this.GetSection<ICharacterPaletteKeymap>("Palette Keymap");

        ICharacterArcade Arcade => this.GetSection<ICharacterArcade>("Arcade");
    }

    public interface ICharacterInfo : IManagerSection
    {
        string Name => this.GetValue<string>("name");
        string DisplayName => this.GetValue<string>("displayname");
        ITimeEntry VersionDate => this.GetValue<ITimeEntry>("versiondate");
        string Version => this.GetValue<string>("mugenversion");
        string Author => this.GetValue<string>("author");

        /// <summary>
        /// Default palettes in order of preference (up to 4).
        /// </summary>
        IVectorEntry PaletteDefaults => this.GetValue<IVectorEntry>("pal.defaults");
    }

    public interface ICharacterFiles : IManagerSection
    {
        IFileEntry CommandFile => this.GetValue<IFileEntry>("cmd");
        IFileEntry ConstantsFile => this.GetValue<IFileEntry>("cns");
        IFileEntry StatesFile => this.GetValue<IFileEntry>("st");
        IFileEntry CommonStatesFile => this.GetValue<IFileEntry>("stcommon");
        IFileEntry SpriteFiles => this.GetValue<IFileEntry>("sprite");
        IFileEntry AnimationFile => this.GetValue<IFileEntry>("anim");
        IFileEntry SoundFile => this.GetValue<IFileEntry>("sound");
        IFileEntry AiHintsDataFile => this.GetValue<IFileEntry>("ai");
    }

    public interface ICharacterPaletteKeymap : IManagerSection
    {
        int A => this.GetValue<int>("a");
        int B => this.GetValue<int>("b");
        int C => this.GetValue<int>("c");
        int X => this.GetValue<int>("x");
        int Y => this.GetValue<int>("y");
        int Z => this.GetValue<int>("z");
    }

    public interface ICharacterArcade : IManagerSection
    {
        IFileEntry IntroStoryboardFile => this.GetValue<IFileEntry>("intro.storyboard");
        IFileEntry EndingStoryboardFile => this.GetValue<IFileEntry>("ending.storyboard");
    }
}