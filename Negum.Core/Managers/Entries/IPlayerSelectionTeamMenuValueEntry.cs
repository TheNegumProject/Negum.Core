namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Player Team Menu Value entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuValueEntry : IManagerSectionEntry<IPlayerSelectionTeamMenuValueEntry>
    {
        IVectorEntry Sound { get; }
        IImageEntry Icon { get; }
        IImageEntry EmptyIcon { get; }
        IVectorEntry Spacing { get; }
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
        public IVectorEntry Sound { get; private set; }
        public IImageEntry Icon { get; private set; }
        public IImageEntry EmptyIcon { get; private set; }
        public IVectorEntry Spacing { get; private set; }

        public override IPlayerSelectionTeamMenuValueEntry Get()
        {
            this.Sound = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".snd");
            this.Icon = this.Section.GetValue<IImageEntry>(this.FieldKey + ".icon");
            this.EmptyIcon = this.Section.GetValue<IImageEntry>(this.FieldKey + ".empty.icon");
            this.Spacing = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".spacing");

            return this;
        }
    }
}