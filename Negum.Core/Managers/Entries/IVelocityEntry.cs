namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Velocity entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IVelocityEntry : IManagerSectionEntry<IVelocityEntry>
    {
        IVectorEntry Forward { get; }
        IVectorEntry Backward { get; }
        IVectorEntry Neutral { get; }
        IVectorEntry Up { get; }
        IVectorEntry Down { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class VelocityEntry : ManagerSectionEntry<IVelocityEntry>, IVelocityEntry
    {
        public IVectorEntry Forward { get; private set; }
        public IVectorEntry Backward { get; private set; }
        public IVectorEntry Neutral { get; private set; }
        public IVectorEntry Up { get; private set; }
        public IVectorEntry Down { get; private set; }

        public override IVelocityEntry Get()
        {
            this.Forward = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".fwd");
            this.Backward = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".back");
            this.Neutral = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".neu");
            this.Up = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".up");
            this.Down = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".down");

            return this;
        }
    }
}