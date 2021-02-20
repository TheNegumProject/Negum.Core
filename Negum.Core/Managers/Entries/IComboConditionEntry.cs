namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Combo Condition entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IComboConditionEntry : IManagerSectionEntry<IComboConditionEntry>
    {
        // TODO: Design and implement how each "var" field should be handled in *.cmd file in single [State...] section.
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ComboConditionEntry : ManagerSectionEntry<IComboConditionEntry>, IComboConditionEntry
    {
        public override IComboConditionEntry Get() => this;
    }
}