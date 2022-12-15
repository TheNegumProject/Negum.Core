using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Extensions;
using Negum.Core.Models.Sounds;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is used to find files.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFilePathReader
{
    /// <summary>
    /// Reads sound in specified directory and in parent directories.
    /// </summary>
    /// <param name="dirName"></param>
    /// <param name="soundPath"></param>
    /// <returns>Found sound.</returns>
    Task<ISound?> GetSoundAsync(string dirName, string? soundPath);

    /// <summary>
    /// Reads sprite in specified directory and in parent directories.
    /// </summary>
    /// <param name="dirName"></param>
    /// <param name="spritePath"></param>
    /// <returns>Found sprite.</returns>
    Task<ISprite?> GetSpriteAsync(string dirName, string? spritePath);

    /// <summary>
    /// Searches for specified file in given directory and in parent directories.
    /// </summary>
    /// <param name="dirName"></param>
    /// <param name="fileName"></param>
    /// <returns>Found file.</returns>
    FileInfo? FindFile(string dirName, string fileName);
}

public class FilePathReader : IFilePathReader
{
    public virtual async Task<ISound?> GetSoundAsync(string dirName, string? soundPath)
    {
        if (soundPath is null)
        {
            return null;
        }
        
        var file = FindFile(dirName, soundPath);

        if (file is null)
        {
            return null;
        }
            
        return await NegumContainer.Resolve<ISoundPathReader>().ReadAsync(file.FullName);
    }

    public virtual async Task<ISprite?> GetSpriteAsync(string dirName, string? spritePath)
    {
        if (spritePath is null)
        {
            return null;
        }
        
        var file = FindFile(dirName, spritePath);
            
        if (file is null)
        {
            return null;
        }
            
        return await NegumContainer.Resolve<ISpritePathReader>().ReadAsync(file.FullName);
    }

    public virtual FileInfo? FindFile(string dirName, string fileName)
    {
        var path = Path.Combine(dirName, fileName);
        var file = new FileInfo(path);

        while (!file.Exists)
        {
            if (file.GetDirectoryOrThrow().Parent == null)
            {
                return null;
            }

            path = Path.Combine(file.GetDirectoryOrThrow().GetParentOrThrow().FullName, file.Name);
            file = new FileInfo(path);
        }

        return file;
    }
}