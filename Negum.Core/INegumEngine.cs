using Negum.Core.Configurations;

namespace Negum.Core
{
    /// <summary>
    /// Entry point for the whole Negum system.
    /// Contains entries and functionality for all parts of Negum.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumEngine
    {
        /// <summary>
        /// Represents configuration read from files.
        /// </summary>
        INegumConfiguration Configuration { get; }
    }
}
