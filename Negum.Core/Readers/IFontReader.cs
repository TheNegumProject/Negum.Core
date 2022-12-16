using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Fonts;
using Negum.Core.Readers.Fonts;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is designed to handle Font (.fnt) files.
/// Most fonts are build of header information and PCX files.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFontReader : IReader<string, IFont>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontReader : CommonFileReader, IFontReader
{
    public async Task<IFont> ReadAsync(string path)
    {
        if (path.EndsWith(".fnt")) // assume version 0.010
        {
            return await GetFontV0Async(path);
        }

        if (path.EndsWith(".def")) // assume version 2.000
        {
            return await GetFontV2Async(path);
        }

        throw new ArgumentException($"Unknown font file on path: {path}");
    }

    protected virtual async Task<IFont> GetFontV0Async(string path)
    {
        var fileContentStream = await NegumContainer.Resolve<IFileContentReader>().ReadAsync(path);
        var memoryStream = await NegumContainer.Resolve<IMemoryStreamReader>().ReadAsync(fileContentStream);

        var binaryReader = new BinaryReader(memoryStream);
        var (signature, version) = ReadFileHeader(binaryReader);

        return await NegumContainer.Resolve<IFontV0Reader>().ReadAsync(binaryReader, signature, version);
    }

    protected virtual async Task<IFont> GetFontV2Async(string path) =>
        await NegumContainer.Resolve<IFontV2Reader>().ReadAsync(path);
}