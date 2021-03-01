namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Movement State entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMovementStateEntry : IManagerSectionEntry<IMovementStateEntry>
    {
        ISpriteSoundEntry Move { get; }
        ISpriteSoundEntry Done { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MovementStateEntry : ManagerSectionEntry<IMovementStateEntry>, IMovementStateEntry
    {
        public ISpriteSoundEntry Move { get; private set; }
        public ISpriteSoundEntry Done { get; private set; }

        public override IMovementStateEntry Get()
        {
            this.Move = this.Section.GetValue<ISpriteSoundEntry>(this.FieldKey + ".move");
            this.Done = this.Section.GetValue<ISpriteSoundEntry>(this.FieldKey + ".done");

            return this;
        }
    }
}