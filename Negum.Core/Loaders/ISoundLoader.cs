using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Models.Sounds;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Loader used to get all currently available Sounds.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISoundLoader : IDirectoryLoader<IEnumerable<ISound>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SoundLoader : ISoundLoader
    {
        public async Task<IEnumerable<ISound>> LoadAsync(DirectoryInfo dir)
        {
            var tasks = dir.GetFiles()
                .Select(this.GetSoundAsync)
                .ToArray();

            Task.WaitAll(tasks);

            var sounds = tasks
                .Select(task => task.Result)
                .ToList();

            return sounds;
        }

        protected virtual async Task<ISound> GetSoundAsync(FileInfo file)
        {
            return await Task.FromResult(new Sound
            {
                File = file
            });
        }
    }
}