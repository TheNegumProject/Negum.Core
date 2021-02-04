using Negum.Core.Configurations;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class AudioEntry : IAudioEntry
    {
        private IConfigurationScrapper Scrapper { get; set; }
        private IConfigurationSection Section { get; set; }
        private string KeyPrefix { get; set; }

        public IFileEntry File => this.Scrapper.GetFile(this.Section.Name, this.KeyPrefix);
        public int Volume => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".volume");
        public bool Loop => this.Scrapper.GetBoolean(this.Section.Name, this.KeyPrefix + ".loop");
        public int LoopStart => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".loopstart");
        public int LoopEnd => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".loopend");

        public IAudioEntry From(
            IConfigurationScrapper scrapper,
            IConfigurationSection section,
            string keyPrefix)
        {
            this.Scrapper = scrapper;
            this.Section = section;
            this.KeyPrefix = keyPrefix;
            return this;
        }
    }
}