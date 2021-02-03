using System.Threading.Tasks;
using Negum.Core.Cleaners;
using Negum.Core.Configurations.Managers;
using Negum.Core.Containers;
using Negum.Core.Parsers;
using Negum.Core.Readers;
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
            
            var reader = NegumContainer.Resolve<IConfigurationReader>();
            var data = await reader.ReadAsync(path);

            var cleaner = NegumContainer.Resolve<IConfigurationCleaner>();
            var cleaned = await cleaner.CleanAsync(data);

            var parser = NegumContainer.Resolve<INegumConfigurationParser>();
            var result = await parser.ParseAsync(cleaned);
            
            var key = NegumConfigurationManager.P1Keys.Keys.X;
            Assert.True(key == 108);
        }
    }
}