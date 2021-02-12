namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Keys.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IKeysEntry : IScrapperEntry
    {
        int Jump => Scrapper.GetInt("Jump");
        int Crouch => Scrapper.GetInt("Crouch");
        int Left => Scrapper.GetInt("Left");
        int Right => Scrapper.GetInt("Right");
        int A => Scrapper.GetInt("A");
        int B => Scrapper.GetInt("B");
        int C => Scrapper.GetInt("C");
        int X => Scrapper.GetInt("X");
        int Y => Scrapper.GetInt("Y");
        int Z => Scrapper.GetInt("Z");
        int Start => Scrapper.GetInt("Start");
    }
}