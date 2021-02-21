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
    public class MotifManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/system.def")]
        public async Task Should_Return_Field_Value(string path)
        {
            this.InitializeContainer();

            var config = await this.ParseWithSubsections(path);
            var manager = (IMotifManager) NegumContainer.Resolve<IMotifManager>().UseConfiguration(config);
            var animation = manager.SelectInfo.Player1.Cursor.Animation.Animation;
            
            Assert.True(animation == 160);
            
            var titleBgsSections = manager.TitleBgs;
            
            Assert.True(titleBgsSections.Count() == 6);
        }
    }
}