namespace Negum.Core.Configurations.Def.Motif
{
    /// <summary>
    /// Represents a definition of a Motif configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMotifConfiguration :
        INegumConfiguration<IMotifConfigurationSection, IMotifConfigurationSectionEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifConfiguration : NegumConfiguration<IMotifConfigurationSection, IMotifConfigurationSectionEntry>,
        IMotifConfiguration
    {
    }
}