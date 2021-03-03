using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Configurations.Animations;
using Negum.Core.Containers;
using Negum.Core.Readers;
using Xunit;

namespace Negum.Core.Tests.Readers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationReaderTests : TestBase
    {
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/mugen.cfg")]
        public async Task Should_Read_Configuration(string file)
        {
            this.InitializeContainer();
            var config = await this.Parse(file);
            Assert.True(config.Any());
        }

        [Theory]
        [InlineData("TitleBGdef", 6)]
        [InlineData("SelectBGdef", 4)]
        [InlineData("VersusBGdef", 13)]
        [InlineData("VictoryBGdef", 3)]
        [InlineData("OptionBGdef", 1)]
        public async Task Should_Read_Motif_With_Subsections(string sectionName, int subsectionsCount)
        {
            const string filePath =
                "https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/mugen1/system.def";
            this.InitializeContainer();
            var config = await this.ParseWithSubsections(filePath);
            var section = config.FirstOrDefault(s => s.Name.Equals(sectionName));
            Assert.True(section.Subsections.Count() == subsectionsCount);
        }

        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.air")]
        public async Task Should_Read_Animation_File(string path)
        {
            this.InitializeContainer();
            var config = await this.ParseAnimation(path);

            Assert.True(config.Any());

            Assert.True(((IAnimationSection) config
                    .Cast<IAnimationSection>()
                    .FirstOrDefault())
                .Count() == 1);

            Assert.True(((IAnimationSection) config
                    .Cast<IAnimationSection>()
                    .FirstOrDefault())
                .Count() == 1);

            Assert.True(((IAnimationSectionEntry) config
                    .Cast<IAnimationSection>()
                    .FirstOrDefault(s => s.ActionNumber == 170)
                    .ElementAt(0))
                .AnimationElements
                .Count() == 9);
        }
        
        [Theory]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/common1.cns")]
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.cns")]
        public async Task Should_Read_Constants(string file)
        {
            this.InitializeContainer();
            var config = await this.ParseConstants(file);
            Assert.True(config.Any());
        }

        [Theory]
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Gogeta%20SSJ5/1.act?raw=true")]
        public async Task Should_Parse_Palette_File(string url)
        {
            this.InitializeContainer();

            var stream = await this.ReadFromUrl(url);
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();
            var palette = await paletteReader.ReadAsync(stream);
            
            Assert.True(palette.Count() == 256);
            Assert.True(!palette.Any(c => c.Red > 256 || c.Green > 256 || c.Blue > 256));
        }
    }
}