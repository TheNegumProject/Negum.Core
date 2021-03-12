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
    public class AnimationManagerTests : TestBase
    {
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm/kfm.air")]
        public async Task Should_Parse_Animation_Config_To_Manager(string path)
        {
            this.InitializeContainer();

            var config = await this.ParseAnimation(path);
            var manager = (IAnimationManager) NegumContainer.Resolve<IAnimationManager>().UseConfiguration(config);
            
            Assert.True(manager.Animations.Count() == 117);
        }
    }
}