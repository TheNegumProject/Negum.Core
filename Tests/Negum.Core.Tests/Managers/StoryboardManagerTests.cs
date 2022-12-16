using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers.Types;
using Xunit;

namespace Negum.Core.Tests.Managers;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class StoryboardManagerTests : TestBase
{
    [Theory]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/intro.def", 5)]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/ending.def", 3)]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm/intro.def", 5)]
    public async Task Should_Count_Number_Of_Scenes(string path, int sceneCount)
    {
        var config = await ParseWithSubsections(path);
        var manager = (IStoryboardManager) NegumContainer.Resolve<IStoryboardManager>().UseConfiguration(config);
        var scenes = manager.Scenes;

        Assert.True(scenes.Count() == sceneCount);
    }

    [Theory]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/DragonBallMugenEdition2009/main/data/Backup/intro.def")]
    public async Task Should_Count_Number_Of_Scenes_And_Print_Details(string path)
    {
        var config = await ParseWithSubsections(path);
        var manager = (IStoryboardManager) NegumContainer.Resolve<IStoryboardManager>().UseConfiguration(config);
        var scenes = manager.Scenes.ToList();

        Assert.True(scenes.Count == 3);

        var time = scenes[0].FadeInTime;
        
        Assert.True(time is not null);
        
        var timeDetails = time.GetTimeSpan()?.Ticks;

        Assert.True(timeDetails == 35);

        var introConfig = await ParseAnimation(path);
        var introManager = (IAnimationManager) NegumContainer.Resolve<IAnimationManager>().UseConfiguration(introConfig);
        var actions = introManager.Animations.ToList();

        Assert.True(actions.Count == 3);
        Assert.True(actions.ElementAt(0).ActionNumber == 0);
        Assert.True(actions.ElementAt(0).Parts.Count() == 1);
        Assert.True(actions.ElementAt(1).ActionNumber == 1);
        Assert.True(actions.ElementAt(1).Parts.Count() == 1);
        Assert.True(actions.ElementAt(2).Parts.Count() == 1);
        Assert.True(actions.ElementAt(2).Parts.ElementAt(0).Frames.Count() == 2301);
    }
}