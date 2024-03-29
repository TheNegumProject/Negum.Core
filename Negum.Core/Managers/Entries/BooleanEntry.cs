namespace Negum.Core.Managers.Entries;

/// <summary>
/// Responsible for parsing single boolean value.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class BooleanEntry : ManagerSectionEntry<bool>
{
    public override bool Read() =>
        Entry?.Value switch
        {
            "0" => false,
            "1" => true,
            _ => bool.Parse(Entry?.Value ?? string.Empty)
        };
}