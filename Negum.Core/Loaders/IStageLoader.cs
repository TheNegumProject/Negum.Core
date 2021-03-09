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
    public interface IStageLoader : IReader<DirectoryInfo, IEnumerable<IStage>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageLoader : IStageLoader
    {
        public async Task<IEnumerable<IStage>> ReadAsync(DirectoryInfo dir)
        {
            var tasks = dir.GetFiles()
                .Where(file => file.Extension.Equals(".def"))
                .Select(this.GetStageAsync)
                .ToArray();

            Task.WaitAll(tasks);

            var stages = tasks
                .Select(task => task.Result)
                .ToList();
            
            return stages;
        }

        protected virtual async Task<IStage> GetStageAsync(FileInfo defFile)
        {
            var reader = NegumContainer.Resolve<IConfigurationWithSubsectionReader>();
            var configuration = await reader.ReadAsync(defFile.FullName);
            
            var manager = (IStageManager) NegumContainer.Resolve<IStageManager>().UseConfiguration(configuration);

            var spriteFilePath = Path.Combine(defFile.DirectoryName, manager.BackgroundDef.SpriteFile);
            var fileContentReader = NegumContainer.Resolve<IFileContentReader>();
            var fileContentStream = await fileContentReader.ReadAsync(spriteFilePath);

            var spriteReader = NegumContainer.Resolve<ISpriteReader>();
            var sprite = await spriteReader.ReadAsync(fileContentStream);

            return InitializeStage(manager, sprite);
        }

        protected virtual IStage InitializeStage(IStageManager manager, ISprite sprite)
        {
            var stage = new Stage
            {
                Manager = manager,
                Sprite = sprite
            };
        
            return stage;
        }
    }
}