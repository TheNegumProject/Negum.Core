using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites;
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
        [InlineData("https://github.com/TheNegumProject/DragonBallMugenEdition2005/blob/main/chars/Goku%20San/Sprite.sff?raw=true")]
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Gogeta%20SSJ5/gogetassj4.sff?raw=true")]
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Goku%20SSJ2/kakaroto.sff?raw=true")]
        public async Task Should_Parse_Sprite_File_And_Images_SFFv1(string url)
        {
            this.InitializeContainer();

            var stream = await this.ReadFromUrl(url);
            
            var memoryStreamReader = NegumContainer.Resolve<IMemoryStreamReader>();
            var sffStream = await memoryStreamReader.ReadAsync(stream);
            
            var spriteReader = NegumContainer.Resolve<ISpriteReader>();
            var sprite = (ISffSpriteV1) await spriteReader.ReadAsync(sffStream);

            Assert.True(sprite.SpriteSubFiles.Any());
            Assert.True(sprite.SpriteSubFiles.Count() == sprite.Images);
            
            var image = sprite.SpriteSubFiles.ElementAt(0).Image;
            
            Assert.True(image != null);
            
            var pcxStream = new MemoryStream(image.ToArray());
            
            var pcxReader = NegumContainer.Resolve<IPcxReader>();
            var pcxImage = await pcxReader.ReadAsync(pcxStream);
            
            Assert.True(pcxImage.Pixels.Any());
        }
        
        [Theory]
        [InlineData("https://github.com/TheNegumProject/UnpackedMugen/blob/main/stages/kfm.sff?raw=true")]
        [InlineData("https://github.com/TheNegumProject/UnpackedMugen/blob/main/stages/stage0-720.sff?raw=true")]
        [InlineData("https://github.com/TheNegumProject/UnpackedMugen/blob/main/stages/stage0.sff?raw=true")]
        public async Task Should_Parse_Sprite_File_And_Images_SFFv2(string url)
        {
            this.InitializeContainer();

            var stream = await this.ReadFromUrl(url);

            var memoryStreamReader = NegumContainer.Resolve<IMemoryStreamReader>();
            var memoryStream = await memoryStreamReader.ReadAsync(stream);
            
            Assert.True(memoryStream.Length > 0);
            Assert.True(memoryStream.Position == 0);

            var spriteReader = NegumContainer.Resolve<ISpriteReader>();
            var sprite = await spriteReader.ReadAsync(memoryStream);
            
            Assert.True(sprite != null);
            Assert.True(sprite is ISffSpriteV2);

            var sffSprite = (ISffSpriteV2) sprite;
            
            Assert.True(sffSprite.SpriteSubFiles.Any());

            var firstImage = sffSprite.SpriteSubFiles.FirstOrDefault();
            
            Assert.True(firstImage != null);
            Assert.True(firstImage.Image.Any());
        }
    }
}