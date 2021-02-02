using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Object which contains key-value pairs of data.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationSection
    {
        /// <summary>
        /// Allows for easy accessing entries.
        /// </summary>
        /// <param name="key"></param>
        string this[string key] { get; set; }
        
        /// <summary>
        /// Contains all read entries.
        /// </summary>
        ICollection<IConfigurationSectionEntry> Entries { get; }
    }
}