namespace Negum.Core.Managers
{
    /// <summary>
    /// Represents single entry returned from Manager's Section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumManagerSectionEntry<out TEntryType>
    {
        /// <summary>
        /// Section from which the current entry was created.
        /// </summary>
        INegumManagerSection Section { get; }
        
        /// <summary>
        /// Prefix from which the current field was created.
        /// </summary>
        string FieldKey { get; }

        /// <summary>
        /// Initializes current entry with values.
        /// This should be called only once per every new instance of the entry.
        /// Do not call it directly.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="fieldKey"></param>
        /// <param name="sectionEntryContent"></param>
        void Initialize(INegumManagerSection section, string fieldKey, string sectionEntryContent);

        /// <summary>
        /// </summary>
        /// <returns>Parsed value.</returns>
        TEntryType Get();
    }
}