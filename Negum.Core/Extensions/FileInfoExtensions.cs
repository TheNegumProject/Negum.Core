using System.IO;
using Negum.Core.Exceptions;

namespace Negum.Core.Extensions;

public static class FileInfoExtensions
{
    public static string GetDirectoryNameOrThrow(this FileInfo fi) => 
        fi.DirectoryName ?? throw new NegumException($"Cannot find directory name for file: {fi.FullName}");

    public static DirectoryInfo GetDirectoryOrThrow(this FileInfo fi) => 
        fi.Directory ?? throw new NegumException($"Cannot find directory of file: {fi.FullName}");
}