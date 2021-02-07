using System;
using System.Collections.Generic;
using Negum.Core.Configurations;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// Scraps over specified section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationSectionScrapper
    {
        /// <summary>
        /// Setups current Section Scrapper.
        /// </summary>
        /// <param name="configSection"></param>
        /// <returns>Current Section Scrapper.</returns>
        IConfigurationSectionScrapper Setup(IConfigurationSection configSection);

        /// <summary>
        /// </summary>
        /// <returns>All configuration entries in current section.</returns>
        IEnumerable<IConfigurationSectionEntry> GetAll();
        
        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Integer value from current configuration.</returns>
        int GetInt(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Float  value from current configuration.</returns>
        float GetFloat(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Boolean value from current configuration.</returns>
        bool GetBoolean(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>String value from current configuration.</returns>
        string GetString(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>DateTime value from current configuration.</returns>
        DateTime GetDate(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>File value from current configuration.</returns>
        IFileEntry GetFile(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="keys">Keys which should be used to take values from current Section.</param>
        /// <returns>Collection of entries from specified keys.</returns>
        IEntryCollection<TEntry> GetCollection<TEntry>(IEnumerable<string> keys) where TEntry : IScrapperEntry<TEntry>;

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TEntry"></typeparam>
        /// <returns>Collection of values which starts from selected key from configuration.</returns>
        IEntryCollection<TEntry> GetCollection<TEntry>(string fieldKey) where TEntry : IScrapperEntry<TEntry>;

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Audio value from current configuration.</returns>
        IAudioEntry GetAudio(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Keys value from current configuration.</returns>
        IKeysEntry GetKeys(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sprite and Sound values from current configuration.</returns>
        ISpriteSoundEntry GetSpriteSound(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Animation value from current configuration.</returns>
        IAnimationEntry GetAnimation(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Player selection value from current configuration.</returns>
        IPlayerSelectionEntry GetPlayerSelection(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Player selection cursor value from current configuration.</returns>
        IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Movement value from current configuration.</returns>
        IMovementEntry GetMovement(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Image value from current configuration.</returns>
        IImageEntry GetImage(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Position value from current configuration.</returns>
        IPositionEntry GetPosition(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Box value from current configuration.</returns>
        IBoxEntry GetBox(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Text value from current configuration.</returns>
        ITextEntry GetText(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Font value from current configuration.</returns>
        IFontEntry GetFont(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Cell value from current configuration.</returns>
        ICellSelectionEntry GetCell(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Stage value from current configuration.</returns>
        IStageSelectionEntry GetStage(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sprite value from current configuration.</returns>
        ISpriteEntry GetSprite(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from current configuration.</returns>
        ISoundEntry GetSound(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Player Selection Team Menu Item value from current configuration.</returns>
        IPlayerSelectionTeamMenuItemEntry GetPlayerSelectionTeamMenuItem(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from current configuration.</returns>
        IPlayerSelectionTeamMenuEntry GetPlayerSelectionTeamMenu(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from current configuration.</returns>
        IPlayerSelectionTeamMenuValueEntry GetPlayerSelectionTeamMenuValue(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Time value from current configuration.</returns>
        ITimeEntry GetTime(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Demo Mode Fight value from current configuration.</returns>
        IDemoModeFightEntry GetDemoModeFight(string fieldKey);

        /// <summary>
        /// </summary>
        /// <returns>Character collection from current configuration.</returns>
        IEnumerable<ICharacterEntry> GetCharacters();
    }
}