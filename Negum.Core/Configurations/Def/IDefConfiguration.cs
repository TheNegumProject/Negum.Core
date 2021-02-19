namespace Negum.Core.Configurations.Def
{
    /// <summary>
    /// Represents a definition of a DEF configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDefConfiguration : INegumConfiguration<IDefConfigurationSection, IDefConfigurationSectionEntry>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class DefConfiguration : NegumConfiguration<IDefConfigurationSection, IDefConfigurationSectionEntry>,
        IDefConfiguration
    {
    }
}