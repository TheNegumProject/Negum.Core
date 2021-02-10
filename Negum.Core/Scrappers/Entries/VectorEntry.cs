using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public string this[int index] => this.Values[index];

        private IList<string> Values { get; set; }

        public string RawValue { get; protected set; }

        public IVectorEntry From(string value)
        {
            this.RawValue = value;

            this.Values = this.RawValue
                .Replace(" ", "")
                .Split(",")
                .ToList();

            return this;
        }

        public override IVectorEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            base.Setup(scrapper, keyPrefix);
            return this.From(this.Scrapper.GetString(this.KeyPrefix));
        }

        public IEnumerator<string> GetEnumerator() => this.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}