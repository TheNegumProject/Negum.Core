namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Player Team Menu Item entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPlayerSelectionTeamMenuItemEntry : IManagerSectionEntry<IPlayerSelectionTeamMenuItemEntry>
{
    ITextEntry? Item { get; }
    IVectorEntry? Active { get; }
    IVectorEntry? Active2 { get; }
    IImageEntry? Cursor { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PlayerSelectionTeamMenuItemEntry : ManagerSectionEntry<IPlayerSelectionTeamMenuItemEntry>,
    IPlayerSelectionTeamMenuItemEntry
{
    public ITextEntry? Item { get; private set; }
    public IVectorEntry? Active { get; private set; }
    public IVectorEntry? Active2 { get; private set; }
    public IImageEntry? Cursor { get; private set; }

    public override IPlayerSelectionTeamMenuItemEntry Read()
    {
        Item = Section?.GetValue<ITextEntry>(FieldKey);
        Active = Section?.GetValue<IVectorEntry>(FieldKey + ".active");
        Active2 = Section?.GetValue<IVectorEntry>(FieldKey + ".active2");
        Cursor = Section?.GetValue<IImageEntry>(FieldKey + ".cursor");

        return this;
    }
}