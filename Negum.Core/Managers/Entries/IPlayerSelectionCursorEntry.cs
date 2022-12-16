namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Player Selection Cursor entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPlayerSelectionCursorEntry : IManagerSectionEntry<IPlayerSelectionCursorEntry>
{
    IVectorEntry? StartCell { get; }
    IImageEntry? Animation { get; }
    IMovementStateEntry? MovementState { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PlayerSelectionCursorEntry : ManagerSectionEntry<IPlayerSelectionCursorEntry>,
    IPlayerSelectionCursorEntry
{
    public IVectorEntry? StartCell { get; private set; }
    public IImageEntry? Animation { get; private set; }
    public IMovementStateEntry? MovementState { get; private set; }

    public override IPlayerSelectionCursorEntry Read()
    {
        StartCell = Section?.GetValue<IVectorEntry>(FieldKey + ".startcell");
        Animation = Section?.GetValue<IImageEntry>(FieldKey + ".active");
        MovementState = Section?.GetValue<IMovementStateEntry>(FieldKey);

        return this;
    }
}