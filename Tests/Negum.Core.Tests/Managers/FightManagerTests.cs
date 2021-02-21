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
    public class FightManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/fight.def")]
        public async Task Should_Parse_Win_Text(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var manager = (IFightManager) NegumContainer.Resolve<IFightManager>().UseConfiguration(config);
            var text = manager.Round.WinText.Text;

            Assert.True(text.Equals("%s Wins"));
        }
    }
}