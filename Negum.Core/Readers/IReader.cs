using System.Threading.Tasks;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reads from specified input and returns in a designed format.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IReader<in TInput, TOutput>
    {
        /// <summary>
        /// Reads data from given input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Data in a desired format.</returns>
        Task<TOutput> ReadAsync(TInput input);
    }
}