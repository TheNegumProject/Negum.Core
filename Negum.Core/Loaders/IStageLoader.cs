using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Sprites;
using Negum.Core.Models.Stages;
using Negum.Core.Readers;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Loader used to get all currently available Stages.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageLoader : IDirectoryLoader<IEnumerable<IStage>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageLoader : AbstractLoader, IStageLoader
    {
        public async Task<IEnumerable<IStage>> LoadAsync(DirectoryInfo dir)
        {
            var sources = dir.GetFiles()
                .Where(file => file.Extension.Equals(".def"));

            return await this.LoadMultipleAsync(sources, this.GetStageAsync);
        }

        protected virtual async Task<IStage> GetStageAsync(FileInfo defFile)
        {
            var reader = NegumContainer.Resolve<IConfigurationWithSubsectionReader>();
            var configuration = await reader.ReadAsync(defFile.FullName);

            var manager = (IStageManager) NegumContainer.Resolve<IStageManager>().UseConfiguration(configuration);

            var spritePathReader = NegumContainer.Resolve<ISpritePathReader>();
            var sprite =
                await spritePathReader.ReadAsync(Path.Combine(defFile.DirectoryName, manager.BackgroundDef.SpriteFile));

            return InitializeStage(defFile, manager, sprite);
        }

        protected virtual IStage InitializeStage(FileInfo defFile, IStageManager manager, ISprite sprite)
        {
            var stage = new Stage
            {
                File = defFile,
                Manager = manager,
                Sprite = sprite
            };

            return stage;
        }
    }
}