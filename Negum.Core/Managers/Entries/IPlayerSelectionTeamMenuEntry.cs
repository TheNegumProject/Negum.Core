namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Player Team Menu entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuEntry : INegumManagerSectionEntry<IPlayerSelectionTeamMenuEntry>
    {
        IVectorEntry Position { get; }
        IImageEntry Background { get; }
        ITextEntry SelfTitle { get; }
        ITextEntry EnemyTitle { get; }
        IVectorEntry Move { get; }
        IPlayerSelectionTeamMenuItemEntry Item { get; }
        IPlayerSelectionTeamMenuValueEntry Value { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PlayerSelectionTeamMenuEntry : NegumManagerSectionEntry<IPlayerSelectionTeamMenuEntry>,
        IPlayerSelectionTeamMenuEntry
    {
        public IVectorEntry Position { get; private set; }
        public IImageEntry Background { get; private set; }
        public ITextEntry SelfTitle { get; private set; }
        public ITextEntry EnemyTitle { get; private set; }
        public IVectorEntry Move { get; private set; }
        public IPlayerSelectionTeamMenuItemEntry Item { get; private set; }
        public IPlayerSelectionTeamMenuValueEntry Value { get; private set; }

        public override IPlayerSelectionTeamMenuEntry Get()
        {
            this.Position = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".pos");
            this.Background = this.Section.GetValue<IImageEntry>(this.FieldKey + ".bg");
            this.SelfTitle = this.Section.GetValue<ITextEntry>(this.FieldKey + ".selftitle");
            this.EnemyTitle = this.Section.GetValue<ITextEntry>(this.FieldKey + ".enemytitle");
            this.Move = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".move");
            this.Item = this.Section.GetValue<IPlayerSelectionTeamMenuItemEntry>(this.FieldKey + ".item");
            this.Value = this.Section.GetValue<IPlayerSelectionTeamMenuValueEntry>(this.FieldKey + ".value");

            return this;
        }
    }
}