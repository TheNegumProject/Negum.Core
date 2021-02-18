namespace Negum.Core.Configurations.Cfg
{
    /// <summary>
    /// Represents a definition of a CFG configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICfgConfiguration : INegumConfiguration<ICfgConfigurationSection, ICfgConfigurationSectionEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CfgConfiguration : NegumConfiguration<ICfgConfigurationSection, ICfgConfigurationSectionEntry>,
        ICfgConfiguration
    {
    }
}