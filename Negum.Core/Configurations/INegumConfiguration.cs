namespace Negum.Core.Configurations
{
    /// <summary>
    /// Entry point for the configuration section of the engine.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfiguration
    {
        /// <summary>
        /// Represents settings part of the configuration.
        /// </summary>
        INegumSettings Settings { get; }
        /// <summary>
        /// Represents the selection part of the configuration.
        /// </summary>
        INegumSelection Selection { get; }
        /// <summary>
        /// Represents the system part of the configuration.
        /// </summary>
        INegumSystem System { get; }
    }
}
