using System.Threading.Tasks;
using Negum.Core.Configurations;
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
    public class ConfigurationParserTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg")]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/system.def")]
        public async Task Should_Parse_Configuration(string path)
        {
            this.InitializeContainer();
            
            var result = await this.Parse<IConfigurationParser, IConfigurationDefinition>(path);
            
            Assert.True(result != null);
        }

        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/system.def")]
        public async Task Should_Parse_Motif(string path)
        {
            this.InitializeContainer();
            
            var result = await this.Parse<IMotifConfigurationParser, IMotifConfiguration>(path);
            
            Assert.True(result != null);
        }
    }
}