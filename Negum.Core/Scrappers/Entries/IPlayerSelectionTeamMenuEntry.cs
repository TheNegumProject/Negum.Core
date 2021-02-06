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
        IPositionEntry Position => Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".pos");
        IImageEntry Background => Scrapper.GetImage(this.Section.Name, this.KeyPrefix + ".bg");
        ITextEntry SelfTitle => Scrapper.GetText(this.Section.Name, this.KeyPrefix + ".selftitle");
        ITextEntry EnemyTitle => Scrapper.GetText(this.Section.Name, this.KeyPrefix + ".enemytitle");
        ISoundEntry Move => Scrapper.GetSound(this.Section.Name, this.KeyPrefix + ".move");
        IPlayerSelectionTeamMenuItemEntry Item => Scrapper.GetPlayerSelectionTeamMenuItem(this.Section.Name, this.KeyPrefix + ".item");
        IPlayerSelectionTeamMenuValueEntry Value => Scrapper.GetPlayerSelectionTeamMenuValue(this.Section.Name, this.KeyPrefix + ".value");
    }
}