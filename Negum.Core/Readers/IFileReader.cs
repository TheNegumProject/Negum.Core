namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle file by it's path.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFileReader<TOutput> : IReader<string, TOutput>
    {
    }
}