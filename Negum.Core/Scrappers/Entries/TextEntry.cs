namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class TextEntry : ScrappedEntry<ITextEntry>, ITextEntry
    {
        public IPositionEntry Offset => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".offset");
        public IFontEntry Font => this.Scrapper.GetFont(this.Section.Name, this.KeyPrefix + ".font");
        public IPositionEntry Spacing => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".spacing");
        public string Text => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".text");
    }
}