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
    public class SelectionManagerTests : TestBase
    {
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/select.def")]
        public async Task Should_Read_Selection_Data(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var manager = (ISelectionManager) NegumContainer.Resolve<ISelectionManager>().UseConfiguration(config);

            Assert.True(manager.Characters.Characters.Count() == 2);
            Assert.True(manager.Stages.StageFiles.Count() == 1);
            Assert.True(manager.Options.ArcadeMaxMatches.RawValue.Equals("6,1,1,0,0,0,0,0,0,0"));
            Assert.True(manager.Options.TeamMaxMatches.RawValue.Equals("4,1,1,0,0,0,0,0,0,0"));
        }
    }
}