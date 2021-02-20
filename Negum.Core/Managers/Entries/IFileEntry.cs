namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a File entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFileEntry : IManagerSectionEntry<IFileEntry>
    {
        /// <summary>
        /// Path to the file. 
        /// </summary>
        string Path { get; }
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FileEntry : ManagerSectionEntry<IFileEntry>, IFileEntry
    {
        public string Path { get; private set; }

        public override IFileEntry Get()
        {
            this.Path = this.Section.GetValue<string>(this.FieldKey);

            return this;
        }
    }
}