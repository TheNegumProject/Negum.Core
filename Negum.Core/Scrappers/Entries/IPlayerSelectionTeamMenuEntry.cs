namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player Team Menu.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuEntry : IScrapperEntry<IPlayerSelectionTeamMenuEntry>
    {
        IPositionEntry Position => Scrapper.GetPosition(this.KeyPrefix + ".pos");
        IImageEntry Background => Scrapper.GetImage(this.KeyPrefix + ".bg");
        ITextEntry SelfTitle => Scrapper.GetText(this.KeyPrefix + ".selftitle");
        ITextEntry EnemyTitle => Scrapper.GetText(this.KeyPrefix + ".enemytitle");
        ISoundEntry Move => Scrapper.GetSound(this.KeyPrefix + ".move");
        IPlayerSelectionTeamMenuItemEntry Item => Scrapper.GetPlayerSelectionTeamMenuItem(this.KeyPrefix + ".item");
        IPlayerSelectionTeamMenuValueEntry Value => Scrapper.GetPlayerSelectionTeamMenuValue(this.KeyPrefix + ".value");
    }
}