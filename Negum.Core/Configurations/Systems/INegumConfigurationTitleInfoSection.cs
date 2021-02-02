namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// Title Info section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationTitleInfoSection : INegumConfigurationSection
    {
        public const string FadeInTimeKey = "fadein.time";
        public const string FadeOutTimeKey = "fadeout.time";
        public const string MenuPosKey = "menu.pos";
        public const string MenuItemFontKey = "menu.item.font";
        public const string MenuItemActiveFontKey = "menu.item.active.font";
        public const string MenuItemSpacingKey = "menu.item.spacing";
        public const string MenuItemNameArcadeKey = "menu.itemname.arcade";
        public const string MenuItemNameVersusKey = "menu.itemname.versus";
        public const string MenuItemNameTeamArcadeKey = "menu.itemname.teamarcade";
        public const string MenuItemNameTeamVersusKey = "menu.itemname.teamversus";
        public const string MenuItemNameTeamCoopKey = "menu.itemname.teamcoop";
        public const string MenuItemNameSurvivalKay = "menu.itemname.survival";
        public const string MenuItemNameSurvivalCoopKey = "menu.itemname.survivalcoop";
        public const string MenuItemNameTrainingKey = "menu.itemname.training";
        public const string MenuItemNameWatchKey = "menu.itemname.watch";
        public const string MenuItemNameOptionsKey = "menu.itemname.options";
        public const string MenuItemNameExitKey = "menu.itemname.exit";
        public const string MenuWindowMarginsYKey = "menu.window.margins.y";
        public const string MenuWindowVisibleItemsKey = "menu.window.visibleitems";
        public const string MenuBoxCursorVisibleKey = "menu.boxcursor.visible";
        public const string MenuBoxCursorCoordsKey = "menu.boxcursor.coords";
        public const string CursorMoveSoundKey = "cursor.move.snd";
        public const string CursorDoneSoundKey = "cursor.done.snd";
        public const string CancelSoundKey = "cancel.snd";

        int FadeInTime
        {
            get => this.GetOrDefault(FadeInTimeKey, 10);
            set => this.SetNewValue(FadeInTimeKey, value);
        }

        int FadeOutTime
        {
            get => this.GetOrDefault(FadeOutTimeKey, 10);
            set => this.SetNewValue(FadeOutTimeKey, value);
        }

        string MenuPos
        {
            get => this.GetOrDefault(MenuPosKey, "159,158");
            set => this.SetNewValue(MenuPosKey, value);
        }

        string MenuItemFont
        {
            get => this.GetOrDefault(MenuItemFontKey, "3,0,0");
            set => this.SetNewValue(MenuItemFontKey, value);
        }

        string MenuItemActiveFont
        {
            get => this.GetOrDefault(MenuItemActiveFontKey, "3,5,0");
            set => this.SetNewValue(MenuItemActiveFontKey, value);
        }

        string MenuItemSpacing
        {
            get => this.GetOrDefault(MenuItemSpacingKey, "0,13");
            set => this.SetNewValue(MenuItemSpacingKey, value);
        }

        string MenuItemNameArcade
        {
            get => this.GetOrDefault(MenuItemNameArcadeKey, "ARCADE");
            set => this.SetNewValue(MenuItemNameArcadeKey, value);
        }

        string MenuItemNameVersus
        {
            get => this.GetOrDefault(MenuItemNameVersusKey, "VS MODE");
            set => this.SetNewValue(MenuItemNameVersusKey, value);
        }

        string MenuItemNameTeamArcade
        {
            get => this.GetOrDefault(MenuItemNameTeamArcadeKey, "TEAM ARCADE");
            set => this.SetNewValue(MenuItemNameTeamArcadeKey, value);
        }

        string MenuItemNameTeamVersus
        {
            get => this.GetOrDefault(MenuItemNameTeamVersusKey, "TEAM VS");
            set => this.SetNewValue(MenuItemNameTeamVersusKey, value);
        }

        string MenuItemNameTeamCoop
        {
            get => this.GetOrDefault(MenuItemNameTeamCoopKey, "TEAM CO-OP");
            set => this.SetNewValue(MenuItemNameTeamCoopKey, value);
        }

        string MenuItemNameSurvival
        {
            get => this.GetOrDefault(MenuItemNameSurvivalKay, "SURVIVAL");
            set => this.SetNewValue(MenuItemNameSurvivalKay, value);
        }

        string MenuItemNameSurvivalCoop
        {
            get => this.GetOrDefault(MenuItemNameSurvivalCoopKey, "SURVIVAL CO-OP");
            set => this.SetNewValue(MenuItemNameSurvivalCoopKey, value);
        }

        string MenuItemNameTraining
        {
            get => this.GetOrDefault(MenuItemNameTrainingKey, "TRAINING");
            set => this.SetNewValue(MenuItemNameTrainingKey, value);
        }

        string MenuItemNameWatch
        {
            get => this.GetOrDefault(MenuItemNameWatchKey, "WATCH");
            set => this.SetNewValue(MenuItemNameWatchKey, value);
        }

        string MenuItemNameOptions
        {
            get => this.GetOrDefault(MenuItemNameOptionsKey, "OPTIONS");
            set => this.SetNewValue(MenuItemNameOptionsKey, value);
        }

        string MenuItemNameExit
        {
            get => this.GetOrDefault(MenuItemNameExitKey, "EXIT");
            set => this.SetNewValue(MenuItemNameExitKey, value);
        }

        string MenuWindowMarginsY
        {
            get => this.GetOrDefault(MenuWindowMarginsYKey, "12,8");
            set => this.SetNewValue(MenuWindowMarginsYKey, value);
        }

        int MenuWindowVisibleItems
        {
            get => this.GetOrDefault(MenuWindowVisibleItemsKey, 5);
            set => this.SetNewValue(MenuWindowVisibleItemsKey, value);
        }

        /// <summary>
        /// Set it to true to enable default cursor display.
        /// Set it to false to disable default cursor display.
        /// </summary>
        bool MenuBoxCursorVisible
        {
            get => this.GetOrDefault(MenuBoxCursorVisibleKey, true);
            set => this.SetNewValue(MenuBoxCursorVisibleKey, value);
        }

        string MenuBoxCursorCoords
        {
            get => this.GetOrDefault(MenuBoxCursorCoordsKey, "-58,-10,57,2");
            set => this.SetNewValue(MenuBoxCursorCoordsKey, value);
        }

        string CursorMoveSound
        {
            get => this.GetOrDefault(CursorMoveSoundKey, "100,0");
            set => this.SetNewValue(CursorMoveSoundKey, value);
        }

        string CursorDoneSound
        {
            get => this.GetOrDefault(CursorDoneSoundKey, "100,1");
            set => this.SetNewValue(CursorDoneSoundKey, value);
        }

        string CancelSound
        {
            get => this.GetOrDefault(CancelSoundKey, "100,2");
            set => this.SetNewValue(CancelSoundKey, value);
        }
    }
}