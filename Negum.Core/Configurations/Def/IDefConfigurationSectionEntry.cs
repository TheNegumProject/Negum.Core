namespace Negum.Core.Configurations.Def
{
    /// <summary>
    /// Represents a definition of a DEF entry in a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDefConfigurationSectionEntry : INegumConfigurationSectionEntry
    {
        /// <summary>
        /// Entry's key.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Entry's value.
        /// </summary>
        string Value { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class DefConfigurationSectionEntry : NegumConfigurationSectionEntry, IDefConfigurationSectionEntry
    {
        public string Key { get; internal set; }
        public string Value { get; internal set; }
    }
}