namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Movement entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMovementEntry : IManagerSectionEntry<IMovementEntry>
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
    public class MovementEntry : ManagerSectionEntry<IMovementEntry>, IMovementEntry
    {
        public ISpriteSoundEntry Move { get; private set; }
        public ISpriteSoundEntry Done { get; private set; }

        public override IMovementEntry Get()
        {
            this.Move = this.Section.GetValue<ISpriteSoundEntry>(this.FieldKey + ".move");
            this.Done = this.Section.GetValue<ISpriteSoundEntry>(this.FieldKey + ".done");

            return this;
        }
    }
}