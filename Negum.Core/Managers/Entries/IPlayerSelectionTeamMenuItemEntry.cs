namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Player Team Menu Item entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuItemEntry : INegumManagerSectionEntry<IPlayerSelectionTeamMenuItemEntry>
    {
        ITextEntry Item { get; }
        IVectorEntry Active { get; }
        IVectorEntry Active2 { get; }
        IImageEntry Cursor { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PlayerSelectionTeamMenuItemEntry : NegumManagerSectionEntry<IPlayerSelectionTeamMenuItemEntry>,
        IPlayerSelectionTeamMenuItemEntry
    {
        public ITextEntry Item { get; private set; }
        public IVectorEntry Active { get; private set; }
        public IVectorEntry Active2 { get; private set; }
        public IImageEntry Cursor { get; private set; }

        public override IPlayerSelectionTeamMenuItemEntry Get()
        {
            this.Item = this.Section.GetValue<ITextEntry>(this.FieldKey);
            this.Active = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".active");
            this.Active2 = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".active2");
            this.Cursor = this.Section.GetValue<IImageEntry>(this.FieldKey + ".cursor");

            return this;
        }
    }
}