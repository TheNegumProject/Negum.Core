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
    public class NegumConfigurationManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg")]
        public async Task Should_Get_Appropriate_Key(string path)
        {
            this.InitializeContainer();
            
            var result = await this.Parse<INegumConfigurationParser, INegumConfiguration>(path);
            var key = NegumConfigurationManager.P1Keys.Keys.X;
            
            Assert.True(key == 108);
        }
    }
}