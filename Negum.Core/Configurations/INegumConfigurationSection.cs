using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Represents single section in a configuration element.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationSection
    {
        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Value from the specified key; otherwise default value.</returns>
        TValue GetOrDefault<TValue>(string key, TValue defaultValue);

        /// <summary>
        /// Sets new value for the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <typeparam name="TValue"></typeparam>
        void SetNewValue<TValue>(string key, TValue newValue);

        /// <summary>
        /// </summary>
        /// <returns>Enumerable which contains all pairs of currently known elements.</returns>
        IEnumerable<KeyValuePair<string, object>> GetAll();
    }
}