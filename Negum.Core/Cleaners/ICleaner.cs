using System.Threading.Tasks;

namespace Negum.Core.Cleaners
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICleaner<in TInput, TOutput>
    {
        /// <summary>
        /// Cleans given parameter and returns value after cleaning.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Given input after the cleaning process.</returns>
        Task<TOutput> CleanAsync(TInput input);
    }
}