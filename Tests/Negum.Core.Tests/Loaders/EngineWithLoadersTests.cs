using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Xunit;

namespace Negum.Core.Tests.Loaders
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class EngineWithLoadersTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main")]
        public async Task Should_Read_Engine_Using_Registered_Loaders(string path)
        {
            this.InitializeContainer();

            var engineProvider = NegumContainer.Resolve<IEngineProvider>();
            var engine = await engineProvider.InitializeAsync(path);
            
            Assert.True(engine != null);
        }
    }
}