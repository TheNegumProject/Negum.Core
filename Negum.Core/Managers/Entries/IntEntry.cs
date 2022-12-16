namespace Negum.Core.Managers.Entries;

/// <summary>
/// Responsible for parsing single int value.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class IntEntry : ManagerSectionEntry<int>
{
    public override int Read() => int.Parse(Entry?.Value ?? int.MaxValue.ToString());
}