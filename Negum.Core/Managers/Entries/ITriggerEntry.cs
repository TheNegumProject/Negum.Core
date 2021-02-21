namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Trigger entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ITriggerEntry : IManagerSectionEntry<ITriggerEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class TriggerEntry : ManagerSectionEntry<ITriggerEntry>, ITriggerEntry
    {
        public override ITriggerEntry Get() => this;
    }
}