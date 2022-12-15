namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Player Team Menu entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPlayerSelectionTeamMenuEntry : IManagerSectionEntry<IPlayerSelectionTeamMenuEntry>
{
    IVectorEntry? Position { get; }
    IImageEntry? Background { get; }
    ITextEntry? SelfTitle { get; }
    ITextEntry? EnemyTitle { get; }
    IVectorEntry? Move { get; }
    IPlayerSelectionTeamMenuItemEntry? Item { get; }
    IPlayerSelectionTeamMenuValueEntry? Value { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PlayerSelectionTeamMenuEntry : ManagerSectionEntry<IPlayerSelectionTeamMenuEntry>,
    IPlayerSelectionTeamMenuEntry
{
    public IVectorEntry? Position { get; private set; }
    public IImageEntry? Background { get; private set; }
    public ITextEntry? SelfTitle { get; private set; }
    public ITextEntry? EnemyTitle { get; private set; }
    public IVectorEntry? Move { get; private set; }
    public IPlayerSelectionTeamMenuItemEntry? Item { get; private set; }
    public IPlayerSelectionTeamMenuValueEntry? Value { get; private set; }

    public override IPlayerSelectionTeamMenuEntry Read()
    {
        Position = Section?.GetValue<IVectorEntry>(FieldKey + ".pos");
        Background = Section?.GetValue<IImageEntry>(FieldKey + ".bg");
        SelfTitle = Section?.GetValue<ITextEntry>(FieldKey + ".selftitle");
        EnemyTitle = Section?.GetValue<ITextEntry>(FieldKey + ".enemytitle");
        Move = Section?.GetValue<IVectorEntry>(FieldKey + ".move");
        Item = Section?.GetValue<IPlayerSelectionTeamMenuItemEntry>(FieldKey + ".item");
        Value = Section?.GetValue<IPlayerSelectionTeamMenuValueEntry>(FieldKey + ".value");

        return this;
    }
}