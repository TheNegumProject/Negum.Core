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

        public IConfigurationScrapper Setup(IConfigurationDefinition def)
        {
            this.ConfigDef = def;
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
            NegumContainer.Resolve<IFileEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IEntryCollection<TEntry> GetCollection<TEntry>(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IEntryCollection<TEntry>>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IAudioEntry GetAudio(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IAudioEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IKeysEntry GetKeys(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IKeysEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public ISpriteSoundEntry GetSpriteSound(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ISpriteSoundEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IAnimationEntry GetAnimation(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IAnimationEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionEntry GetPlayerSelection(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionCursorEntry GetPlayerSelectionCursor(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionCursorEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IMovementEntry GetMovement(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IMovementEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IImageEntry GetImage(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IImageEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IPositionEntry GetPosition(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPositionEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);
        
        public IPositionEntry GetPosition(string position) =>
            NegumContainer.Resolve<IPositionEntry>().From(position);

        public IBoxEntry GetBox(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IBoxEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public ITextEntry GetText(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ITextEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IFontEntry GetFont(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IFontEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public ICellSelectionEntry GetCell(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ICellSelectionEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IStageSelectionEntry GetStage(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IStageSelectionEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public ISpriteEntry GetSprite(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ISpriteEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public ISoundEntry GetSound(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ISoundEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionTeamMenuItemEntry GetPlayerSelectionTeamMenuItem(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionTeamMenuItemEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionTeamMenuEntry GetPlayerSelectionTeamMenu(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionTeamMenuEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IPlayerSelectionTeamMenuValueEntry GetPlayerSelectionTeamMenuValue(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IPlayerSelectionTeamMenuValueEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public ITimeEntry GetTime(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<ITimeEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);

        public IDemoModeFightEntry GetDemoModeFight(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IDemoModeFightEntry>().Setup(this, this.ConfigDef[sectionName], fieldKey);
    }
}