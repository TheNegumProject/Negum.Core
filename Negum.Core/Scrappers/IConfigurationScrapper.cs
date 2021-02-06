using System;
using Negum.Core.Configurations;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// Scraps over specified configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationScrapper
    {
        /// <summary>
        /// Sets configuration which should be scrapped.
        /// </summary>
        /// <typeparam name="TConfiguration"></typeparam>
        /// <returns>Returns this scrapper.</returns>
        IConfigurationScrapper Setup(IConfigurationDefinition def);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Integer value from selected configuration.</returns>
        int GetInt(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Float  value from selected configuration.</returns>
        float GetFloat(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Boolean value from selected configuration.</returns>
        bool GetBoolean(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>String value from selected configuration.</returns>
        string GetString(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>DateTime value from selected configuration.</returns>
        DateTime GetDate(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>File value from selected configuration.</returns>
        IFileEntry GetFile(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TEntry"></typeparam>
        /// <returns>Collection of values which starts from selected key from configuration.</returns>
        IEntryCollection<TEntry> GetCollection<TEntry>(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Audio value from selected configuration.</returns>
        IAudioEntry GetAudio(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Keys value from selected configuration.</returns>
        IKeysEntry GetKeys(string sectionName, string fieldKey);
        
        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Sprite and Sound values from selected configuration.</returns>
        ISpriteSoundEntry GetSpriteSound(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Animation value from selected configuration.</returns>
        IAnimationEntry GetAnimation(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Player selection value from selected configuration.</returns>
        IPlayerSelectionEntry GetPlayerSelection(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Player selection cursor value from selected configuration.</returns>
        IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Movement value from selected configuration.</returns>
        IMovementEntry GetMovement(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Image value from selected configuration.</returns>
        IImageEntry GetImage(string sectionName, string fieldKey);
        
        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Position value from selected configuration.</returns>
        IPositionEntry GetPosition(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Position from specified value directly.</returns>
        IPositionEntry GetPosition(string value);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Box value from selected configuration.</returns>
        IBoxEntry GetBox(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Text value from selected configuration.</returns>
        ITextEntry GetText(string sectionName, string fieldKey);

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Font value from selected configuration.</returns>
        IFontEntry GetFont(string sectionName, string fieldKey);
        
        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Cell value from selected configuration.</returns>
        ICellSelectionEntry GetCell(string sectionName, string fieldKey);
        
        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Stage value from selected configuration.</returns>
        IStageSelectionEntry GetStage(string sectionName, string fieldKey);
        
        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Sprite value from selected configuration.</returns>
        ISpriteEntry GetSprite(string sectionName, string fieldKey);
        
        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="fieldKey"></param>
        /// <returns>Sound value from selected configuration.</returns>
        ISoundEntry GetSound(string sectionName, string fieldKey);
    }
}