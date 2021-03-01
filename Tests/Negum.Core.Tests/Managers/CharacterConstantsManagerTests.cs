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
    public class CharacterConstantsManagerTests : TestBase
    {
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.cns")]
        public async Task Should_Read_Character_Constants(string path)
        {
            this.InitializeContainer();

            var config = await this.ParseConstants(path);
            var manager = (ICharacterConstantsManager) NegumContainer.Resolve<ICharacterConstantsManager>().UseConfiguration(config);
            
            Assert.True(manager.Data.AirJuggle == 15);
            Assert.True(manager.Size.AirFront == 48);
            Assert.True(manager.Movement.TripGroundLevel == 60);
            Assert.True(manager.Quotes.Victories.Count() == 7);

            var stateDef = manager.GetStateDef(410);
            
            Assert.True(stateDef.PowerAdd.Equals("25"));

            var state = manager.GetStates(410).FirstOrDefault(s => s.Value?.Equals("11") ?? false);
            
            Assert.True(state.Control.Equals("1"));
        }
    }
}