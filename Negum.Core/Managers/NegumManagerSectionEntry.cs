namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class NegumManagerSectionEntry<TEntry> : INegumManagerSectionEntry<TEntry>
    {
        protected string SectionEntryContent { get; set; }
        
        public INegumManagerSection Section { get; protected set; }
        public string FieldKey { get; protected set; }

        public void Initialize(INegumManagerSection section, string fieldKey, string sectionEntryContent)
        {
            this.Section = section;
            this.FieldKey = fieldKey;
            this.SectionEntryContent = sectionEntryContent;
        }

        public abstract TEntry Get();
    }
}