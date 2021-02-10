namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class VectorEntry : ScrappedEntry<IVectorEntry>, IVectorEntry
    {
        public string RawValue { get; protected set; }

        public IVectorEntry From(string value)
        {
            this.RawValue = Clean(value);
            return this;
        }

        public override IVectorEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            base.Setup(scrapper, keyPrefix);
            this.RawValue = Clean(this.Scrapper.GetString(this.KeyPrefix));
            return this;
        }

        private static string Clean(string value) => value.Replace(" ", "").Trim();
    }
}