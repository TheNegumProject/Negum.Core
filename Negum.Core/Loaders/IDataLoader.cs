using System.IO;
using System.Threading.Tasks;
using Negum.Core.Engines;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Data;

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

            var dir = this.GetDirectory(engine, "data").FullName;
            var data = new NegumData();

            data.ConfigManager = await this.FindManagerAsync<IConfigurationManager>(dir, configFileName);

            var motifFileName = data.ConfigManager.Options.MotifFile;
            var motifFile = this.FindFile(dir, motifFileName);

            if (motifFile == null)
            {
                throw new FileNotFoundException($"Cannot find motif file: {motifFileName}");
            }

            var motifDirFullName = motifFile.Directory.FullName;

            data.MotifManager = await this.FindManagerAsync<IMotifManager>(dir, data.ConfigManager.Options.MotifFile);
            data.MotifSprite = await this.GetSpriteAsync(motifDirFullName, data.MotifManager.Files.SpriteFile);
            data.MotifSound = await this.GetSoundAsync(motifDirFullName, data.MotifManager.Files.SoundFile);
            data.SelectionManager = await this.FindManagerAsync<ISelectionManager>(motifDirFullName, data.MotifManager.Files.SelectionFile);
            data.FightManager = await this.FindManagerAsync<IFightManager>(motifDirFullName, data.MotifManager.Files.FightFile);
            data.Logo = await this.ReadStoryboardAsync(motifDirFullName, data.MotifManager.Files.LogoStoryboardDefinition);
            data.Intro = await this.ReadStoryboardAsync(motifDirFullName, data.MotifManager.Files.IntroStoryboardDefinition);

            return data;
        }

        protected override FileInfo FindFile(string dirName, string fileName)
        {
            if (fileName.StartsWith("data/"))
            {
                fileName = fileName.Replace("data/", "");
            }

            return base.FindFile(dirName, fileName);
        }
    }
}