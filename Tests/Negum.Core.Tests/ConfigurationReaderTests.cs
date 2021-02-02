using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
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
    public class ConfigurationReaderTests
    {
        [Fact]
        public async Task Should_Return_All_Lines()
        {
            const string path = "/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg";
                
            NegumContainer.RegisterKnownTypes();

            var reader = NegumContainer.Resolve<IConfigurationReader>();
            var result = await reader.ReadAsync(path);
            
            Assert.True(result.Any());
        }
    }
}