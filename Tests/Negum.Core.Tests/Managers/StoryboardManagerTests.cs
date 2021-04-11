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
    public class StoryboardManagerTests : TestBase
    {
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/DragonBallMugenEdition2009/main/data/Backup/intro.def")]
        public async Task Should_Count_Number_Of_Scenes_And_Print_Details(string path)
        {
            this.InitializeContainer();

            var config = await this.ParseWithSubsections(path);
            var manager = (IStoryboardManager) NegumContainer.Resolve<IStoryboardManager>().UseConfiguration(config);
            var scenes = manager.Scenes;

            Assert.True(scenes.Count() == 3);

            var time = scenes.FirstOrDefault().FadeInTime;
            var timeDetails = time.GetTimeSpan().Ticks;

            Assert.True(timeDetails == 35);
        }
    }
}