namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents general definition of an entry in a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public partial interface IConfigurationSectionEntry
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
    public partial class ConfigurationSectionEntry : IConfigurationSectionEntry
    {
        public string Key { get; internal set; }
        public string Value { get; internal set; }
    }
}