using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationSectionScrapper : IConfigurationSectionScrapper
    {
        private IConfigurationSection ConfigSection { get; set; }

        public IConfigurationSectionScrapper Setup(IConfigurationSection configSection)
        {
            this.ConfigSection = configSection;
            return this;
        }

        public IEnumerable<IConfigurationSectionEntry> GetAll() =>
            this.ConfigSection.Entries.ToImmutableList();

        public int GetInt(string fieldKey) =>
            int.Parse(this.GetString(fieldKey));

        public float GetFloat(string fieldKey) =>
            float.Parse(this.GetString(fieldKey));

        public bool GetBoolean(string fieldKey) =>
            bool.Parse(this.GetString(fieldKey));

        public string GetString(string fieldKey) =>
            this.ConfigSection[fieldKey];

        public DateTime GetDate(string fieldKey) =>
            DateTime.Parse(this.GetString(fieldKey));

        public IFileEntry GetFile(string fieldKey) =>
            NegumContainer.Resolve<IFileEntry>().Setup(this, fieldKey);
        
        public IEntryCollection<TEntry> GetCollection<TEntry>(IEnumerable<string> keys)
            where TEntry : IScrapperEntry<TEntry> => 
            NegumContainer.Resolve<IEntryCollection<TEntry>>().Setup(this, keys);

        public IEntryCollection<TEntry> GetCollection<TEntry>(string fieldKey)
            where TEntry : IScrapperEntry<TEntry> => 
            NegumContainer.Resolve<IEntryCollection<TEntry>>().Setup(this, fieldKey);

        public IAudioEntry GetAudio(string fieldKey) =>
            NegumContainer.Resolve<IAudioEntry>().Setup(this, fieldKey);

        public IKeysEntry GetKeys(string fieldKey) =>
            NegumContainer.Resolve<IKeysEntry>().Setup(this, fieldKey);

        public ISpriteSoundEntry GetSpriteSound(string fieldKey) =>
            NegumContainer.Resolve<ISpriteSoundEntry>().Setup(this, fieldKey);

        public IAnimationEntry GetAnimation(string fieldKey) =>
            NegumContainer.Resolve<IAnimationEntry>().Setup(this, fieldKey);

        public IPlayerSelectionEntry GetPlayerSelection(string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionEntry>().Setup(this, fieldKey);

        public IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionCursorEntry>().Setup(this, fieldKey);

        public IMovementEntry GetMovement(string fieldKey) =>
            NegumContainer.Resolve<IMovementEntry>().Setup(this, fieldKey);

        public IImageEntry GetImage(string fieldKey) =>
            NegumContainer.Resolve<IImageEntry>().Setup(this, fieldKey);

        public IPositionEntry GetPosition(string fieldKey) =>
            NegumContainer.Resolve<IPositionEntry>().Setup(this, fieldKey);

        public IBoxEntry GetBox(string fieldKey) =>
            NegumContainer.Resolve<IBoxEntry>().Setup(this, fieldKey);

        public ITextEntry GetText(string fieldKey) =>
            NegumContainer.Resolve<ITextEntry>().Setup(this, fieldKey);

        public IFontEntry GetFont(string fieldKey) =>
            NegumContainer.Resolve<IFontEntry>().Setup(this, fieldKey);

        public ICellSelectionEntry GetCell(string fieldKey) =>
            NegumContainer.Resolve<ICellSelectionEntry>().Setup(this, fieldKey);

        public IStageSelectionEntry GetStage(string fieldKey) =>
            NegumContainer.Resolve<IStageSelectionEntry>().Setup(this, fieldKey);

        public ISpriteEntry GetSprite(string fieldKey) =>
            NegumContainer.Resolve<ISpriteEntry>().Setup(this, fieldKey);

        public ISoundEntry GetSound(string fieldKey) =>
            NegumContainer.Resolve<ISoundEntry>().Setup(this, fieldKey);

        public IPlayerSelectionTeamMenuItemEntry GetPlayerSelectionTeamMenuItem(string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionTeamMenuItemEntry>().Setup(this, fieldKey);

        public IPlayerSelectionTeamMenuEntry GetPlayerSelectionTeamMenu(string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionTeamMenuEntry>().Setup(this, fieldKey);

        public IPlayerSelectionTeamMenuValueEntry GetPlayerSelectionTeamMenuValue(string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionTeamMenuValueEntry>().Setup(this, fieldKey);

        public ITimeEntry GetTime(string fieldKey) =>
            NegumContainer.Resolve<ITimeEntry>().Setup(this, fieldKey);

        public IDemoModeFightEntry GetDemoModeFight(string fieldKey) =>
            NegumContainer.Resolve<IDemoModeFightEntry>().Setup(this, fieldKey);

        public IEnumerable<ICharacterEntry> GetCharacters() =>
            this.GetAll()
                .Select(entry => NegumContainer.Resolve<ICharacterEntry>().Setup(this, entry.Value))
                .ToImmutableList();
    }
}