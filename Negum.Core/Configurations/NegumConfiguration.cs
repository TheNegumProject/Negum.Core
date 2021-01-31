namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfiguration : INegumConfiguration
    {
        public INegumSettings Settings { get; }
        public INegumSelection Selection { get; }
        public INegumSystem System { get; }

        public NegumConfiguration()
        {
            Settings = NegumContainer.Resolve<INegumSettings>();
            Selection = NegumContainer.Resolve<INegumSelection>();
            System = NegumContainer.Resolve<INegumSystem>();
        }
    }
}