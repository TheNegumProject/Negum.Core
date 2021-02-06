namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Cell.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICellSelectionEntry : IScrapperEntry<ICellSelectionEntry>
    {
        /// <summary>
        /// (x,y) size of each cell in pixels.
        /// </summary>
        IPositionEntry CellSize => Scrapper.GetPosition(this.KeyPrefix + ".size");
        
        /// <summary>
        /// Space between each cell.
        /// </summary>
        int CellSpacing => Scrapper.GetInt(this.KeyPrefix + ".spacing");
        
        ISpriteSoundEntry CellBg => Scrapper.GetSpriteSound(this.KeyPrefix + ".bg");
        
        /// <summary>
        /// Icon for random select.
        /// </summary>
        ISpriteSoundEntry CellRandom => Scrapper.GetSpriteSound(this.KeyPrefix + ".random");
        
        /// <summary>
        /// Time to wait before changing to another random portrait.
        /// </summary>
        string CellRandomSwitchTime => Scrapper.GetString(this.KeyPrefix + ".random.switchtime");
    }
}