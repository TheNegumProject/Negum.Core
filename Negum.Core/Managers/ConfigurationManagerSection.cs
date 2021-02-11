using System.Collections.Generic;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationManagerSection : IConfigurationManagerSection
    {
        private IConfigurationManager Manager { get; set; }

        public IConfigurationSectionScrapper Scrapper { get; protected set; }
        public string SectionName { get; protected set; }

        public IConfigurationManagerSection Setup(IConfigurationManager manager, IConfigurationSectionScrapper scrapper,
            string sectionName)
        {
            this.Manager = manager;
            this.Scrapper = scrapper;
            this.SectionName = sectionName;
            return this;
        }

        public IEnumerable<IConfigurationManagerSection> GetActions() => 
            this.Manager.GetInnerSections(this, "Begin Action ");
    }
}