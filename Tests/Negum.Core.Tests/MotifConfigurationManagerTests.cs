using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Managers;
using Negum.Core.Parsers;
using Negum.Core.Scrappers;
using Xunit;

namespace Negum.Core.Tests
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/system.def")]
        public async Task Should_Return_Field_Value(string path)
        {
            this.InitializeContainer();

            var config = await this.Parse<IMotifConfigurationParser, IMotifConfiguration>(path);
            var scrapper = NegumContainer.Resolve<IConfigurationScrapper>().Setup(config);
            var manager = NegumContainer.Resolve<IMotifConfigurationManager>().Setup(scrapper);
            var animation = manager.SelectInfo.Player1.Cursor.Animation.Animation;
            
            Assert.True(animation == 160);
        }
    }
}