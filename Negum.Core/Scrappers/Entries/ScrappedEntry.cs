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
        public IConfigurationScrapper Scrapper { get; protected set; }
        public IConfigurationSection Section { get; protected set; }
        public string KeyPrefix { get; protected set; }

        public virtual TEntry Setup(IConfigurationScrapper scrapper, IConfigurationSection section, string keyPrefix)
        {
            this.Scrapper = scrapper;
            this.Section = section;
            this.KeyPrefix = keyPrefix;

            return (TEntry) (IScrapperEntry<TEntry>) this;
        }
    }
}