namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Velocity entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IVelocityEntry : IManagerSectionEntry<IVelocityEntry>
{
    IVectorEntry? Forward { get; }
    IVectorEntry? Backward { get; }
    IVectorEntry? Neutral { get; }
    IVectorEntry? Up { get; }
    IVectorEntry? Down { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class VelocityEntry : ManagerSectionEntry<IVelocityEntry>, IVelocityEntry
{
    public IVectorEntry? Forward { get; private set; }
    public IVectorEntry? Backward { get; private set; }
    public IVectorEntry? Neutral { get; private set; }
    public IVectorEntry? Up { get; private set; }
    public IVectorEntry? Down { get; private set; }

    public override IVelocityEntry Read()
    {
        Forward = Section?.GetValue<IVectorEntry>(FieldKey + ".fwd");
        Backward = Section?.GetValue<IVectorEntry>(FieldKey + ".back");
        Neutral = Section?.GetValue<IVectorEntry>(FieldKey + ".neu");
        Up = Section?.GetValue<IVectorEntry>(FieldKey + ".up");
        Down = Section?.GetValue<IVectorEntry>(FieldKey + ".down");

        return this;
    }
}