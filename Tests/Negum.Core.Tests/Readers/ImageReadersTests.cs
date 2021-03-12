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
        [InlineData("https://github.com/TheNegumProject/DragonBallMugenEdition2005/blob/main/chars/Goku%20San/Sprite.sff?raw=true")] // 1.010
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Gogeta%20SSJ5/gogetassj4.sff?raw=true")] // 1.010
        [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Goku%20SSJ2/kakaroto.sff?raw=true")] // 1.010
        [InlineData("https://github.com/TheNegumProject/DragonBallMugenEdition2007/blob/main/stages/Future.sff?raw=true")] // 1.010
        [InlineData("/Users/kdobrzynski/Downloads/Sprite.sff")] // 1.010
        [InlineData("/Users/kdobrzynski/Downloads/gogetassj4.sff")] // 1.010
        [InlineData("/Users/kdobrzynski/Downloads/kakaroto.sff")] // 1.010
        [InlineData("/Users/kdobrzynski/Downloads/Future.sff")] // 1.010
        public async Task Should_Parse_Sprite_File_And_Images_SFFv1(string url)
        {
            this.InitializeContainer();

            var spritePathReader = NegumContainer.Resolve<ISpritePathReader>();
            var sprite = await spritePathReader.ReadAsync(url);
            
            Assert.True(sprite != null);
            Assert.True(sprite is ISffSpriteV1);

            var sffSprite = (ISffSpriteV1) sprite;

            Assert.True(sffSprite.SpriteSubFiles.Any());
            Assert.True(sffSprite.SpriteSubFiles.Count() == sffSprite.Images);
            
            var image = sffSprite.SpriteSubFiles.ElementAt(0).Image;
            
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
            
            var spritePathReader = NegumContainer.Resolve<ISpritePathReader>();
            var sprite = await spritePathReader.ReadAsync(url);

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