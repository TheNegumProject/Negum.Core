using System;
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
        /// <param name="fieldKey"></param>
        /// <returns>Integer value from selected configuration.</returns>
        int GetInt(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Float  value from selected configuration.</returns>
        float GetFloat(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Boolean value from selected configuration.</returns>
        bool GetBoolean(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>String value from selected configuration.</returns>
        string GetString(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>DateTime value from selected configuration.</returns>
        DateTime GetDate(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>File value from selected configuration.</returns>
        IFileEntry GetFile(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TEntry"></typeparam>
        /// <returns>Collection of values which starts from selected key from configuration.</returns>
        IEntryCollection<TEntry> GetCollection<TEntry>(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Audio value from selected configuration.</returns>
        IAudioEntry GetAudio(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Keys value from selected configuration.</returns>
        IKeysEntry GetKeys(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sprite and Sound values from selected configuration.</returns>
        ISpriteSoundEntry GetSpriteSound(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Animation value from selected configuration.</returns>
        IAnimationEntry GetAnimation(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Player selection value from selected configuration.</returns>
        IPlayerSelectionEntry GetPlayerSelection(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Player selection cursor value from selected configuration.</returns>
        IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Movement value from selected configuration.</returns>
        IMovementEntry GetMovement(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Image value from selected configuration.</returns>
        IImageEntry GetImage(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Position value from selected configuration.</returns>
        IPositionEntry GetPosition(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Box value from selected configuration.</returns>
        IBoxEntry GetBox(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Text value from selected configuration.</returns>
        ITextEntry GetText(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Font value from selected configuration.</returns>
        IFontEntry GetFont(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Cell value from selected configuration.</returns>
        ICellSelectionEntry GetCell(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Stage value from selected configuration.</returns>
        IStageSelectionEntry GetStage(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sprite value from selected configuration.</returns>
        ISpriteEntry GetSprite(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from selected configuration.</returns>
        ISoundEntry GetSound(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Player Selection Team Menu Item value from selected configuration.</returns>
        IPlayerSelectionTeamMenuItemEntry GetPlayerSelectionTeamMenuItem(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from selected configuration.</returns>
        IPlayerSelectionTeamMenuEntry GetPlayerSelectionTeamMenu(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from selected configuration.</returns>
        IPlayerSelectionTeamMenuValueEntry GetPlayerSelectionTeamMenuValue(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Time value from selected configuration.</returns>
        ITimeEntry GetTime(string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <returns>Demo Mode Fight value from selected configuration.</returns>
        IDemoModeFightEntry GetDemoModeFight(string fieldKey);
    }
}