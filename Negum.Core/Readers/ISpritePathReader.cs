using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to read Sprite from specified path.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpritePathReader : IReader<string, ISprite>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpritePathReader : ISpritePathReader
    {
        public async Task<ISprite> ReadAsync(string path)
        {
            var fileContentStream = await NegumContainer.Resolve<IFileContentReader>().ReadAsync(path);
            var memoryStream = await NegumContainer.Resolve<IMemoryStreamReader>().ReadAsync(fileContentStream);
            var sprite = await NegumContainer.Resolve<ISpriteReader>().ReadAsync(memoryStream);

            return sprite;
        }
    }
}