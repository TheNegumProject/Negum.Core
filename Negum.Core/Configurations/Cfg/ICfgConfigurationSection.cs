using System.Linq;

namespace Negum.Core.Configurations.Cfg
{
    /// <summary>
    /// Represents a definition of a CFG section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICfgConfigurationSection : INegumConfigurationSection<ICfgConfigurationSectionEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CfgConfigurationSection : NegumConfigurationSection<ICfgConfigurationSectionEntry>,
        ICfgConfigurationSection
    {
        protected override ICfgConfigurationSectionEntry GetEntry(string key) =>
            this.FirstOrDefault(entry => entry.Key.Equals(key));
    }
}