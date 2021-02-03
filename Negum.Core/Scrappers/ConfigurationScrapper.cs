using System;
using Negum.Core.Configurations;
using Negum.Core.Containers;

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
            this.ConfigDef.Sections[sectionName][fieldKey];

        public DateTime GetDate(string sectionName, string fieldKey) =>
            DateTime.Parse(this.GetString(sectionName, fieldKey));

        public IFileEntry GetFile(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IFileEntry>().From(this.GetString(sectionName, fieldKey));

        public IEntryCollection<TEntry> GetCollection<TEntry>(string sectionName, string fieldKey) =>
            NegumContainer.Resolve<IEntryCollection<TEntry>>().From(this.ConfigDef.Sections[sectionName], fieldKey);
    }
}