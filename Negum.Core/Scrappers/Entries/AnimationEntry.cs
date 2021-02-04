namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class AnimationEntry : ScrappedEntry<IAnimationEntry>, IAnimationEntry
    {
        public int Animation => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".anim");
    }
}