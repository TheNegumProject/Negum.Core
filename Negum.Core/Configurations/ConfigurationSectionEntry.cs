namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationSectionEntry : IConfigurationSectionEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}