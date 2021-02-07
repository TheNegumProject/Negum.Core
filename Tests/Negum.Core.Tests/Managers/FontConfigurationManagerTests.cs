using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers;
using Negum.Core.Scrappers;
using Xunit;

namespace Negum.Core.Tests.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/font/f-4x6.def")]
        public async Task Should_Read_Data(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var scrapper = NegumContainer.Resolve<IConfigurationScrapper>().Setup(config);
            var manager = NegumContainer.Resolve<IFontConfigurationManager>().Setup(scrapper);

            Assert.True(manager.Def.Type.Equals("bitmap"));
        }
    }
}