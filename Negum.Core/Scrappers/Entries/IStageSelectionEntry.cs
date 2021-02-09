namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Stage.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageSelectionEntry : IScrapperEntry<IStageSelectionEntry>
    {
        IVectorEntry Position => Scrapper.GetVector(this.KeyPrefix + ".pos");
        ITextEntry Active => Scrapper.GetText(this.KeyPrefix + ".active");
        ITextEntry Active2 => Scrapper.GetText(this.KeyPrefix + ".active2");
        ITextEntry Done => Scrapper.GetText(this.KeyPrefix + ".done");
    }
}