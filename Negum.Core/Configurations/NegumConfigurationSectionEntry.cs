namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class NegumConfigurationSectionEntry : INegumConfigurationSectionEntry
    {
        public string Content { get; internal set; }
    }
}