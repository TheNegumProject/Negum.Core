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
    public class CharacterStoryboardSceneManagerTests : TestBase
    {
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/intro.def", 5)]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/ending.def", 3)]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm/intro.def", 5)]
        public async Task Should_Count_Number_Of_Scenes(string path, int sceneCount)
        {
            this.InitializeContainer();
            
            var config = await this.ParseWithSubsections(path);
            var manager = (ICharacterStoryboardSceneManager) NegumContainer.Resolve<ICharacterStoryboardSceneManager>().UseConfiguration(config);
            var scenes = manager.Scenes;
            
            Assert.True(scenes.Count() == sceneCount);
        }
    }
}