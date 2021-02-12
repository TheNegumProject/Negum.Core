namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>   
    public class CharacterEntry : ScrappedEntry, ICharacterEntry
    {
        public string Name { get; protected set; }
        public IFileEntry NameFile { get; protected set; }
        public IFileEntry StageFile { get; protected set; }
        public IFileEntry MusicFile { get; protected set; }
        public int IncludeStage { get; protected set; }
        public int Order { get; protected set; }
        public bool IsRandomSelect { get; protected set; }

        public override ICharacterEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            base.Setup(scrapper, keyPrefix);
            
            // TODO: Set values

            return this;
        }
    }
}