using System.IO;
using System.Threading.Tasks;
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

            var dir = this.GetDirectory(engine, "data").FullName;
            var data = new NegumData();

            data.ConfigManager = await this.FindManagerAsync<IConfigurationManager>(dir, configFileName);

            var motifFile = this.FindFile(dir, data.ConfigManager.Options.MotifFile);
            
            data.MotifManager = await this.FindManagerAsync<IMotifManager>(dir, data.ConfigManager.Options.MotifFile);
            data.MotifSprite = await this.GetSpriteAsync(motifFile.Directory.FullName, data.MotifManager.Files.SpriteFile);
            data.MotifSound = await this.GetSoundAsync(motifFile.Directory.FullName, data.MotifManager.Files.SoundFile);
            data.SelectionManager = await this.FindManagerAsync<ISelectionManager>(motifFile.Directory.FullName, data.MotifManager.Files.SelectionFile);
            data.FightManager = await this.FindManagerAsync<IFightManager>(motifFile.Directory.FullName, data.MotifManager.Files.FightFile);

            var motifLogoPath = data.MotifManager.Files.LogoStoryboardDefinition;

            if (!string.IsNullOrWhiteSpace(motifLogoPath))
            {
                data.Logo = await this.ReadStoryboardAsync(motifFile.Directory.FullName, motifLogoPath);
            }

            var motifIntroPath = data.MotifManager.Files.IntroStoryboardDefinition;

            if (!string.IsNullOrWhiteSpace(motifIntroPath))
            {
                data.Intro = await this.ReadStoryboardAsync(motifFile.Directory.FullName, motifIntroPath);
            }

            return data;
        }

        protected virtual async Task<IStoryboard> ReadStoryboardAsync(string dirName, string fileName)
        {
            var defFilePath = this.FindFile(dirName, fileName);
            var storyboard = new Storyboard();
            
            storyboard.Manager = await this.ReadManagerAsync<IStoryboardManager>(defFilePath);
            storyboard.Animation = await this.ReadManagerAsync<IAnimationManager, IAnimationReader>(defFilePath);
            storyboard.Sprite = await this.GetSpriteAsync(dirName, storyboard.Manager.SceneDef.SpriteFile);

            return storyboard;
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