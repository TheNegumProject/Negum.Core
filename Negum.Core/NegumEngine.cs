using Negum.Core.Configurations;

namespace Negum.Core
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumEngine : INegumEngine
    {
        public static INegumEngine Instance { get; } = NegumContainer.Resolve<INegumEngine>();
        
        public INegumConfiguration Configuration { get; }

        public NegumEngine()
        {
            this.Configuration = NegumContainer.Resolve<INegumConfiguration>();
        }
    }
}
