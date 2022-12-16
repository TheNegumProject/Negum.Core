namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Player Team Menu Value entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPlayerSelectionTeamMenuValueEntry : IManagerSectionEntry<IPlayerSelectionTeamMenuValueEntry>
{
    IVectorEntry? Sound { get; }
    IImageEntry? Icon { get; }
    IImageEntry? EmptyIcon { get; }
    IVectorEntry? Spacing { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PlayerSelectionTeamMenuValueEntry : ManagerSectionEntry<IPlayerSelectionTeamMenuValueEntry>,
    IPlayerSelectionTeamMenuValueEntry
{
    public IVectorEntry? Sound { get; private set; }
    public IImageEntry? Icon { get; private set; }
    public IImageEntry? EmptyIcon { get; private set; }
    public IVectorEntry? Spacing { get; private set; }

    public override IPlayerSelectionTeamMenuValueEntry Read()
    {
        Sound = Section?.GetValue<IVectorEntry>(FieldKey + ".snd");
        Icon = Section?.GetValue<IImageEntry>(FieldKey + ".icon");
        EmptyIcon = Section?.GetValue<IImageEntry>(FieldKey + ".empty.icon");
        Spacing = Section?.GetValue<IVectorEntry>(FieldKey + ".spacing");

        return this;
    }
}