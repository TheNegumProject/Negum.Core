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
public class ConfigurationManagerTests : TestBase
{
    [Theory]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/mugen.cfg")]
    public async Task Should_Get_Appropriate_Key(string path)
    {
        var config = await Parse(path);
        var manager = (IConfigurationManager) NegumContainer.Resolve<IConfigurationManager>().UseConfiguration(config);
        var key = manager.P1Keys.Keys.X;
            
        Assert.True(key == 108);
    }
}