using System.Collections.Generic;
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
        /// </summary>
        /// <param name="sectionName">Name of the section to find.</param>
        /// <typeparam name="TManagerSection">Type of the searched section.</typeparam>
        /// <returns>Parsed found section.</returns>
        TManagerSection GetSection<TManagerSection>(string sectionName)
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

        protected IConfiguration Config { get; }

        public Manager(IConfiguration config)
        {
            this.Config = config;
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

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="configSection"></param>
        /// <returns>Returns related Manager's Section.</returns>
        protected abstract IManagerSection GetNewManagerSection(string sectionName,
            IConfigurationSection configSection);
    }
}