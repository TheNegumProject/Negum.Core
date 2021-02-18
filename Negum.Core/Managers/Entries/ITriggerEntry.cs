namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Trigger entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ITriggerEntry : INegumManagerSectionEntry<ITriggerEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class TriggerEntry : NegumManagerSectionEntry<ITriggerEntry>, ITriggerEntry
    {
        public override ITriggerEntry Get() => this;
    }
}