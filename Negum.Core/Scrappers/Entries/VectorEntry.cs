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
        private string Value { get; set; }

        public IVectorEntry From(string value)
        {
            this.Value = Clean(value);
            return this;
        }

        public override IVectorEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            base.Setup(scrapper, keyPrefix);
            this.Value = Clean(this.Scrapper.GetString(this.KeyPrefix));
            return this;
        }

        private static string Clean(string value) => value.Replace(" ", "").Trim();
    }
}