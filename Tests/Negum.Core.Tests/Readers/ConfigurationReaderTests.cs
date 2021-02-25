using System.Linq;
using System.Threading.Tasks;
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
        [InlineData("https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/chars/kfm720/kfm720.air")]
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
            const string filePath = "https://raw.githubusercontent.com/TheNegumProject/UnpackedMugen/main/data/mugen1/system.def";
            this.InitializeContainer();
            var config = await this.ParseWithSubsections(filePath);
            var section = config.FirstOrDefault(s => s.Name.Equals(sectionName));
            Assert.True(section.Subsections.Count() == subsectionsCount);
        }
    }
}