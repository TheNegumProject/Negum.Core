namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Stage entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IStageSelectionEntry : IManagerSectionEntry<IStageSelectionEntry>
{
    IVectorEntry? Position { get; }
    ITextEntry? Active { get; }
    ITextEntry? Active2 { get; }
    ITextEntry? Done { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class StageSelectionEntry : ManagerSectionEntry<IStageSelectionEntry>, IStageSelectionEntry
{
    public IVectorEntry? Position { get; private set; }
    public ITextEntry? Active { get; private set; }
    public ITextEntry? Active2 { get; private set; }
    public ITextEntry? Done { get; private set; }

    public override IStageSelectionEntry Read()
    {
        Position = Section?.GetValue<IVectorEntry>(FieldKey + ".pos");
        Active = Section?.GetValue<ITextEntry>(FieldKey + ".active");
        Active2 = Section?.GetValue<ITextEntry>(FieldKey + ".active2");
        Done = Section?.GetValue<ITextEntry>(FieldKey + ".done");

        return this;
    }
}