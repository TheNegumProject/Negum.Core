using System.IO;
using Negum.Core.Exceptions;

namespace Negum.Core.Extensions;

public static class DirectoryInfoExtensions
{
    public static DirectoryInfo GetParentOrThrow(this DirectoryInfo di) => 
        di.Parent ?? throw new NegumException($"Cannot get parent for directory: {di.FullName}");
}