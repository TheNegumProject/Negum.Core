using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationScrapper : IConfigurationScrapper
    {
        private IConfigurationDefinition ConfigDef { get; set; }

        public IConfigurationScrapper Setup(IConfigurationDefinition def)
        {
            this.ConfigDef = def;
            return this;
        }

        public IConfigurationSectionScrapper ForSection(string sectionName) =>
            NegumContainer.Resolve<IConfigurationSectionScrapper>().Setup(this.ConfigDef[sectionName]);
    }
}