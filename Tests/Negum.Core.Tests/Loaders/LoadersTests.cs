using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Loaders;
using Negum.Core.Models.Characters;
using Negum.Core.Models.Fonts;
using Negum.Core.Models.Sounds;
using Negum.Core.Models.Stages;
using Xunit;

namespace Negum.Core.Tests.Loaders
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class LoadersTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/stages")]
        public async Task Should_Read_Stages_From_Directory(string path)
        {
            var stages = await this.InitializeMultipleTest<IStage, IStageLoader>(path);

            if (stages == null)
            {
                return;
            }
            
            Assert.True(stages.Count() == 3);
        }

        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/sound")]
        public async Task Should_Read_Sounds_From_Directory(string path)
        {
            var sounds = await this.InitializeMultipleTest<ISound, ISoundLoader>(path);
            
            if (sounds == null)
            {
                return;
            }
            
            Assert.True(sounds.Any());
        }
        
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/font")]
        public async Task Should_Read_Fonts_From_Directory(string path)
        {
            var fonts = await this.InitializeMultipleTest<IFont, IFontLoader>(path);
            
            if (fonts == null)
            {
                return;
            }
            
            Assert.True(fonts.Count() == 19);
        }

        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/chars")]
        public async Task Should_Read_Characters_From_Directory(string path)
        {
            var characters = await this.InitializeMultipleTest<ICharacter, ICharacterLoader>(path);
            
            if (characters == null)
            {
                return;
            }
            
            Assert.True(characters.Any());
        }

        private async Task<IEnumerable<TOutput>> InitializeMultipleTest<TOutput, TLoader>(string path)
            where TLoader : IDirectoryLoader<IEnumerable<TOutput>>
        {
            this.InitializeContainer();

            var directory = new DirectoryInfo(path);

            // Prevent CI/CD from crashing
            if (!directory.Exists)
            {
                return default;
            }

            var loader = NegumContainer.Resolve<TLoader>();
            var entities = await loader.LoadAsync(directory);

            return entities;
        }
    }
}