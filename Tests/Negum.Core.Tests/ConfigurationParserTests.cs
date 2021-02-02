using System.Threading.Tasks;
using Negum.Core.Cleaners;
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
    public class ConfigurationParserTests
    {
        public class ConfigurationCleanerTests
        {
            [Fact]
            public async Task Should_Clean_Read_Configuration()
            {
                const string path = "/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg";

                NegumContainer.RegisterKnownTypes();

                var reader = NegumContainer.Resolve<IConfigurationReader>();
                var data = await reader.ReadAsync(path);

                var cleaner = NegumContainer.Resolve<IConfigurationCleaner>();
                var cleaned = await cleaner.CleanAsync(data);

                var parser = NegumContainer.Resolve<IConfigurationParser>();
                var result = await parser.ParseAsync(cleaned);

                Assert.True(result != null);
            }
        }
    }
}