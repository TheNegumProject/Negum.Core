using System.Linq;
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
    public class StageManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/stages/stage0.def")]
        public async Task Should_Get_Number_Of_Backgrounds(string path)
        {
            this.InitializeContainer();

            var config = await this.ParseWithSubsections(path);
            var manager = (IStageManager) NegumContainer.Resolve<IStageManager>().UseConfiguration(config);
            var backgrounds = manager.Backgrounds;

            Assert.True(backgrounds.Count() == 2);
        }
    }
}