using System.Collections.Generic;
using System.Linq;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfigurationSection : INegumConfigurationSection
    {
        private IDictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public TValue GetOrDefault<TValue>(string key, TValue defaultValue)
        {
            if (!this.Values.ContainsKey(key))
            {
                this.SetNewValue(key, defaultValue);
            }

            return (TValue) this.Values[key];
        }

        public void SetNewValue<TValue>(string key, TValue newValue) =>
            this.Values[key] = newValue;

        public IEnumerable<KeyValuePair<string, object>> GetAll() =>
            this.Values.ToList();
    }
}