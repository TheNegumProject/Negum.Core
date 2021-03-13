using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Loaders;

namespace Negum.Core.Engines
{
    /// <summary>
    /// Provider which is used to create IEngine instance.
    /// One provider can create multiple instances of the game objects.
    /// Thanks to that user can select different paths from which to load data without quitting the game nor restarting.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IEngineProvider
    {
        /// <summary>
        /// Creates new instance of the IEngine object from the specified path.
        /// Each call will create new instance of the IEngine.
        /// Instances are not cached anywhere so it is users responsibility to keep created instance.
        /// Otherwise it will need to be created one more time.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Engine instance populated from the specified path.</returns>
        Task<IEngine> InitializeAsync(string path);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class EngineProvider : IEngineProvider
    {
        public async Task<IEngine> InitializeAsync(string path)
        {
            var engine = new EngineInstance
            {
                Path = path
            };

            engine.Data = await NegumContainer.Resolve<IDataLoader>().LoadAsync(engine);
            engine.Fonts = await NegumContainer.Resolve<IFontLoader>().LoadAsync(engine);
            engine.Sounds = await NegumContainer.Resolve<ISoundLoader>().LoadAsync(engine);
            engine.Stages = await NegumContainer.Resolve<IStageLoader>().LoadAsync(engine);
            engine.Characters = await NegumContainer.Resolve<ICharacterLoader>().LoadAsync(engine);

            return engine;
        }
    }
}