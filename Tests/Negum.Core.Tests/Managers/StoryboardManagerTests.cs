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

            var introConfig = await this.ParseAnimation(path);
            var introManager = (IAnimationManager) NegumContainer.Resolve<IAnimationManager>().UseConfiguration(introConfig);
            var actions = introManager.Animations;

            Assert.True(actions.Count() == 3);
            Assert.True(actions.ElementAt(0).ActionNumber == 0);
            Assert.True(actions.ElementAt(0).Parts.Count() == 1);
            Assert.True(actions.ElementAt(1).ActionNumber == 1);
            Assert.True(actions.ElementAt(1).Parts.Count() == 1);
            Assert.True(actions.ElementAt(2).Parts.Count() == 1);
            Assert.True(actions.ElementAt(2).Parts.ElementAt(0).Frames.Count() == 2301);
        }
    }
}