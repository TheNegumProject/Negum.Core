namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Demo Mode.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDemoModeFightEntry : IScrapperEntry
    {
        /// <summary>
        /// Time to display the fight before returning to title.
        /// </summary>
        ITimeEntry EndTime => Scrapper.GetTime(this.KeyPrefix + ".endtime");

        /// <summary>
        /// Set to true to enable in-fight BGM, false to disable.
        /// </summary>
        bool PlayBackgroundMusic => Scrapper.GetBoolean(this.KeyPrefix + ".playbgm");

        /// <summary>
        /// Set to true to stop title BGM (only if playbgm = true).
        /// </summary>
        bool StopBackgroundMusic => Scrapper.GetBoolean(this.KeyPrefix + ".stopbgm");

        /// <summary>
        /// Set to true to display lifebar, false to disable.
        /// </summary>
        bool DisplayBars => Scrapper.GetBoolean(this.KeyPrefix + ".bars.display");
    }
}