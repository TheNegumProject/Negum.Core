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
public class CharacterManagerTests : TestBase
{
    [Theory]
    [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.def")]
    public async Task Should_Read_Character_Data(string path)
    {
        var config = await Parse(path);
        var manager = (ICharacterManager) NegumContainer.Resolve<ICharacterManager>().UseConfiguration(config);
        var displayName = manager.Info.DisplayName;
            
        Assert.True(displayName.Equals("Kung Fu Man"));
    }
}