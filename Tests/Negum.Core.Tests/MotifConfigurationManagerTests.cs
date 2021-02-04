using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Managers;
using Negum.Core.Parsers;
using Xunit;

namespace Negum.Core.Tests
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/system.def")]
        public async Task Should_Return_Field_Value(string path)
        {
            this.InitializeContainer();

            var parsed = await this.Parse<IMotifConfigurationParser, IMotifConfiguration>(path);
            var animation = MotifConfigurationManager.SelectInfo.Player1.Cursor.Animation.Animation;
            
            Assert.True(animation == 160);
        }
    }
}