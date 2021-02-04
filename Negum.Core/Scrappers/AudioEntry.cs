namespace Negum.Core.Scrappers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class AudioEntry : IAudioEntry
    {
        private string Value { get; set; }
        
        public IAudioEntry From(string value)
        {
            this.Value = value;
            return this;
        }
    }
}