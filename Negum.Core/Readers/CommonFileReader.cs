using System.IO;
using Negum.Core.Extensions;

namespace Negum.Core.Readers;

/// <summary>
/// Reader class which contains common code for all file-related readers.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class CommonFileReader
{
    protected virtual (string signature, string version) ReadFileHeader(BinaryReader binaryReader)
    {
        var signature = binaryReader.ReadBytes(12).ToUtf8String();
        var version = GetVersion(binaryReader);

        return (signature, version);
    }

    protected virtual string GetVersion(BinaryReader binaryReader)
    {
        var versionBytes = binaryReader.ReadBytes(4);
        var versionString = $"{versionBytes[3]}.{versionBytes[2]}{versionBytes[1]}{versionBytes[0]}";
        return versionString;
    }
}