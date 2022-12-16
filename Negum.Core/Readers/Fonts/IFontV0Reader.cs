using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Extensions;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Fonts;
using Negum.Core.Models.Pcx;

namespace Negum.Core.Readers.Fonts;

/// <summary>
/// Represents a reader for Font v0.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFontV0Reader
{
    /// <summary>
    /// Reads Font from specified BinaryReader.
    /// </summary>
    /// <param name="binaryReader">BinaryReader from which the font data should be read.</param>
    /// <param name="signature">File signature.</param>
    /// <param name="version">File version.</param>
    /// <returns>Read Font.</returns>
    Task<IFont> ReadAsync(BinaryReader binaryReader, string signature, string version);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontV0Reader : CommonFontReader, IFontV0Reader
{
    public async Task<IFont> ReadAsync(BinaryReader binaryReader, string signature, string version)
    {
        var font = new FontV0
        {
            Signature = signature,
            Version = version,
            SpriteDataOffset = binaryReader.ReadUInt32(),
            SpriteDataLength = binaryReader.ReadInt32(),
            TextDataOffset = binaryReader.ReadUInt32(),
            TextDataLength = binaryReader.ReadInt32(),
            Comment = binaryReader.ReadBytes(40).ToUtf8String()
        };

        if (font.SpriteDataLength > 0)
        {
            binaryReader.BaseStream.Seek(font.SpriteDataOffset, SeekOrigin.Begin);

            var imageData = binaryReader.ReadBytes(font.SpriteDataLength);
            var imageStream = new MemoryStream(imageData);

            var ctx = new PcxDetails
            {
                Stream = imageStream
            };

            font.Image = await NegumContainer.Resolve<IPcxReader>().ReadAsync(ctx);
        }

        if (font.TextDataLength > 0)
        {
            binaryReader.BaseStream.Seek(font.TextDataOffset, SeekOrigin.Begin);

            var configurationDefinitionBytes = binaryReader.ReadBytes(font.TextDataLength);
            var configurationText = configurationDefinitionBytes.ToUtf8String();

            var stream = new MemoryStream(configurationText.ToByteArray());
            var config = NegumContainer.Resolve<IConfigurationReader>().ReadAsync(stream).Result;
            var manager = (IFontManager) NegumContainer.Resolve<IFontManager>().UseConfiguration(config);

            ProcessConfiguration(font, manager);
        }

        return font;
    }
}