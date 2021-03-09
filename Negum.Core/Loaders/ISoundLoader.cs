using System.Collections.Generic;
using System.IO;
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
    public class SoundLoader : AbstractLoader, ISoundLoader
    {
        public async Task<IEnumerable<ISound>> LoadAsync(DirectoryInfo dir) =>
            await this.LoadMultipleAsync(dir.GetFiles(), this.GetSoundAsync);

        protected virtual async Task<ISound> GetSoundAsync(FileInfo file)
        {
            return await Task.FromResult(new Sound
            {
                File = file
            });
        }
    }
}