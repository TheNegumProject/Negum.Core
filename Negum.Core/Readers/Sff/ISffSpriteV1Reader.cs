using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Extensions;
using Negum.Core.Models.Pcx;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers.Sff;

/// <summary>
/// Represents a reader for SFF v1.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffSpriteV1Reader : ISffSpriteReader
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffSpriteV1Reader : SffSpriteReader, ISffSpriteV1Reader
{
    public override async Task<ISprite> ReadAsync(BinaryReader binaryReader, string signature, string version)
    {
        var paletteReader = NegumContainer.Resolve<IPaletteReader>();
        var pcxReader = NegumContainer.Resolve<IPcxReader>();

        var sprite = new SffSpriteV1
        {
            Signature = signature,
            Version = version,
            GroupCount = binaryReader.ReadUInt32(),
            ImageCount = binaryReader.ReadUInt32(),
            PosFirstSubFileOffset = binaryReader.ReadUInt32(), // Next Sub File Offset
            Length = binaryReader.ReadUInt32(), // Sub-Header Size
            PaletteType = binaryReader.ReadByte(), // Shared Palette Byte; 0 - individual, 1 - shared
            Blank = binaryReader.ReadBytes(3).ToUtf8String(),
            Comments = binaryReader.ReadBytes(476).ToUtf8String()
        };

        for (var i = 0; i < sprite.ImageCount; ++i)
        {
            var subFile = await ReadSubFileAsync(pcxReader, binaryReader, i, paletteReader, sprite);
            sprite.AddSubFile(subFile);
        }

        return sprite;
    }

    protected virtual async Task<ISpriteSubFile> ReadSubFileAsync(IPcxReader pcxReader, BinaryReader binaryReader,
        int index, IPaletteReader paletteReader, SffSpriteV1 sprite)
    {
        var subFile = new SpriteSubFileSffV1
        {
            DataOffset = binaryReader.ReadUInt32(),
            DataLength = binaryReader.ReadUInt32(),
            SpriteImageXAxis = binaryReader.ReadUInt16(),
            SpriteImageYAxis = binaryReader.ReadUInt16(),
            SpriteGroup = binaryReader.ReadUInt16(),
            SpriteNumber = binaryReader.ReadUInt16(),
            SpriteLinkedIndex = binaryReader.ReadUInt16(),
            SamePalette = binaryReader.ReadByte(), // 1 - if the palette is the same as in previous sprite, 0 - new
            Comment = binaryReader.ReadBytes(14).ToUtf8String()
        };

        if (subFile.SpriteLinkedIndex == 0)
        {
            binaryReader.BaseStream.Position -= 1;
            var count = (int) (subFile.DataOffset - binaryReader.BaseStream.Position);
            subFile.RawImage = binaryReader.ReadBytes(count);
        }

        if (index == 0) // TODO: Load only if palette available
        {
            var paletteData = binaryReader.ReadBytes(768);
            var palette = await paletteReader.ReadAsync(paletteData);
            sprite.Palette = palette.Reverse();
        }

        if (subFile.RawImage.Length > 0)
        {
            var palette = subFile.SamePalette == 1
                ? sprite.SpriteSubFiles.ElementAt(0).Palette
                : null;
                
            var pcxDetails = new PcxDetails
            {
                Stream = new MemoryStream(subFile.RawImage),
                Palette = palette
            };

            subFile.PcxImage = await pcxReader.ReadAsync(pcxDetails);
        }

        binaryReader.BaseStream.Position = subFile.DataOffset;

        return subFile;
    }
}