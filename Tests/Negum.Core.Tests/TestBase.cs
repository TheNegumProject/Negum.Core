using System.Threading.Tasks;
using Negum.Core.Cleaners;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Parsers;
using Negum.Core.Readers;

namespace Negum.Core.Tests
{
    /// <summary>
    /// Base class for all tests.
    /// All tests are performed for as much raw engine as possible.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class TestBase
    {
        protected void InitializeContainer()
        {
            NegumContainer.RegisterKnownTypes();
        }

        protected async Task<IConfigurationDefinition> Parse(string path)
        {
            var reader = NegumContainer.Resolve<IConfigurationReader>();
            var data = await reader.ReadAsync(path);

            var cleaner = NegumContainer.Resolve<IConfigurationCleaner>();
            var cleaned = await cleaner.CleanAsync(data);

            var parser = NegumContainer.Resolve<IConfigurationParser>();
            var result = await parser.ParseAsync(cleaned);

            return result;
        }
    }
}