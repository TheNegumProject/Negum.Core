using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;
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
            try
            {
                NegumContainer.RegisterKnownTypes();
            }
            catch (Exception e)
            {
                /***
                 * Multiple tests may try to register it multiple times.
                 * This should not happen is real-life scenario.
                 */
            }
        }

        protected async Task<Stream> ReadFromUrl(string url)
        {
            var urlReader = NegumContainer.Resolve<IUrlReader>();
            var stream = await urlReader.ReadAsync(url);
            return stream;
        }

        protected async Task<IConfiguration> Parse(string path) => 
            await this.ParseInternal<IConfigurationReader>(path);

        protected async Task<IConfiguration> ParseWithSubsections(string path) => 
            await this.ParseInternal<IConfigurationWithSubsectionReader>(path);

        protected async Task<IConfiguration> ParseAnimation(string path) => 
            await this.ParseInternal<IAnimationReader>(path);

        protected async Task<IConfiguration> ParseConstants(string path) =>
            await this.ParseInternal<IConstantsReader>(path);

        private async Task<IConfiguration> ParseInternal<TReader>(string path)
            where TReader : IConfigurationReader
        {
            var reader = NegumContainer.Resolve<TReader>();
            var data = await reader.ReadAsync(path);
            return data;
        }
    }
}