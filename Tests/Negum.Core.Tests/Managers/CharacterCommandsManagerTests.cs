using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers.Entries;
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
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.cmd")]
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

        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.cmd")]
        public async Task Should_Parse_Triggers(string path)
        {
            this.InitializeContainer();
            
            var config = await this.ParseConstants(path);
            var manager = (ICharacterCommandsManager) NegumContainer.Resolve<ICharacterCommandsManager>().UseConfiguration(config);
            var states = manager.States;
            
            Assert.True(states.Any());

            var state = states.FirstOrDefault();
            
            Assert.True(state != null);

            var triggers = state.Triggers;
            
            Assert.True(triggers.Any());

            var trigger = triggers.FirstOrDefault();
            
            Assert.True(trigger != null);
            Assert.True(trigger.IsTriggerAll);
            Assert.True(trigger.NameRaw.Equals(TriggerEntry.TriggerAllKey));
            Assert.True(trigger.ExpressionRaw.Equals("command = SmashKFUpper"));
        }
    }
}