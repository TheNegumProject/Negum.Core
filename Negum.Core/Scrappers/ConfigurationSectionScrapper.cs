using System.Collections;
using System.Collections.Generic;
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

        public string SectionName { get; protected set; }

        public IConfigurationSectionScrapper Setup(IConfigurationSection configSection, string sectionName)
        {
            this.ConfigSection = configSection;
            this.SectionName = sectionName;
            return this;
        }

        public int GetInt(string fieldKey) => int.Parse(this.GetString(fieldKey));
        public float GetFloat(string fieldKey) => float.Parse(this.GetString(fieldKey));
        public bool GetBoolean(string fieldKey) => bool.Parse(this.GetString(fieldKey));
        public string GetString(string fieldKey) => this.ConfigSection[fieldKey];
        public IFileEntry GetFile(string fieldKey) => this.GetEntry<IFileEntry>(fieldKey);

        public IEntryCollection<TEntry> GetCollection<TEntry>(IEnumerable<string> keys)
            where TEntry : IScrapperEntry =>
            NegumContainer.Resolve<IEntryCollection<TEntry>>().Setup(this, keys);

        public IEntryCollection<TEntry> GetCollection<TEntry>(string fieldKey)
            where TEntry : IScrapperEntry =>
            this.GetEntry<IEntryCollection<TEntry>>(fieldKey);

        public IAudioEntry GetAudio(string fieldKey) => this.GetEntry<IAudioEntry>(fieldKey);
        public IKeysEntry GetKeys(string fieldKey) => this.GetEntry<IKeysEntry>(fieldKey);
        public ISpriteSoundEntry GetSpriteSound(string fieldKey) => this.GetEntry<ISpriteSoundEntry>(fieldKey);

        public IPlayerSelectionEntry GetPlayerSelection(string fieldKey) =>
            this.GetEntry<IPlayerSelectionEntry>(fieldKey);

        public IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string fieldKey) =>
            this.GetEntry<IPlayerSelectionCursorEntry>(fieldKey);

        public IMovementEntry GetMovement(string fieldKey) => this.GetEntry<IMovementEntry>(fieldKey);
        public IImageEntry GetImage(string fieldKey) => this.GetEntry<IImageEntry>(fieldKey);
        public IVectorEntry GetVector(string fieldKey) => this.GetEntry<IVectorEntry>(fieldKey);
        public ITextEntry GetText(string fieldKey) => this.GetEntry<ITextEntry>(fieldKey);
        public ICellSelectionEntry GetCell(string fieldKey) => this.GetEntry<ICellSelectionEntry>(fieldKey);
        public IStageSelectionEntry GetStage(string fieldKey) => this.GetEntry<IStageSelectionEntry>(fieldKey);

        public IPlayerSelectionTeamMenuItemEntry GetPlayerSelectionTeamMenuItem(string fieldKey) =>
            this.GetEntry<IPlayerSelectionTeamMenuItemEntry>(fieldKey);

        public IPlayerSelectionTeamMenuEntry GetPlayerSelectionTeamMenu(string fieldKey) =>
            this.GetEntry<IPlayerSelectionTeamMenuEntry>(fieldKey);

        public IPlayerSelectionTeamMenuValueEntry GetPlayerSelectionTeamMenuValue(string fieldKey) =>
            this.GetEntry<IPlayerSelectionTeamMenuValueEntry>(fieldKey);

        public ITimeEntry GetTime(string fieldKey) => this.GetEntry<ITimeEntry>(fieldKey);
        public IDemoModeFightEntry GetDemoModeFight(string fieldKey) => this.GetEntry<IDemoModeFightEntry>(fieldKey);

        public IEnumerable<ICharacterEntry> GetCharacters() =>
            this.Select(entry => this.GetEntry<ICharacterEntry>(entry.Value))
                .ToList();

        public IFightConfigurationPlayerEntry GetFightConfigurationPlayer(string fieldKey) =>
            this.GetEntry<IFightConfigurationPlayerEntry>(fieldKey);

        public IFightConfigurationTeamEntry GetFightConfigurationTeam(string fieldKey) =>
            this.GetEntry<IFightConfigurationTeamEntry>(fieldKey);

        public IFightConfigurationWinEntry GetFightConfigurationWin(string fieldKey) =>
            this.GetEntry<IFightConfigurationWinEntry>(fieldKey);

        public IScreenElementEntry GetScreenElement(string fieldKey) => this.GetEntry<IScreenElementEntry>(fieldKey);

        public IEnumerator<IConfigurationSectionEntry> GetEnumerator() => this.ConfigSection.Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private TEntry GetEntry<TEntry>(string fieldKey)
            where TEntry : IScrapperEntry =>
            (TEntry) NegumContainer.Resolve<TEntry>().Setup(this, fieldKey);
    }
}