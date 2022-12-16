namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Fighting Player Win Types entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFightConfigurationWinEntry : IManagerSectionEntry<IFightConfigurationWinEntry>
{
    /// <summary>
    /// Win by normal.
    /// </summary>
    IImageEntry? Normal { get; }

    /// <summary>
    /// Win by special.
    /// </summary>
    IImageEntry? Special { get; }

    /// <summary>
    /// Win by hyper (super).
    /// </summary>
    IImageEntry? Hyper { get; }

    /// <summary>
    /// Win by normal throw.
    /// </summary>
    IImageEntry? Throw { get; }

    /// <summary>
    /// Win by cheese.
    /// </summary>
    IImageEntry? Cheese { get; }

    /// <summary>
    /// Win by time over.
    /// </summary>
    IImageEntry? TimeOver { get; }

    /// <summary>
    /// Win by suicide.
    /// </summary>
    IImageEntry? Suicide { get; }

    /// <summary>
    /// Opponent beaten by his own teammate.
    /// </summary>
    IImageEntry? Teammate { get; }

    /// <summary>
    /// Win by perfect.
    /// </summary>
    IImageEntry? Perfect { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FightConfigurationWinEntry : ManagerSectionEntry<IFightConfigurationWinEntry>,
    IFightConfigurationWinEntry
{
    public IImageEntry? Normal { get; private set; }
    public IImageEntry? Special { get; private set; }
    public IImageEntry? Hyper { get; private set; }
    public IImageEntry? Throw { get; private set; }
    public IImageEntry? Cheese { get; private set; }
    public IImageEntry? TimeOver { get; private set; }
    public IImageEntry? Suicide { get; private set; }
    public IImageEntry? Teammate { get; private set; }
    public IImageEntry? Perfect { get; private set; }

    public override IFightConfigurationWinEntry Read()
    {
        Normal = Section?.GetValue<IImageEntry>(FieldKey + ".n");
        Special = Section?.GetValue<IImageEntry>(FieldKey + ".s");
        Hyper = Section?.GetValue<IImageEntry>(FieldKey + ".h");
        Throw = Section?.GetValue<IImageEntry>(FieldKey + ".throw");
        Cheese = Section?.GetValue<IImageEntry>(FieldKey + ".c");
        TimeOver = Section?.GetValue<IImageEntry>(FieldKey + ".t");
        Suicide = Section?.GetValue<IImageEntry>(FieldKey + ".suicide");
        Teammate = Section?.GetValue<IImageEntry>(FieldKey + ".teammate");
        Perfect = Section?.GetValue<IImageEntry>(FieldKey + ".perfect");

        return this;
    }
}