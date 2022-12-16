using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models.Sounds;

namespace Negum.Core.Readers;

/// <summary>
/// Represents a reader used to get sound information from specified file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISoundPathReader : IReader<string, ISound>
{
}
    
/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SoundPathReader : ISoundPathReader
{
    public async Task<ISound> ReadAsync(string file)
    {
        var sound = new Sound
        {
            File = new FileInfo(file)
        };
            
        return await Task.FromResult(sound);
    }
}