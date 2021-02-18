namespace Negum.Core.Configurations.Cfg
{
    /// <summary>
    /// Represents a definition of a CFG entry in a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICfgConfigurationSectionEntry : INegumConfigurationSectionEntry
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
    public class CfgConfigurationSectionEntry : NegumConfigurationSectionEntry, ICfgConfigurationSectionEntry
    {
        public string Key { get; internal set; }
        public string Value { get; internal set; }
    }
}