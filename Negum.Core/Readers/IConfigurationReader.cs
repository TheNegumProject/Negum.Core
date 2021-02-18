namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle specific configuration file by it's path.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationReader<TOutput> : IFileReader<TOutput>
    {
    }
}