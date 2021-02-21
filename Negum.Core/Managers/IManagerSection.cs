using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Root manager's section definition.
    /// Sections are what configurations are divided by.
    /// It represent single area of configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IManagerSection
    {
        /// <summary>
        /// Name of the current section.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>Value parsed to specified type</returns>
        TValue GetValue<TValue>(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>Collection of values with the specified key.</returns>
        IEnumerable<TValue> GetValues<TValue>(string fieldKey);

        /// <summary>
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>All entries of current section.</returns>
        IEnumerable<TValue> GetAll<TValue>();
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class ManagerSection : IManagerSection
    {
        private IConfigurationSection Section { get; }

        public string Name { get; }

        public ManagerSection(string name, IConfigurationSection section)
        {
            this.Name = name;
            this.Section = section;
        }

        public TValue GetValue<TValue>(string fieldKey) =>
            this.GetValues<TValue>(fieldKey).FirstOrDefault();

        public IEnumerable<TValue> GetValues<TValue>(string fieldKey)
        {
            if (string.IsNullOrWhiteSpace(fieldKey))
            {
                return this.GetAll<TValue>();
            }
            
            var sections = this.Section
                .Where(sectionEntry => sectionEntry.Key.Equals(fieldKey));

            return this.InitializeEntries<TValue>(sections);
        }

        public IEnumerable<TValue> GetAll<TValue>() =>
            this.InitializeEntries<TValue>(this.Section);

        protected virtual IEnumerable<TValue>
            InitializeEntries<TValue>(IEnumerable<IConfigurationSectionEntry> entries) =>
            entries
                .Select(sectionEntry =>
                {
                    var entry = NegumContainer.Resolve<IManagerSectionEntry<TValue>>();
                    entry.Initialize(this, string.Empty, sectionEntry);
                    return entry.Get();
                })
                .ToList();
    }
}