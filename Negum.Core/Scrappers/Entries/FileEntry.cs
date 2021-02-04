namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FileEntry : IFileEntry
    {
        private string Value { get; set; }
        
        public IFileEntry From(string value)
        {
            this.Value = value;
            return this;
        }
    }
}