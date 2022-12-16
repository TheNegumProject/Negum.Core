namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Trigger entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ITriggerEntry : IManagerSectionEntry<ITriggerEntry>
{
    /// <summary>
    /// True if current trigger is of type "triggerall"; false otherwise.
    /// </summary>
    bool? IsTriggerAll { get; }
        
    /// <summary>
    /// Raw name value of this trigger.
    /// i.e.: "triggerall", "trigger", "trigger3", "trigger29", etc.
    /// </summary>
    string? NameRaw { get; }
        
    /// <summary>
    /// Represents a raw version of expression of this trigger.
    /// </summary>
    string? ExpressionRaw { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class TriggerEntry : ManagerSectionEntry<ITriggerEntry>, ITriggerEntry
{
    public const string TriggerAllKey = "triggerall";
    public const string TriggerKey = "trigger";

    public bool? IsTriggerAll => Entry?.Key.Equals(TriggerAllKey);
    public string? NameRaw => Entry?.Key;
    public string? ExpressionRaw => Entry?.Value;
        
    public override ITriggerEntry Read() => this;
}