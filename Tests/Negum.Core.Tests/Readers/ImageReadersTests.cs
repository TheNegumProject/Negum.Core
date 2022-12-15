using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites;
using Negum.Core.Readers;
using Xunit;

namespace Negum.Core.Tests.Readers;

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
        var stream = await ReadFromUrl(url);
        var paletteReader = NegumContainer.Resolve<IPaletteReader>();
        var palette = await paletteReader.ReadAsync(stream);
            
        Assert.True(palette.Count() == 256);
    }

    [Theory]
    [InlineData("https://github.com/TheNegumProject/DragonBallMugenEdition2005/blob/main/chars/Goku%20San/Sprite.sff?raw=true")] // 1.010
    [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Gogeta%20SSJ5/gogetassj4.sff?raw=true")] // 1.010
    [InlineData("https://github.com/TheNegumProject/DragonBallVsSaintSeiyaMugen/blob/main/chars/Goku%20SSJ2/kakaroto.sff?raw=true")] // 1.010
    [InlineData("https://github.com/TheNegumProject/DragonBallMugenEdition2007/blob/main/stages/Future.sff?raw=true")] // 1.010
    public async Task Should_Parse_Sprite_File_And_Images_SFFv1(string url)
    {
        var spritePathReader = NegumContainer.Resolve<ISpritePathReader>();
        var sprite = await spritePathReader.ReadAsync(url);
            
        Assert.True(sprite != null);
        Assert.True(sprite is ISffSpriteV1);

        var sffSprite = (ISffSpriteV1) sprite;

        Assert.True(sffSprite.SpriteSubFiles.Any());
        Assert.True(sffSprite.SpriteSubFiles.Count() == sffSprite.ImageCount);
    }
        
    [Theory]
    [InlineData("https://github.com/TheNegumProject/UnpackedMugen/blob/main/chars/kfm720/kfm720.sff?raw=true")] // 2.000
    [InlineData("https://github.com/TheNegumProject/JumpUltimateStarsMugen/blob/main/chars/Seiya/Seiya.sff?raw=true")] // 2.000
    [InlineData("https://github.com/TheNegumProject/UnpackedMugen/blob/main/stages/stage0-720.sff?raw=true")] // 2.000
    [InlineData("https://github.com/TheNegumProject/UnpackedMugen/blob/main/stages/stage0.sff?raw=true")] // 2.000
    // [InlineData("/Users/kdobrzynski/Downloads/kfm720.sff")] // 2.000
    // [InlineData("/Users/kdobrzynski/Downloads/Seiya.sff")] // 2.000
    // [InlineData("/Users/kdobrzynski/Downloads/stage0-720.sff")] // 2.000
    // [InlineData("/Users/kdobrzynski/Downloads/stage0.sff")] // 2.000
    [InlineData("https://github.com/TheNegumProject/DragonBallMugenEditionJusUltimate/blob/main/chars/Goku_JUS/Goku_JUS.sff?raw=true")] // 2.010
    [InlineData("https://github.com/TheNegumProject/DragonBallMugenEditionJusUltimate/blob/main/chars/Vegeta_JUS/Vegeta_JUS.sff?raw=true")] // 2.010
    [InlineData("https://github.com/TheNegumProject/DragonBallMugenEditionJusUltimate/blob/main/stages/Super_Chikara_End.sff?raw=true")] // 2.010
    [InlineData("https://github.com/TheNegumProject/DragonBallMugenEditionJusUltimate/blob/main/stages/TimeChamber.sff?raw=true")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/Goku_JUS.sff")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/Vegeta_JUS.sff")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/Super_Chikara_End.sff")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/TimeChamber.sff")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/chars/kfm/kfm.sff")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/chars/kfm720/kfm720.sff")] // 2.010
    // [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/stages/stage0-720.sff")] // 2.010
    public async Task Should_Parse_Sprite_File_And_Images_SFFv2(string url)
    {
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