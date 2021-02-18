using System.Linq;
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
    public class SelectionConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/select.def")]
        public async Task Should_Read_Data(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var scrapper = NegumContainer.Resolve<IConfigurationScrapper>().Setup(config);
            var manager = (ISelectionNegumManager) NegumContainer.Resolve<ISelectionNegumManager>().Setup(scrapper);

            Assert.True(manager.Characters.Characters.Count() == 2);
            Assert.True(manager.Stages.StageFiles.Count() == 1);
            Assert.True(manager.Options.ArcadeMaxMatches.RawValue.Equals("6,1,1,0,0,0,0,0,0,0"));
            Assert.True(manager.Options.TeamMaxMatches.RawValue.Equals("4,1,1,0,0,0,0,0,0,0"));
        }
    }
}