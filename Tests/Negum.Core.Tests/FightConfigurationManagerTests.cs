using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers;
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
    public class FightConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/fight.def")]
        public async Task Should_Parse_Win_Text(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var scrapper = NegumContainer.Resolve<IConfigurationScrapper>().Setup(config);
            var manager = NegumContainer.Resolve<IFightConfigurationManager>().Setup(scrapper);
            var text = manager.Round.WinText.Text;
            
            Assert.True(text.Equals("%s Wins"));
        }
    }
}