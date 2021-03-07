using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites;
using Negum.Core.Readers.Sff.V2;

namespace Negum.Core.Readers.Sff
{
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
                Signature = signature,
                Version = version,
                Header = binaryReader.ReadBytes(20), // TODO: Unknown 20 bytes
                SpriteOffset = binaryReader.ReadUInt32(),
                SpriteNumber = binaryReader.ReadUInt32(),
                PaletteOffset = binaryReader.ReadUInt32(),
                PaletteNumber = binaryReader.ReadUInt32(),
                LDataOffset = binaryReader.ReadUInt32(),
                LDataLength = binaryReader.ReadUInt32(),
                TDataOffset = binaryReader.ReadUInt32(),
                TDataLength = binaryReader.ReadUInt32()
            };

            for (var i = 0; i < sprite.SpriteNumber; ++i)
            {
                var subFile = await this.ReadSubFileAsync(binaryReader, sprite, i);
                sprite.AddSubFile(subFile);
            }

            return sprite;
        }

        protected virtual async Task<ISpriteSubFileSffV2> ReadSubFileAsync(BinaryReader binaryReader,
            ISffSpriteV2 sprite, int index)
        {
            // Where 28 is the number of bytes read next for sub-file properties.
            binaryReader.BaseStream.Seek(sprite.SpriteOffset + 28 * index, SeekOrigin.Begin);

            var subFile = new SpriteSubFileSffV2
            {
                Group = binaryReader.ReadUInt16(),
                Index = binaryReader.ReadUInt16(),
                Width = binaryReader.ReadUInt16(),
                Height = binaryReader.ReadUInt16(),
                X = binaryReader.ReadUInt16(),
                Y = binaryReader.ReadUInt16(),
                LinkIndex = binaryReader.ReadUInt16(),
                Format = binaryReader.ReadByte(),
                Depth = binaryReader.ReadByte(),
                DataOffset = binaryReader.ReadUInt32(),
                DataLength = binaryReader.ReadUInt32(),
                PaletteIndex = binaryReader.ReadUInt16(),
                Flags = binaryReader.ReadUInt16()
            };

            if (subFile.DataLength == 0)
            {
                return await this.ReadSubFileAsync(binaryReader, sprite, subFile.LinkIndex);
            }

            binaryReader.BaseStream.Seek((subFile.Flags == 1 ? sprite.TDataOffset : sprite.LDataOffset) +
                                         subFile.DataOffset, SeekOrigin.Begin);

            if (subFile.Format == 0) // No conversion
            {
                subFile.Image = binaryReader.ReadBytes((int) subFile.DataLength);
            }
            else
            {
                var imageSize = binaryReader.ReadUInt32();
                subFile.Image = binaryReader.ReadBytes((int) (subFile.DataLength - 4));
            }

            switch (subFile.Format)
            {
                case 0:
                    subFile.Palette = this.GetPaletteData(binaryReader, subFile.PaletteIndex, sprite);
                    break;

                case 2:
                    var sffRle8Reader = NegumContainer.Resolve<ISffRle8Reader>();
                    subFile.Palette = this.GetPaletteData(binaryReader, subFile.PaletteIndex, sprite);
                    subFile.Image = await sffRle8Reader.ReadAsync(subFile.Image);
                    break;

                case 4:
                    var sffLz5Reader = NegumContainer.Resolve<ISffLz5Reader>();
                    subFile.Palette = this.GetPaletteData(binaryReader, subFile.PaletteIndex, sprite);
                    subFile.Image = await sffLz5Reader.ReadAsync(subFile.Image);
                    break;

                case 10:
                    return await this.ReadPngAsync(binaryReader, sprite, subFile, 8);

                case 11:
                    return await this.ReadPngAsync(binaryReader, sprite, subFile, 24);

                case 12:
                    return await this.ReadPngAsync(binaryReader, sprite, subFile, 32);
            }

            return subFile;
        }

        protected virtual async Task<ISpriteSubFileSffV2> ReadPngAsync(BinaryReader binaryReader, ISffSpriteV2 sprite,
            SpriteSubFileSffV2 subFile, byte pngFormat)
        {
            subFile.PngFormat = pngFormat;
            subFile.Palette = this.GetPaletteData(binaryReader, subFile.PaletteIndex, sprite);

            var sffPngReader = NegumContainer.Resolve<ISffPngReader>();
            subFile.Image = await sffPngReader.ReadAsync(subFile);

            return subFile;
        }

        protected virtual byte[] GetPaletteData(BinaryReader binaryReader, ushort paletteIndex, ISffSpriteV2 sprite)
        {
            binaryReader.BaseStream.Seek(sprite.PaletteOffset + paletteIndex * 16, SeekOrigin.Begin);

            var paletteGroup = binaryReader.ReadUInt16();
            var index = binaryReader.ReadUInt16(); // TODO: PaletteIndex ???
            var paletteColorNumber = binaryReader.ReadUInt16();
            var paletteLinkIndex = binaryReader.ReadUInt16();
            var paletteLDataOffset = binaryReader.ReadUInt32();
            var paletteLDataLength = binaryReader.ReadUInt32();

            binaryReader.BaseStream.Seek(sprite.LDataLength + paletteLDataOffset, SeekOrigin.Begin);

            return binaryReader.ReadBytes((int) paletteLDataLength);
        }
    }
}