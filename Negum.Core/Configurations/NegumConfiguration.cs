namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfiguration : ConfigurationDefinition, INegumConfiguration
    {
        public bool IsInitialized { get; set; }
    }
}