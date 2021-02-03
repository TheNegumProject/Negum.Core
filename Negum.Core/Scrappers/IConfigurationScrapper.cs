using Negum.Core.Configurations;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// Scraps over specified configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationScrapper
    {
        /// <summary>
        /// Sets configuration which should be scrapped.
        /// </summary>
        /// <typeparam name="TConfiguration"></typeparam>
        /// <returns>Returns this scrapper.</returns>
        IConfigurationScrapper Use<TConfiguration>() where TConfiguration : IConfigurationDefinition;

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Integer value from selected configuration.</returns>
        int GetInt(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Float  value from selected configuration.</returns>
        float GetFloat(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Boolean value from selected configuration.</returns>
        bool GetBoolean(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>String value from selected configuration.</returns>
        string GetString(string sectionName, string fieldKey);
    }
}