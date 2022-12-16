using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Character configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ICharacterManager : IManager
{
    ICharacterInfo Info => GetSection<ICharacterInfo>("Info");
    ICharacterFiles Files => GetSection<ICharacterFiles>("Files");
    ICharacterPaletteKeymap Keymap => GetSection<ICharacterPaletteKeymap>("Palette Keymap");
    ICharacterArcade Arcade => GetSection<ICharacterArcade>("Arcade");
}

public interface ICharacterInfo : IManagerSection
{
    string? CharacterName => GetValue<string>("name");
    string? DisplayName => GetValue<string>("displayname");
    ITimeEntry? VersionDate => GetValue<ITimeEntry>("versiondate");
    string? Version => GetValue<string>("mugenversion");
    string? Author => GetValue<string>("author");

    /// <summary>
    /// Default palettes in order of preference (up to 4).
    /// </summary>
    IVectorEntry? PaletteDefaults => GetValue<IVectorEntry>("pal.defaults");
}

public interface ICharacterFiles : IManagerSection
{
    string? CommandFile => GetValue<string>("cmd");
    string? ConstantsFile => GetValue<string>("cns");
    string? StatesFile => GetValue<string>("st");
    string? CommonStatesFile => GetValue<string>("stcommon");
    string? SpriteFiles => GetValue<string>("sprite");
    string? AnimationFile => GetValue<string>("anim");
    string? SoundFile => GetValue<string>("sound");
    string? AiHintsDataFile => GetValue<string>("ai");
}

public interface ICharacterPaletteKeymap : IManagerSection
{
    int? A => GetValue<int>("a");
    int? B => GetValue<int>("b");
    int? C => GetValue<int>("c");
    int? X => GetValue<int>("x");
    int? Y => GetValue<int>("y");
    int? Z => GetValue<int>("z");
}

public interface ICharacterArcade : IManagerSection
{
    string? IntroStoryboardFile => GetValue<string>("intro.storyboard");
    string? EndingStoryboardFile => GetValue<string>("ending.storyboard");
}