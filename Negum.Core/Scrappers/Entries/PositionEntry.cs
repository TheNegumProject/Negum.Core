using Negum.Core.Configurations;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PositionEntry : ScrappedEntry<IPositionEntry>, IPositionEntry
    {
        private string Value { get; set; }

        public float X => this.GetValue(0);
        public float y => this.GetValue(1);

        public IPositionEntry From(string value)
        {
            this.Value = value;
            return this;
        }

        public override IPositionEntry From(IConfigurationScrapper scrapper, IConfigurationSection section,
            string keyPrefix)
        {
            base.From(scrapper, section, keyPrefix);

            this.Value = this.Scrapper
                .GetString(this.Section.Name, this.KeyPrefix)
                .Replace(" ", "")
                .Trim();

            return this;
        }

        private float GetValue(int index)
        {
            var parts = this.Value.Split(",");
            return float.Parse(parts[index]);
        }
    }
}