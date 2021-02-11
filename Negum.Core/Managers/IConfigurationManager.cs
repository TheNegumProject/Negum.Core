using System.Collections.Generic;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager allows for easier interaction with ConfigurationDefinition's known fields.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationManager
    {
        /// <summary>
        /// ASetups Manager.
        /// </summary>
        /// <param name="scrapper"></param>
        /// <returns>Current Manager.</returns>
        IConfigurationManager Setup(IConfigurationScrapper scrapper);

        /// <summary>
        /// </summary>
        /// <param name="sectionName">Name of the section to find.</param>
        /// <typeparam name="TManagerSection">Type of the searched section.</typeparam>
        /// <returns>Parsed found section.</returns>
        TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : IConfigurationManagerSection;

        /// <summary>
        /// </summary>
        /// <param name="sectionNamePrefix"></param>
        /// <typeparam name="TManagerSection"></typeparam>
        /// <returns>Collection of sections which name starts from the given prefix.</returns>
        IEnumerable<TManagerSection> GetSections<TManagerSection>(string sectionNamePrefix)
            where TManagerSection : IConfigurationManagerSection;

        /// <summary>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="innerSectionsPrefix"></param>
        /// <typeparam name="TManagerSection"></typeparam>
        /// <returns>Sections which names starts from the specified name which are directly after the specified section</returns>
        IEnumerable<IConfigurationManagerSection> GetInnerSections(IConfigurationManagerSection parent,
            string innerSectionsPrefix);
    }
}