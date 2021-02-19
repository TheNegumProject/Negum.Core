using System.Linq;

namespace Negum.Core.Configurations.Def
{
    /// <summary>
    /// Represents a definition of a DEF section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDefConfigurationSection : INegumConfigurationSection<IDefConfigurationSectionEntry>
    {
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class DefConfigurationSection : NegumConfigurationSection<IDefConfigurationSectionEntry>,
        IDefConfigurationSection
    {
        protected override IDefConfigurationSectionEntry GetEntry(string key) =>
            this.FirstOrDefault(entry => entry.Key.Equals(key));
    }
}