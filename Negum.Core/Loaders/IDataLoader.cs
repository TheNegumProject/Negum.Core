using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Data;
using Negum.Core.Readers;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Loader used to read everything from "data" directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDataLoader : IEngineModuleLoader<IData>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class DataLoader : AbstractLoader, IDataLoader
    {
        public async Task<IData> LoadAsync(IEngine engine)
        {
            const string configFileName = "mugen.cfg";

            var dir = this.GetDirectory(engine, "data");
            var data = new NegumData();

            data.ConfigManager = await this.ReadManagerAsync<IConfigurationManager>(this.FindFile(dir, configFileName));

            var motifConfigPath = data.ConfigManager.Options.MotifFile;
            var motifFile = this.FindFile(dir, motifConfigPath);
            data.MotifManager = await this.ReadManagerAsync<IMotifManager>(motifFile);

            var motifSpritePath = data.MotifManager.Files.SpriteFile;
            var motifSpriteFullPath = this.FindFile(motifFile.Directory, motifSpritePath).FullName;
            var spriteReader = NegumContainer.Resolve<ISpritePathReader>();
            data.MotifSprite = await spriteReader.ReadAsync(motifSpriteFullPath);

            var motifSoundPath = data.MotifManager.Files.SoundFile;
            var motifSoundFullPath = this.FindFile(motifFile.Directory, motifSoundPath).FullName;
            var soundReader = NegumContainer.Resolve<ISoundPathReader>();
            data.MotifSound = await soundReader.ReadAsync(motifSoundFullPath);

            var motifSelectPath = data.MotifManager.Files.SelectionFile;
            var motifSelectFullPath = this.FindFile(motifFile.Directory, motifSelectPath);
            data.SelectionManager = await this.ReadManagerAsync<ISelectionManager>(motifSelectFullPath);

            var motifFightPath = data.MotifManager.Files.FightFile;
            var motifFightFullPath = this.FindFile(motifFile.Directory, motifFightPath);
            data.FightManager = await this.ReadManagerAsync<IFightManager>(motifFightFullPath);

            var motifLogoPath = data.MotifManager.Files.LogoStoryboardDefinition;

            if (!string.IsNullOrWhiteSpace(motifLogoPath))
            {
                var motifLogoFullPath = this.FindFile(motifFile.Directory, motifLogoPath);
                data.LogoManager = await this.ReadManagerAsync<IStoryboardManager>(motifLogoFullPath);
            }

            var motifIntroPath = data.MotifManager.Files.IntroStoryboardDefinition;

            if (!string.IsNullOrWhiteSpace(motifIntroPath))
            {
                var motifIntroFullPath = this.FindFile(motifFile.Directory, motifIntroPath);
                data.IntroManager = await this.ReadManagerAsync<IStoryboardManager>(motifIntroFullPath);
            }

            return data;
        }

        protected virtual FileInfo FindFile(DirectoryInfo dataDir, string fileName)
        {
            if (fileName.StartsWith("data/"))
            {
                fileName = fileName.Replace("data/", "");
            }

            var fullPath = Path.Combine(dataDir.FullName, fileName);
            var file = new FileInfo(fullPath);

            if (file.Exists)
            {
                return file;
            }

            while (!file.Exists)
            {
                fullPath = Path.Combine(file.Directory.Parent.FullName, file.Name);
                file = new FileInfo(fullPath);
            }

            return file;
        }
    }
}