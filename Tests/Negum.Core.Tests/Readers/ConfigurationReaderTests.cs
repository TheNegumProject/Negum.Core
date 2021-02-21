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
        [Fact]
        public async Task Should_Read_Configuration()
        {
            const string filePath = "/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg";
            this.InitializeContainer();
            var config = await this.Parse(filePath);
            Assert.True(config.Any());
        }
        
        [Theory]
        [InlineData("TitleBGdef", 6)]
        [InlineData("SelectBGdef", 4)]
        [InlineData("VersusBGdef", 13)]
        [InlineData("VictoryBGdef", 3)]
        [InlineData("OptionsBGdef", 1)]
        public async Task Should_Read_Motif_With_Subsections(string sectionName, int subsectionsCount)
        {
            const string filePath = "/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen1/system.def";
            this.InitializeContainer();
            var config = await this.ParseWithSubsections(filePath);
            var section = config.FirstOrDefault(s => s.Name.Equals(sectionName));
            Assert.True(section.Subsections.Count() == subsectionsCount);
        }
    }
}