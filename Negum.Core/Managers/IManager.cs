using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;

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
    public interface IManager
    {
        /// <summary>
        /// Setups current Manager to use specified configuration.
        /// </summary>
        /// <param name="config"></param>
        /// <returns>Current manager.</returns>
        IManager UseConfiguration(IConfiguration config);

        /// <summary>
        /// </summary>
        /// <param name="sectionName">Name of the section to find.</param>
        /// <typeparam name="TManagerSection">Type of the searched section.</typeparam>
        /// <returns>Parsed found section.</returns>
        TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : IManagerSection;

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <typeparam name="TManagerSection"></typeparam>
        /// <returns>Collection of subsections from the current section.</returns>
        IEnumerable<TManagerSection> GetSubsections<TManagerSection>(string sectionName)
            where TManagerSection : IManagerSection;
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class Manager : IManager
    {
        /// <summary>
        /// Contains sections already used.
        /// Mainly used to increase performance.
        /// </summary>
        private IDictionary<string, IManagerSection> Sections { get; } =
            new Dictionary<string, IManagerSection>();

        protected IConfiguration Config { get; set; }

        public IManager UseConfiguration(IConfiguration config)
        {
            this.Config = config;
            return this;
        }

        public TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : IManagerSection
        {
            var section = this.Config[sectionName];

            if (!this.Sections.ContainsKey(sectionName))
            {
                var managerSection = this.GetNewManagerSection(sectionName, section);
                this.Sections.Add(sectionName, managerSection);
            }

            return (TManagerSection) this.Sections[sectionName];
        }

        public IEnumerable<TManagerSection> GetSubsections<TManagerSection>(string sectionName)
            where TManagerSection : IManagerSection =>
            this.Config[sectionName].Subsections
                .Select(subsection => (TManagerSection) this.GetNewManagerSection(subsection.Name, subsection))
                .ToList();

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="configSection"></param>
        /// <returns>Returns related Manager's Section.</returns>
        protected abstract IManagerSection GetNewManagerSection(string sectionName,
            IConfigurationSection configSection);
    }
}