namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Player Selection entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPlayerSelectionEntry : IManagerSectionEntry<IPlayerSelectionEntry>
{
    IImageEntry? BigPortrait { get; }
    IPlayerSelectionCursorEntry? Cursor { get; }
    IMovementStateEntry? RandomMove { get; }
    IImageEntry? Face { get; }
    ITextEntry? Name { get; }
    IPlayerSelectionTeamMenuEntry? MenuEntry { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PlayerSelectionEntry : ManagerSectionEntry<IPlayerSelectionEntry>, IPlayerSelectionEntry
{
    public IImageEntry? BigPortrait { get; private set; }
    public IPlayerSelectionCursorEntry? Cursor { get; private set; }
    public IMovementStateEntry? RandomMove { get; private set; }
    public IImageEntry? Face { get; private set; }
    public ITextEntry? Name { get; private set; }
    public IPlayerSelectionTeamMenuEntry? MenuEntry { get; private set; }

    public override IPlayerSelectionEntry Read()
    {
        BigPortrait = Section?.GetValue<IImageEntry>(FieldKey);
        Cursor = Section?.GetValue<IPlayerSelectionCursorEntry>(FieldKey + ".cursor");
        RandomMove = Section?.GetValue<IMovementStateEntry>(FieldKey + ".random");
        Face = Section?.GetValue<IImageEntry>(FieldKey + ".face");
        Name = Section?.GetValue<ITextEntry>(FieldKey + ".name");
        MenuEntry = Section?.GetValue<IPlayerSelectionTeamMenuEntry>(FieldKey + ".teammenu");

        return this;
    }
}