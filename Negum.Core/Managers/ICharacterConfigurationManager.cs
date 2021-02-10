using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Character configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterConfigurationManager : IConfigurationManager<ICharacterConfigurationManager>
    {
        ICharacterConfigurationInfo Info =>
            NegumContainer.Resolve<ICharacterConfigurationInfo>().Setup(this.Scrapper.GetSection("Info"));

        ICharacterConfigurationFiles Files =>
            NegumContainer.Resolve<ICharacterConfigurationFiles>().Setup(this.Scrapper.GetSection("Files"));

        ICharacterConfigurationPaletteKeymap Keymap =>
            NegumContainer.Resolve<ICharacterConfigurationPaletteKeymap>()
                .Setup(this.Scrapper.GetSection("Palette Keymap"));

        ICharacterConfigurationArcade Arcade =>
            NegumContainer.Resolve<ICharacterConfigurationArcade>().Setup(this.Scrapper.GetSection("Arcade"));
    }

    public interface ICharacterConfigurationInfo : IConfigurationManagerSection<ICharacterConfigurationInfo>
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

    public interface ICharacterConfigurationFiles : IConfigurationManagerSection<ICharacterConfigurationFiles>
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

    public interface ICharacterConfigurationPaletteKeymap :
        IConfigurationManagerSection<ICharacterConfigurationPaletteKeymap>
    {
        int A => Scrapper.GetInt("a");
        int B => Scrapper.GetInt("b");
        int C => Scrapper.GetInt("c");
        int X => Scrapper.GetInt("x");
        int Y => Scrapper.GetInt("y");
        int Z => Scrapper.GetInt("z");
    }

    public interface ICharacterConfigurationArcade : IConfigurationManagerSection<ICharacterConfigurationArcade>
    {
        IFileEntry IntroStoryboardFile => Scrapper.GetFile("intro.storyboard");
        IFileEntry EndingStoryboardFile => Scrapper.GetFile("ending.storyboard");
    }
}