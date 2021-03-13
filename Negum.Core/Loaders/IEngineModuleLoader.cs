using Negum.Core.Engines;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Represents a loader which is used to read part of a provided IEngine.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IEngineModuleLoader<TOutput> : ILoader<IEngine, TOutput>
    {
    }
}