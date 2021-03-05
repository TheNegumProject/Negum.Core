using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class ImageReadersTests : TestBase
    {
        [Theory]
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Gogeta%20SSJ5/1.act?raw=true")]
        public async Task Should_Parse_Palette_File(string url)
        {
            this.InitializeContainer();

            var stream = await this.ReadFromUrl(url);
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();
            var palette = await paletteReader.ReadAsync(stream);
            
            Assert.True(palette.Count() == 256);
        }

        [Theory]
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Gogeta%20SSJ5/gogetassj4.sff?raw=true")]
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Goku%20SSJ2/kakaroto.sff?raw=true")]
        public async Task Should_Parse_Sprite_File(string url)
        {
            this.InitializeContainer();

            var stream = await this.ReadFromUrl(url);
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            
            var spriteReader = NegumContainer.Resolve<ISpriteReader>();
            var sprite = await spriteReader.ReadAsync(stream);
            
            Assert.True(sprite.SpriteSubFiles.Any());
        }
    }
}