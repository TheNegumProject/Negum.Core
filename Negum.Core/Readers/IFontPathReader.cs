using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Fonts;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Represents a reader used to get font information from specified file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFontPathReader : IReader<string, IFont>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontPathReader : IFontPathReader
    {
        public async Task<IFont> ReadAsync(string path) =>
            await NegumContainer.Resolve<IFontReader>().ReadAsync(path);
    }
}