namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class KeysEntry : ScrappedEntry<IKeysEntry>, IKeysEntry
    {
        public int Jump => Scrapper.GetInt(this.Section.Name, "Jump");
        public int Crouch => Scrapper.GetInt(this.Section.Name, "Crouch");
        public int Left => Scrapper.GetInt(this.Section.Name, "Left");
        public int Right => Scrapper.GetInt(this.Section.Name, "Right");
        public int A => Scrapper.GetInt(this.Section.Name, "A");
        public int B => Scrapper.GetInt(this.Section.Name, "B");
        public int C => Scrapper.GetInt(this.Section.Name, "C");
        public int X => Scrapper.GetInt(this.Section.Name, "X");
        public int Y => Scrapper.GetInt(this.Section.Name, "Y");
        public int Z => Scrapper.GetInt(this.Section.Name, "Z");
        public int Start => Scrapper.GetInt(this.Section.Name, "Start");
    }
}