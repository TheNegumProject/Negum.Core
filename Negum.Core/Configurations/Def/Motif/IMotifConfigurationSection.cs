using System.Collections.Generic;
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
        /// <summary>
        /// Number of sections with the same name prefix but used for different things based on the postfix.
        /// </summary>
        IEnumerable<IMotifConfigurationSection> Subsections { get; }
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
        public IEnumerable<IMotifConfigurationSection> Subsections { get; } = new List<IMotifConfigurationSection>();

        protected override IMotifConfigurationSectionEntry GetEntry(string key) =>
            this.FirstOrDefault(entry => entry.Key.Equals(key));

        public void AddSubsection(IMotifConfigurationSection section)
        {
            ((List<IMotifConfigurationSection>) this.Subsections).Add(section);
        }
    }
}