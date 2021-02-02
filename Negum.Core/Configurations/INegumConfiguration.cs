namespace Negum.Core.Configurations
{
    /// <summary>
    /// Core configuration used by Negum to determine motif, system, select, etc.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfiguration : IConfigurationDefinition
    {
        /// <summary>
        /// Indicates whether the configuration was already read.
        /// </summary>
        bool IsInitialized { get; set; }
    }
}