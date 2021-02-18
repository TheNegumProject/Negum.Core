namespace Negum.Core.Managers
{
    /// <summary>
    /// Root manager definition.
    /// Managers are objects which wraps around configuration, and are used to easier interact with known fields.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumManager
    {
        /// <summary>
        /// </summary>
        /// <param name="sectionName">Name of the section to find.</param>
        /// <typeparam name="TManagerSection">Type of the searched section.</typeparam>
        /// <returns>Parsed found section.</returns>
        TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : INegumManagerSection;
    }
}