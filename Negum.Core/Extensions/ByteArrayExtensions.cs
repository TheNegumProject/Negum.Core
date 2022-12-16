using System.Text;

namespace Negum.Core.Extensions;

/// <summary>
/// Contains extension methods for byte arrays.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public static class ByteArrayExtensions
{
    public static string ToUtf8String(this byte[] bytes) =>
        Encoding.UTF8.GetString(bytes);
}