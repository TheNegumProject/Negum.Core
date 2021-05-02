using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png
{
    /// <summary>
    /// Reader which is used to read PNG image header.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngImageHeaderReader : IStreamReader<ISffPngImageHeader>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngImageHeaderReader : ISffPngImageHeaderReader
    {
        public async Task<ISffPngImageHeader> ReadAsync(Stream input)
        {
            var expectedHeader = new byte[] {137, 80, 78, 71, 13, 10, 26, 10};

            var headerBytes = new byte[SffPngHelper.ImageHeaderLength];

            if (input.Read(headerBytes) != SffPngHelper.ImageHeaderLength)
            {
                throw new ArgumentException($"Cannot read header bytes.");
            }

            if (!expectedHeader.SequenceEqual(headerBytes))
            {
                throw new ArgumentException($"Malformed image header.");
            }

            var pngChunkHeaderReader = NegumContainer.Resolve<ISffPngChunkHeaderReader>();
            var pngChunkHeader = await pngChunkHeaderReader.ReadAsync(input);

            if (pngChunkHeader.Length != SffPngHelper.ChunkHeaderLength)
            {
                throw new ArgumentException($"Invalid PNG image header length: {pngChunkHeader.Length}");
            }

            if (!pngChunkHeader.Name.Equals("IHDR"))
            {
                throw new ArgumentException($"Invalid PNG image header name: {pngChunkHeader.Name}");
            }

            var headerChunkBytes = new byte[SffPngHelper.ChunkHeaderLength];

            if (input.Read(headerChunkBytes) != SffPngHelper.ChunkHeaderLength)
            {
                throw new ArgumentException($"Cannot read header chunk bytes,");
            }

            var crc = new byte[SffPngHelper.CrcDataLength];

            if (input.Read(crc) != SffPngHelper.CrcDataLength)
            {
                throw new ArgumentException($"Cannot read CRC data from header chunk.");
            }

            var width = SffPngHelper.ReadBigEndian(headerChunkBytes, 0);
            var height = SffPngHelper.ReadBigEndian(headerChunkBytes, 4);

            var imageHeader = new SffPngImageHeader(headerChunkBytes)
            {
                Width = width,
                Height = height,
            };

            return imageHeader;
        }
    }
}