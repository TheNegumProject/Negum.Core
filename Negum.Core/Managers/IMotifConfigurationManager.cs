using System;
using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Motif configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMotifConfigurationManager : IConfigurationManager<IMotifConfigurationManager>
    {
        public IMotifConfigurationInfo Info =>
            NegumContainer.Resolve<IMotifConfigurationInfo>().Setup(this.Scrapper, "Info");

        public IMotifConfigurationFiles Files =>
            NegumContainer.Resolve<IMotifConfigurationFiles>().Setup(this.Scrapper, "Files");

        public IMotifConfigurationMusic Music =>
            NegumContainer.Resolve<IMotifConfigurationMusic>().Setup(this.Scrapper, "Music");

        public IMotifConfigurationTitleInfo TitleInfo => 
            NegumContainer.Resolve<IMotifConfigurationTitleInfo>().Setup(this.Scrapper, "Title Info");

        public IMotifConfigurationTitleBgDef TitleBgDef => 
            NegumContainer.Resolve<IMotifConfigurationTitleBgDef>().Setup(this.Scrapper, "TitleBGdef");

        public IMotifConfigurationInfobox Infobox =>
            NegumContainer.Resolve<IMotifConfigurationInfobox>().Setup(this.Scrapper, "Infobox");

        public IMotifConfigurationSelectInfo SelectInfo => 
            NegumContainer.Resolve<IMotifConfigurationSelectInfo>().Setup(this.Scrapper, "Select Info");

        public IMotifConfigurationSelectBgDef SelectBgDef => 
            NegumContainer.Resolve<IMotifConfigurationSelectBgDef>().Setup(this.Scrapper, "SelectBGdef");

        public IMotifConfigurationVsScreen VsScreen =>
            NegumContainer.Resolve<IMotifConfigurationVsScreen>().Setup(this.Scrapper, "VS Screen");

        public IMotifConfigurationVsBgDef VsBgDef =>
            NegumContainer.Resolve<IMotifConfigurationVsBgDef>().Setup(this.Scrapper, "VersusBGdef");

        public IMotifConfigurationDemoMode DemoMode =>
            NegumContainer.Resolve<IMotifConfigurationDemoMode>().Setup(this.Scrapper, "Demo Mode");

        public IMotifConfigurationContinueScreen ContinueScreen => 
            NegumContainer.Resolve<IMotifConfigurationContinueScreen>().Setup(this.Scrapper, "Continue Screen");

        public IMotifConfigurationGameOverScreen GameOverScreen => 
            NegumContainer.Resolve<IMotifConfigurationGameOverScreen>().Setup(this.Scrapper, "Game Over Screen");

        public IMotifConfigurationVictoryScreen VictoryScreen => 
            NegumContainer.Resolve<IMotifConfigurationVictoryScreen>().Setup(this.Scrapper, "Victory Screen");

        public IMotifConfigurationWinScreen WinScreen => 
            NegumContainer.Resolve<IMotifConfigurationWinScreen>().Setup(this.Scrapper, "Win Screen");

        public IMotifConfigurationDefaultEnding DefaultEnding => 
            NegumContainer.Resolve<IMotifConfigurationDefaultEnding>().Setup(this.Scrapper, "Default Ending");

        public IMotifConfigurationEndCredits EndCredits => 
            NegumContainer.Resolve<IMotifConfigurationEndCredits>().Setup(this.Scrapper, "End Credits");

        public IMotifConfigurationSurvivalResultsScreen SurvivalResultsScreen => 
            NegumContainer.Resolve<IMotifConfigurationSurvivalResultsScreen>().Setup(this.Scrapper, "Survival Results Screen");

        public IMotifConfigurationOptionInfo OptionInfo => 
            NegumContainer.Resolve<IMotifConfigurationOptionInfo>().Setup(this.Scrapper, "Option Info");
    }

    public interface IMotifConfigurationInfo : IConfigurationManagerSection<IMotifConfigurationInfo>
    {
        /// <summary>
        /// Name of motif.
        /// </summary>
        string Name => Scrapper.GetString(SectionName, "name");

        /// <summary>
        /// Motif author name.
        /// </summary>
        string Author => Scrapper.GetString(SectionName, "author");

        /// <summary>
        /// Version date of motif.
        /// </summary>
        DateTime VersionDate => Scrapper.GetDate(SectionName, "versiondate");

        /// <summary>
        /// Version of motif.
        /// </summary>
        float Version => Scrapper.GetFloat(SectionName, "mugenversion");
    }

    public interface IMotifConfigurationFiles : IConfigurationManagerSection<IMotifConfigurationFiles>
    {
        /// <summary>
        /// Filename of sprite data.
        /// </summary>
        IFileEntry Sprite => Scrapper.GetFile(SectionName, "spr");

        /// <summary>
        /// Filename of sound data.
        /// </summary>
        IFileEntry Sound => Scrapper.GetFile(SectionName, "snd");

        /// <summary>
        /// Logo storyboard definition (optional).
        /// </summary>
        string LogoStoryboardDefinition => Scrapper.GetString(SectionName, "logo.storyboard");

        /// <summary>
        /// Intro storyboard definition (optional).
        /// </summary>
        string IntroStoryboardDefinition => Scrapper.GetString(SectionName, "intro.storyboard");

        /// <summary>
        /// Character and stage selection list.
        /// </summary>
        IFileEntry Selection => Scrapper.GetFile(SectionName, "select");

        /// <summary>
        /// Fight definition filename.
        /// </summary>
        IFileEntry Fight => Scrapper.GetFile(SectionName, "fight");

        /// <summary>
        /// System fonts.
        /// </summary>
        IEntryCollection<IFileEntry> Fonts => Scrapper.GetCollection<IFileEntry>(SectionName, "font");
    }

    public interface IMotifConfigurationMusic : IConfigurationManagerSection<IMotifConfigurationMusic>
    {
        /// <summary>
        /// Music to play at title screen.
        /// </summary>
        IAudioEntry Title => Scrapper.GetAudio(SectionName, "title.bgm");

        /// <summary>
        /// Music to play at char select screen.
        /// </summary>
        IAudioEntry Select => Scrapper.GetAudio(SectionName, "select.bgm");

        /// <summary>
        /// Music to play at versus screen.
        /// </summary>
        IAudioEntry Vs => Scrapper.GetAudio(SectionName, "vs.bgm");

        /// <summary>
        /// Music to play at victory screen.
        /// </summary>
        IAudioEntry Victory => Scrapper.GetAudio(SectionName, "victory.bgm");
    }

    public interface IMotifConfigurationTitleInfo : IConfigurationManagerSection<IMotifConfigurationTitleInfo>
    {
        int FadeInTime => Scrapper.GetInt(SectionName, "fadein.time");
        int FadeOutTime => Scrapper.GetInt(SectionName, "fadeout.time");
        IPositionEntry MenuPos => Scrapper.GetPosition(SectionName, "menu.pos");
        ITextEntry MenuItem => Scrapper.GetText(SectionName, "menu.item");
        ITextEntry MenuItemActive => Scrapper.GetText(SectionName, "menu.item.active");
        string MenuItemNameArcade => Scrapper.GetString(SectionName, "menu.itemname.arcade");
        string MenuItemNameVersus => Scrapper.GetString(SectionName, "menu.itemname.versus");
        string MenuItemNameTeamArcade => Scrapper.GetString(SectionName, "menu.itemname.teamarcade");
        string MenuItemNameTeamVersus => Scrapper.GetString(SectionName, "menu.itemname.teamversus");
        string MenuItemNameTeamCoop => Scrapper.GetString(SectionName, "menu.itemname.teamcoop");
        string MenuItemNameSurvival => Scrapper.GetString(SectionName, "menu.itemname.survival");

        string MenuItemNameSurvivalCoop =>
            Scrapper.GetString(SectionName, "menu.itemname.survivalcoop");

        string MenuItemNameTraining => Scrapper.GetString(SectionName, "menu.itemname.training");
        string MenuItemNameWatch => Scrapper.GetString(SectionName, "menu.itemname.watch");
        string MenuItemNameOptions => Scrapper.GetString(SectionName, "menu.itemname.options");
        string MenuItemNameExit => Scrapper.GetString(SectionName, "menu.itemname.exit");
        IPositionEntry MenuWindowMarginsY => Scrapper.GetPosition(SectionName, "menu.window.margins.y");
        int MenuWindowVisibleItems => Scrapper.GetInt(SectionName, "menu.window.visibleitems");

        /// <summary>
        /// Set it to true to enable default cursor display.
        /// Set it to false to disable default cursor display.
        /// </summary>
        bool IsMenuBoxCursorVisible => Scrapper.GetBoolean(SectionName, "menu.boxcursor.visible");

        IBoxEntry MenuBoxCursorCoords => Scrapper.GetBox(SectionName, "menu.boxcursor.coords");
        IMovementEntry Cursor => Scrapper.GetMovement(SectionName, "cursor");
        ISpriteSoundEntry Cancel => Scrapper.GetSpriteSound(SectionName, "cancel");
    }

    public interface IMotifConfigurationTitleBgDef : IConfigurationManagerSection<IMotifConfigurationTitleBgDef> // TODO: Enumerable inside
    {
    }

    public interface IMotifConfigurationInfobox : IConfigurationManagerSection<IMotifConfigurationInfobox> // TODO: What is this ??? Get an example
    {
    }

    public interface IMotifConfigurationSelectInfo : IConfigurationManagerSection<IMotifConfigurationSelectInfo>
    {
        int FadeInTime => Scrapper.GetInt(SectionName, "fadein.time");
        int FadeOutTime => Scrapper.GetInt(SectionName, "fadeout.time");
        int Rows => Scrapper.GetInt(SectionName, "rows");
        int Columns => Scrapper.GetInt(SectionName, "columns");

        /// <summary>
        /// Values:
        /// 0 - default
        /// 1 - cursor wraps around
        /// </summary>
        int Wrapping => Scrapper.GetInt(SectionName, "wrapping");

        /// <summary>
        /// Position to draw to.
        /// </summary>
        string Pos => Scrapper.GetString(SectionName, "pos");

        bool ShowEmptyBoxes => Scrapper.GetBoolean(SectionName, "showemptyboxes");
        bool CanMoveOverEmptyBoxes => Scrapper.GetBoolean(SectionName, "moveoveremptyboxes");

        /// <summary>
        /// (x,y) size of each cell in pixels.
        /// </summary>
        string CellSize => Scrapper.GetString(SectionName, "cell.size");

        /// <summary>
        /// Space between each cell.
        /// </summary>
        int CellSpacing => Scrapper.GetInt(SectionName, "cell.spacing");

        string CellBgSpr => Scrapper.GetString(SectionName, "cell.bg.spr");

        /// <summary>
        /// Icon for random select.
        /// </summary>
        string CellRandomSpr => Scrapper.GetString(SectionName, "cell.random.spr");

        /// <summary>
        /// Time to wait before changing to another random portrait.
        /// </summary>
        string CellRandomSwitchTime => Scrapper.GetString(SectionName, "cell.random.switchtime");

        /// <summary>
        /// Player 1 selection.
        /// </summary>
        IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection(SectionName, "p1");

        /// <summary>
        /// Player 2 selection.
        /// </summary>
        IPlayerSelectionEntry Player2 => Scrapper.GetPlayerSelection(SectionName, "p2");

        IMovementEntry Random => Scrapper.GetMovement(SectionName, "random");
        IMovementEntry Stage => Scrapper.GetMovement(SectionName, "stage");
        ISpriteSoundEntry Cancel => Scrapper.GetSpriteSound(SectionName, "cancel");
        IImageEntry Portrait => Scrapper.GetImage(SectionName, "portrait");
        ITextEntry Title => Scrapper.GetText(SectionName, "title");
    }

    public interface
        IMotifConfigurationSelectBgDef : IConfigurationManagerSection<IMotifConfigurationSelectBgDef
        > // TODO: Enumerable inside
    {
    }

    public interface
        IMotifConfigurationVsScreen : IConfigurationManagerSection<IMotifConfigurationVsScreen
        > // TODO: Enumerable inside
    {
    }

    public interface IMotifConfigurationVsBgDef : IConfigurationManagerSection<IMotifConfigurationVsBgDef>
    {
    }

    public interface IMotifConfigurationDemoMode : IConfigurationManagerSection<IMotifConfigurationDemoMode>
    {
    }

    public interface IMotifConfigurationContinueScreen : IConfigurationManagerSection<IMotifConfigurationContinueScreen>
    {
    }

    public interface IMotifConfigurationGameOverScreen : IConfigurationManagerSection<IMotifConfigurationGameOverScreen>
    {
    }

    public interface
        IMotifConfigurationVictoryScreen : IConfigurationManagerSection<IMotifConfigurationVictoryScreen
        > // TODO: Enumerable inside
    {
    }

    public interface IMotifConfigurationWinScreen : IConfigurationManagerSection<IMotifConfigurationWinScreen>
    {
    }

    public interface IMotifConfigurationDefaultEnding : IConfigurationManagerSection<IMotifConfigurationDefaultEnding>
    {
    }

    public interface IMotifConfigurationEndCredits : IConfigurationManagerSection<IMotifConfigurationEndCredits>
    {
    }

    public interface
        IMotifConfigurationSurvivalResultsScreen : IConfigurationManagerSection<IMotifConfigurationSurvivalResultsScreen
        >
    {
    }

    public interface
        IMotifConfigurationOptionInfo : IConfigurationManagerSection<IMotifConfigurationOptionInfo
        > // TODO: Enumerable inside
    {
    }
}