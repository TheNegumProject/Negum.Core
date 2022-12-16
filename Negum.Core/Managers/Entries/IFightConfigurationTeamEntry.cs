namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Fighting Team entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFightConfigurationTeamEntry : IManagerSectionEntry<IFightConfigurationTeamEntry>
{
    IVectorEntry? Position { get; }
    int? StartX { get; }
    ITextEntry? Counter { get; }
    ITextEntry? Text { get; }
    ITimeEntry? DisplayTime { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FightConfigurationTeamEntry : ManagerSectionEntry<IFightConfigurationTeamEntry>,
    IFightConfigurationTeamEntry
{
    public IVectorEntry? Position { get; private set; }
    public int? StartX { get; private set; }
    public ITextEntry? Counter { get; private set; }
    public ITextEntry? Text { get; private set; }
    public ITimeEntry? DisplayTime { get; private set; }

    public override IFightConfigurationTeamEntry Read()
    {
        Position = Section?.GetValue<IVectorEntry>(FieldKey + ".pos");
        StartX = Section?.GetValue<int>(FieldKey + ".start.x");
        Counter = Section?.GetValue<ITextEntry>(FieldKey + ".counter");
        Text = Section?.GetValue<ITextEntry>(FieldKey + ".text");
        DisplayTime = Section?.GetValue<ITimeEntry>(FieldKey + ".displaytime");

        return this;
    }
}