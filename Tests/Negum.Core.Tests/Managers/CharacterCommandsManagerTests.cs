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
    public class CharacterCommandsManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/chars/kfm720/kfm720.cmd")]
        public async Task Should_Get_Appropriate_Key(string path)
        {
            this.InitializeContainer();
            
            var config = await this.ParseWithSubsections(path);
            var manager = (ICharacterCommandsManager) NegumContainer.Resolve<ICharacterCommandsManager>().UseConfiguration(config);
            var z = manager.Remap.Z;
            
            Assert.True(z.Equals("z"));

            var commandTime = manager.Defaults.CommandTime.GetTimeSpan();
            
            Assert.True(commandTime.Ticks == 15);
        }
    }
}