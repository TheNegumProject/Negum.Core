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
public class ConstantsManagerTests : TestBase
{
    [Theory]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/common1.cns")]
    public async Task Should_Get_State_Value(string path)
    {
        var config = await ParseConstants(path);
        var manager = (IConstantsManager) NegumContainer.Resolve<IConstantsManager>().UseConfiguration(config);

        var stateDef = manager.GetStateDef(132);
            
        Assert.True(stateDef.Type.Equals("A"));
        Assert.True(stateDef.Physics.Equals("N"));

        var states = manager.GetStates(132);
        var state = states.FirstOrDefault(s => s.Value?.Equals("52") ?? false);
            
        Assert.True(state.Triggers.Count() == 1);
        Assert.True(state.Type.Equals("ChangeState"));
    }
}