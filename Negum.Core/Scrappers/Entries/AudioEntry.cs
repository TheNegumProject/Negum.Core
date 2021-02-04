namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class AudioEntry : ScrappedEntry<IAudioEntry>, IAudioEntry
    {
        public IFileEntry File => this.Scrapper.GetFile(this.Section.Name, this.KeyPrefix);
        public int Volume => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".volume");
        public bool Loop => this.Scrapper.GetBoolean(this.Section.Name, this.KeyPrefix + ".loop");
        public int LoopStart => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".loopstart");
        public int LoopEnd => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".loopend");
    }
}