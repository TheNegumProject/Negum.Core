namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Player Selection entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionEntry : IManagerSectionEntry<IPlayerSelectionEntry>
    {
        IImageEntry BigPortrait { get; }
        IPlayerSelectionCursorEntry Cursor { get; }
        IMovementStateEntry RandomMove { get; }
        IImageEntry Face { get; }
        ITextEntry Name { get; }
        IPlayerSelectionTeamMenuEntry MenuEntry { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PlayerSelectionEntry : ManagerSectionEntry<IPlayerSelectionEntry>, IPlayerSelectionEntry
    {
        public IImageEntry BigPortrait { get; private set; }
        public IPlayerSelectionCursorEntry Cursor { get; private set; }
        public IMovementStateEntry RandomMove { get; private set; }
        public IImageEntry Face { get; private set; }
        public ITextEntry Name { get; private set; }
        public IPlayerSelectionTeamMenuEntry MenuEntry { get; private set; }

        public override IPlayerSelectionEntry Get()
        {
            this.BigPortrait = this.Section.GetValue<IImageEntry>(this.FieldKey);
            this.Cursor = this.Section.GetValue<IPlayerSelectionCursorEntry>(this.FieldKey + ".cursor");
            this.RandomMove = this.Section.GetValue<IMovementStateEntry>(this.FieldKey + ".random");
            this.Face = this.Section.GetValue<IImageEntry>(this.FieldKey + ".face");
            this.Name = this.Section.GetValue<ITextEntry>(this.FieldKey + ".name");
            this.MenuEntry = this.Section.GetValue<IPlayerSelectionTeamMenuEntry>(this.FieldKey + ".teammenu");

            return this;
        }
    }
}