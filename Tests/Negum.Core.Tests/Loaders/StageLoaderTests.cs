using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Loaders;
using Xunit;

namespace Negum.Core.Tests.Loaders
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageLoaderTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/stages")]
        public async Task Should_Read_Stages_From_Directory(string path)
        {
            this.InitializeContainer();

            var directory = new DirectoryInfo(path);

            // Prevent CI/CD from crashing
            if (!directory.Exists)
            {
                return;
            }
            
            var stageLoader = NegumContainer.Resolve<IStageLoader>();
            var stages = await stageLoader.LoadAsync(directory);
            
            Assert.True(stages.Count() == 3);
        }

        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/sound")]
        public async Task Should_Read_Sounds_From_Directory(string path)
        {
            this.InitializeContainer();

            var directory = new DirectoryInfo(path);

            // Prevent CI/CD from crashing
            if (!directory.Exists)
            {
                return;
            }

            var soundLoader = NegumContainer.Resolve<ISoundLoader>();
            var sounds = await soundLoader.LoadAsync(directory);
            
            Assert.True(sounds.Any());
        }
        
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/font")]
        public async Task Should_Read_Fonts_From_Directory(string path)
        {
            this.InitializeContainer();

            var directory = new DirectoryInfo(path);

            // Prevent CI/CD from crashing
            if (!directory.Exists)
            {
                return;
            }

            var fontLoader = NegumContainer.Resolve<IFontLoader>();
            var fonts = await fontLoader.LoadAsync(directory);
            
            Assert.True(fonts.Count() == 19);
        }
    }
}