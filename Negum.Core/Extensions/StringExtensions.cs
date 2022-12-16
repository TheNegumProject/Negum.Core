using System.Text;

namespace Negum.Core.Extensions;

/// <summary>
/// Contains extension methods for strings.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public static class StringExtensions
{
    public static byte[] ToByteArray(this string text) =>
        Encoding.UTF8.GetBytes(text);
}