using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Character configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterNegumManager : INegumManager
    {
        ICharacterNegumInfo Info => this.GetSection<ICharacterNegumInfo>("Info");
        ICharacterNegumFiles Files => this.GetSection<ICharacterNegumFiles>("Files");

        ICharacterNegumPaletteKeymap Keymap =>
            this.GetSection<ICharacterNegumPaletteKeymap>("Palette Keymap");

        ICharacterNegumArcade Arcade => this.GetSection<ICharacterNegumArcade>("Arcade");
    }

    public interface ICharacterNegumInfo : INegumManagerSection
    {
        string Name => Scrapper.GetString("name");
        string DisplayName => Scrapper.GetString("displayname");
        ITimeEntry VersionDate => Scrapper.GetTime("versiondate");
        string Version => Scrapper.GetString("mugenversion");
        string Author => Scrapper.GetString("author");

        /// <summary>
        /// Default palettes in order of preference (up to 4).
        /// </summary>
        IVectorEntry PaletteDefaults => Scrapper.GetVector("pal.defaults");
    }

    public interface ICharacterNegumFiles : INegumManagerSection
    {
        IFileEntry CommandFile => Scrapper.GetFile("cmd");
        IFileEntry ConstantsFile => Scrapper.GetFile("cns");
        IFileEntry StatesFile => Scrapper.GetFile("st");
        IFileEntry CommonStatesFile => Scrapper.GetFile("stcommon");
        IFileEntry SpriteFiles => Scrapper.GetFile("sprite");
        IFileEntry AnimationFile => Scrapper.GetFile("anim");
        IFileEntry SoundFile => Scrapper.GetFile("sound");
        IFileEntry AiHintsDataFile => Scrapper.GetFile("ai");
    }

    public interface ICharacterNegumPaletteKeymap : INegumManagerSection
    {
        int A => Scrapper.GetInt("a");
        int B => Scrapper.GetInt("b");
        int C => Scrapper.GetInt("c");
        int X => Scrapper.GetInt("x");
        int Y => Scrapper.GetInt("y");
        int Z => Scrapper.GetInt("z");
    }

    public interface ICharacterNegumArcade : INegumManagerSection
    {
        IFileEntry IntroStoryboardFile => Scrapper.GetFile("intro.storyboard");
        IFileEntry EndingStoryboardFile => Scrapper.GetFile("ending.storyboard");
    }
}