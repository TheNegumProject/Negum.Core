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
        public IConfigurationSectionScrapper Scrapper { get; protected set; }
        public string KeyPrefix { get; protected set; }

        public virtual TEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            this.Scrapper = scrapper;
            this.KeyPrefix = keyPrefix;

            return (TEntry) (IScrapperEntry<TEntry>) this;
        }
    }
}