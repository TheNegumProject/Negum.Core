using System.Threading.Tasks;

namespace Negum.Core.Parsers
{
    /// <summary>
    /// Defines general parsing functionality.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IParser<in TInput, TOutput>
    {
        /// <summary>
        /// Parses given input into the specified output.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Parsed data.</returns>
        Task<TOutput> ParseAsync(TInput input);
    }
}