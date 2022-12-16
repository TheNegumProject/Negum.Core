namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Keys entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IKeysEntry : IManagerSectionEntry<IKeysEntry>
{
    int? Jump { get; }
    int? Crouch { get; }
    int? Left { get; }
    int? Right { get; }
    int? A { get; }
    int? B { get; }
    int? C { get; }
    int? X { get; }
    int? Y { get; }
    int? Z { get; }
    int? Start { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class KeysEntry : ManagerSectionEntry<IKeysEntry>, IKeysEntry
{
    public int? Jump { get; private set; }
    public int? Crouch { get; private set; }
    public int? Left { get; private set; }
    public int? Right { get; private set; }
    public int? A { get; private set; }
    public int? B { get; private set; }
    public int? C { get; private set; }
    public int? X { get; private set; }
    public int? Y { get; private set; }
    public int? Z { get; private set; }
    public int? Start { get; private set; }

    public override IKeysEntry Read()
    {
        Jump = Section?.GetValue<int>("Jump");
        Crouch = Section?.GetValue<int>("Crouch");
        Left = Section?.GetValue<int>("Left");
        Right = Section?.GetValue<int>("Right");
        A = Section?.GetValue<int>("A");
        B = Section?.GetValue<int>("B");
        C = Section?.GetValue<int>("C");
        X = Section?.GetValue<int>("X");
        Y = Section?.GetValue<int>("Y");
        Z = Section?.GetValue<int>("Z");
        Start = Section?.GetValue<int>("Start");

        return this;
    }
}