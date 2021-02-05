namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Keys.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IKeysEntry : IScrapperEntry<IKeysEntry>
    {
        int Jump => Scrapper.GetInt(this.Section.Name, "Jump");
        int Crouch => Scrapper.GetInt(this.Section.Name, "Crouch");
        int Left => Scrapper.GetInt(this.Section.Name, "Left");
        int Right => Scrapper.GetInt(this.Section.Name, "Right");
        int A => Scrapper.GetInt(this.Section.Name, "A");
        int B => Scrapper.GetInt(this.Section.Name, "B");
        int C => Scrapper.GetInt(this.Section.Name, "C");
        int X => Scrapper.GetInt(this.Section.Name, "X");
        int Y => Scrapper.GetInt(this.Section.Name, "Y");
        int Z => Scrapper.GetInt(this.Section.Name, "Z");
        int Start => Scrapper.GetInt(this.Section.Name, "Start");
    }
}