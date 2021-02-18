using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers.Types;
using Xunit;

namespace Negum.Core.Tests.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg")]
        public async Task Should_Get_Appropriate_Key(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var scrapper = NegumContainer.Resolve<IConfigurationScrapper>().Setup(config);
            var manager = (IConfigNegumManager) NegumContainer.Resolve<IConfigNegumManager>().Setup(scrapper);
            var key = manager.P1Keys.Keys.X;
            
            Assert.True(key == 108);
        }
    }
}