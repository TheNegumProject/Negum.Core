namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class ScrappedEntry : IScrapperEntry
    {
        public IConfigurationSectionScrapper Scrapper { get; protected set; }
        public string KeyPrefix { get; protected set; }

        public virtual IScrapperEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            this.Scrapper = scrapper;
            this.KeyPrefix = keyPrefix;
            return this;
        }
    }
}