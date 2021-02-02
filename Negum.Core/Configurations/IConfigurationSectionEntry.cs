namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents single section entry.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationSectionEntry
    {
        /// <summary>
        /// Entry's key.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Entry's value.
        /// </summary>
        string Value { get; set; }
    }
}