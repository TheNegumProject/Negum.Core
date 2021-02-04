using System;
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
    public class ConfigurationScrapper : IConfigurationScrapper
    {
        private IConfigurationDefinition ConfigDef { get; set; }

        public IConfigurationScrapper Use<TConfiguration>()
            where TConfiguration : IConfigurationDefinition
        {
            this.ConfigDef = NegumContainer.Resolve<TConfiguration>();
            return this;
        }

        public int GetInt(string sectionName, string fieldKey) =>
            int.Parse(this.GetString(sectionName, fieldKey));

        public float GetFloat(string sectionName, string fieldKey) =>
            float.Parse(this.GetString(sectionName, fieldKey));

        public bool GetBoolean(string sectionName, string fieldKey) =>
            bool.Parse(this.GetString(sectionName, fieldKey));

        public string GetString(string sectionName, string fieldKey) =>
            this.ConfigDef[sectionName][fieldKey];

        public DateTime GetDate(string sectionName, string fieldKey) =>
            DateTime.Parse(this.GetString(sectionName, fieldKey));

        public IFileEntry GetFile(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IFileEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IEntryCollection<TEntry> GetCollection<TEntry>(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IEntryCollection<TEntry>>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IAudioEntry GetAudio(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IAudioEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IKeysEntry GetKeys(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IKeysEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public ISpriteSoundEntry GetSpriteSound(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ISpriteSoundEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IAnimationEntry GetAnimation(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IAnimationEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionEntry GetPlayerSelection(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionCursorEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IMovementEntry GetMovement(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IMovementEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IImageEntry GetImage(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IImageEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IPositionEntry GetPosition(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPositionEntry>().From(this, this.ConfigDef[sectionName], fieldKey);
        
        public IPositionEntry GetPosition(string position) =>
            NegumContainer.Resolve<IPositionEntry>().From(position);

        public IBoxEntry GetBox(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IBoxEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public ITextEntry GetText(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ITextEntry>().From(this, this.ConfigDef[sectionName], fieldKey);

        public IFontEntry GetFont(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IFontEntry>().From(this, this.ConfigDef[sectionName], fieldKey);
    }
}