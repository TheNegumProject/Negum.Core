using System.IO;
using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Readers;

namespace Negum.Core.Tests;

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
    protected async Task<IConfiguration> Parse(string path) => 
        await ParseInternal<IConfigurationReader>(path);

    protected async Task<IConfiguration> ParseWithSubsections(string path) => 
        await ParseInternal<IConfigurationWithSubsectionReader>(path);

    protected async Task<IConfiguration> ParseAnimation(string path) => 
        await ParseInternal<IAnimationReader>(path);

    protected async Task<IConfiguration> ParseConstants(string path) =>
        await ParseInternal<IConstantsReader>(path);

    private async Task<IConfiguration> ParseInternal<TReader>(string path)
        where TReader : IConfigurationReader
    {
        var reader = NegumContainer.Resolve<TReader>();
        var data = await reader.ReadAsync(path);
        return data;
    }
        
    protected static async Task<Stream> ReadFromUrl(string url)
    {
        var urlReader = NegumContainer.Resolve<IUrlReader>();
        var stream = await urlReader.ReadAsync(url);
        return stream;
    }
}