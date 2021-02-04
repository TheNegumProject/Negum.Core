using Negum.Core.Configurations;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class ScrappedEntry<TEntry> : IScrapperEntry<TEntry>
        where TEntry : IScrapperEntry<TEntry>
    {
        protected IConfigurationScrapper Scrapper { get; set; }
        protected IConfigurationSection Section { get; set; }
        protected string KeyPrefix { get; set; }

        public virtual TEntry From(IConfigurationScrapper scrapper, IConfigurationSection section, string keyPrefix)
        {
            this.Scrapper = scrapper;
            this.Section = section;
            this.KeyPrefix = keyPrefix;

            return (TEntry) (IScrapperEntry<TEntry>) this;
        }
    }
}