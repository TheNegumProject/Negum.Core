namespace Negum.Core.Managers.Entries;

/// <summary>
/// Responsible for parsing single float value.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FloatEntry : ManagerSectionEntry<float>
{
    public override float Read() => float.Parse(Entry?.Value ?? string.Empty);
}