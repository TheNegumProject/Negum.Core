using System.Linq;

namespace Negum.Core.Configurations.Def.Motif
{
    /// <summary>
    /// Represents a definition of a Motif section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMotifConfigurationSection : INegumConfigurationSection<IMotifConfigurationSectionEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifConfigurationSection : NegumConfigurationSection<IMotifConfigurationSectionEntry>,
        IMotifConfigurationSection
    {
        protected override IMotifConfigurationSectionEntry GetEntry(string key) =>
            this.FirstOrDefault(entry => entry.Key.Equals(key));
    }
}