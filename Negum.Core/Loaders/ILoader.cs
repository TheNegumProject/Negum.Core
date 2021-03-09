using System.Threading.Tasks;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Loaders are a layer above Readers.
    /// They are used to read parts of the engine (Stages, Sounds, Fonts, Data, Characters, etc.).
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ILoader<in TInput, TOutput>
    {
        /// <summary>
        /// Loads elements from the specified path or URL.
        /// </summary>
        /// <returns>New task</returns>
        Task<TOutput> LoadAsync(TInput input);
    }
}