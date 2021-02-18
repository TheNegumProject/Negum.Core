namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Player Selection Cursor entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionCursorEntry : INegumManagerSectionEntry<IPlayerSelectionCursorEntry>
    {
        IVectorEntry StartCell { get; }
        IImageEntry Animation { get; }
        IMovementEntry Movement { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PlayerSelectionCursorEntry : NegumManagerSectionEntry<IPlayerSelectionCursorEntry>,
        IPlayerSelectionCursorEntry
    {
        public IVectorEntry StartCell { get; private set; }
        public IImageEntry Animation { get; private set; }
        public IMovementEntry Movement { get; private set; }

        public override IPlayerSelectionCursorEntry Get()
        {
            this.StartCell = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".startcell");
            this.Animation = this.Section.GetValue<IImageEntry>(this.FieldKey + ".active");
            this.Movement = this.Section.GetValue<IMovementEntry>(this.FieldKey);

            return this;
        }
    }
}