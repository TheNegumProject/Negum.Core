namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class BoxEntry : ScrappedEntry<IBoxEntry>, IBoxEntry
    {
        public IPositionEntry Start => this.Scrapper.GetPosition(this.GetValue(0, 1));
        public IPositionEntry End => this.Scrapper.GetPosition(this.GetValue(2, 3));

        private string GetValue(int startIndex, int endIndex)
        {
            var value = this.Scrapper
                .GetString(this.Section.Name, this.KeyPrefix)
                .Replace(" ", "")
                .Trim();
            var parts = value.Split(",");
            return parts[startIndex] + "," + parts[endIndex];
        }
    }
}