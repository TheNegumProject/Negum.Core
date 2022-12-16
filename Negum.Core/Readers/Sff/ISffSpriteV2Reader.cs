using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Palettes;
using Negum.Core.Models.Sprites;
using Negum.Core.Models.Sprites.Png;
using Negum.Core.Readers.Sff.V2;

namespace Negum.Core.Readers.Sff;

/// <summary>
/// Represents a reader for SFF v2.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffSpriteV2Reader : ISffSpriteReader
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffSpriteV2Reader : SffSpriteReader, ISffSpriteV2Reader
{
    public override async Task<ISprite> ReadAsync(BinaryReader binaryReader, string signature, string version)
    {
        var sprite = new SffSpriteV2
        {
            Signature = signature, // 12 bytes
            Version = version, // 4 bytes
            Unknown1 = binaryReader.ReadBytes(10), // TODO: ???
            PaletteMapOffset = binaryReader.ReadUInt32(),
            Unknown2 = binaryReader.ReadBytes(6), // TODO: ???
            SpriteOffset = binaryReader.ReadUInt32(), // First sprite offset
            SpriteCount = binaryReader.ReadUInt32(), // Number of sprites
            PaletteOffset = binaryReader.ReadUInt32(), // First palette offset
            PaletteCount = binaryReader.ReadUInt32(), // Number of palettes
            LDataOffset = binaryReader.ReadUInt32(), // Literal Block Data Information
            LDataLength = binaryReader.ReadUInt32(), // Palettes + SpritesData(OnDemand)
            TDataOffset = binaryReader.ReadUInt32(), // Translated Data Block Information
            TDataLength = binaryReader.ReadUInt32(), // SpritesData(OnLoad)
            Comment = binaryReader.ReadBytes(444) // Space for comment
        };

        ReadSubFiles(binaryReader, sprite);

        ReadPalettesInfo(binaryReader, sprite);

        ReadPalettesColors(binaryReader, sprite);

        await ReadSubFilesDataAsync(binaryReader, sprite);

        return sprite;
    }

    protected virtual void ReadSubFiles(BinaryReader binaryReader, SffSpriteV2 sprite)
    {
        // Go to first sub file
        binaryReader.BaseStream.Seek(sprite.SpriteOffset, SeekOrigin.Begin);

        // Read all sprites
        for (var i = 0; i < sprite.SpriteCount; ++i)
        {
            var subFile = new SpriteSubFileSffV2
            {
                SpriteGroup = binaryReader.ReadUInt16(),
                SpriteNumber = binaryReader.ReadUInt16(),
                SpriteImageWidth = binaryReader.ReadUInt16(),
                SpriteImageHeight = binaryReader.ReadUInt16(),
                SpriteImageXAxis = binaryReader.ReadUInt16(),
                SpriteImageYAxis = binaryReader.ReadUInt16(),
                SpriteLinkedIndex = binaryReader.ReadUInt16(),
                CompressionMethod = binaryReader.ReadByte(),
                ColorDepth = binaryReader.ReadByte(),
                DataOffset = binaryReader.ReadUInt32(), // Offset to data
                DataLength = binaryReader.ReadUInt32(),
                PaletteIndex = binaryReader.ReadUInt16(),
                LoadMode = binaryReader.ReadUInt16()
            };

            sprite.AddSubFile(subFile);
        }
    }

    protected virtual void ReadPalettesInfo(BinaryReader binaryReader, SffSpriteV2 sprite)
    {
        // Go to first palette
        binaryReader.BaseStream.Seek(sprite.PaletteOffset, SeekOrigin.Begin);

        // Read all palettes
        for (var i = 0; i < sprite.PaletteCount; ++i)
        {
            var palette = new Palette
            {
                GroupNumber = binaryReader.ReadUInt16(),
                ItemNumber = binaryReader.ReadUInt16(),
                ColorNumber = binaryReader.ReadUInt16(),
                LinkedIndex = binaryReader.ReadUInt16(),
                LDataOffset = binaryReader.ReadUInt32(),
                LDataLength = binaryReader.ReadUInt32()
            };

            sprite.AddPalette(palette);
        }
    }

    protected virtual void ReadPalettesColors(BinaryReader binaryReader, SffSpriteV2 sprite)
    {
        var paletteReader = NegumContainer.Resolve<IPaletteReader>();

        foreach (var palette in sprite.Palettes)
        {
            // Go to palette data
            binaryReader.BaseStream.Seek(sprite.LDataOffset + palette.LDataOffset, SeekOrigin.Begin);

            var paletteData = binaryReader.ReadBytes((int) palette.LDataLength);

            if (paletteData.Length == 0)
            {
                continue;
            }

            // Read colors of palette - create temporary palette
            var paletteWithColors = paletteReader.ReadExact(paletteData, palette.ColorNumber, true);

            // Copy colors to destination palette
            paletteWithColors.CopyTo(palette);
        }
    }

    protected virtual async Task ReadSubFilesDataAsync(BinaryReader binaryReader, SffSpriteV2 sprite)
    {
        var sffRle8Reader = NegumContainer.Resolve<ISffRle8Reader>();
        var sffRle5Reader = NegumContainer.Resolve<ISffRle5Reader>();
        var sffLz5Reader = NegumContainer.Resolve<ISffLz5Reader>();
        var sffPngReader = NegumContainer.Resolve<ISffPngReader>();

        // Read all sprites pixels
        foreach (var subFileSffV2 in sprite.SpriteSubFiles)
        {
            var subFile = (SpriteSubFileSffV2)subFileSffV2;

            binaryReader.BaseStream.Seek(
                (subFile.LoadMode == 1 ? sprite.TDataOffset : sprite.LDataOffset) + subFile.DataOffset,
                SeekOrigin.Begin);

            if (subFile.CompressionMethod == 0) // No conversion
            {
                subFile.ImageSize = 0; // Indicate that there was no compression
                subFile.RawImage = binaryReader.ReadBytes((int) subFile.DataLength);
            }
            else
            {
                const byte totalBytesPerImageSize = 4;

                subFile.ImageSize = binaryReader.ReadUInt32();

                if (subFile.DataLength >= totalBytesPerImageSize)
                {
                    subFile.RawImage = binaryReader.ReadBytes((int) (subFile.DataLength - totalBytesPerImageSize));
                }
                else
                {
                    continue;
                }
            }

            if (subFile.DataLength == 0)
            {
                // TODO: Process sprite from linked index -> subFile.SpriteLinkedIndex
                continue;
            }

            switch (subFile.CompressionMethod)
            {
                case 0: // Raw Data
                    subFile.Image = subFile.RawImage;
                    break;

                case 1: // Invalid
                    break;

                case 2: // RLE8 (Run-Length Encoding at 8 bits-per-pixel pixmap)
                    subFile.Image = await sffRle8Reader.ReadAsync(subFile.RawImage);
                    break;

                case 3: // RLE5 (Run-Length Encoding at 5 bits-per-pixel pixmap)
                    subFile.Image = await sffRle5Reader.ReadAsync(subFile.RawImage);
                    break;

                case 4: // LZ5
                    subFile.Image = await sffLz5Reader.ReadAsync(subFile.RawImage);
                    break;

                case 10: // PNG8
                    subFile.Image = await ParsePngAsync(sffPngReader, sprite, subFile, 8);
                    break;

                case 11: // PNG24
                    subFile.Image = await ParsePngAsync(sffPngReader, sprite, subFile, 24);
                    break;

                case 12: // PNG32
                    subFile.Image = await ParsePngAsync(sffPngReader, sprite, subFile, 32);
                    break;
            }
        }
    }

    protected virtual async Task<IEnumerable<byte>> ParsePngAsync(ISffPngReader sffPngReader, SffSpriteV2 sprite,
        ISpriteSubFileSffV2 subFile,
        int pngFormat)
    {
        var ctx = new SffPngReaderContext
        {
            PngFormat = pngFormat,
            RawImage = subFile.RawImage
        };

        if (sprite.Palettes.Count() > subFile.PaletteIndex)
        {
            ctx.Palette = sprite.Palettes.ElementAt(subFile.PaletteIndex);
        }

        var image = await sffPngReader.ReadAsync(ctx);

        return image;
    }
}