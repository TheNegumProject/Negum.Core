namespace Negum.Core.Configurations.Def.Motif
{
    /// <summary>
    /// Represents a definition of a Motif entry in a section in configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMotifConfigurationSectionEntry : IDefConfigurationSectionEntry
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifConfigurationSectionEntry : DefConfigurationSectionEntry, IMotifConfigurationSectionEntry
    {
    }
}