namespace Negum.Core.Models.Sounds;

/// <summary>
/// Represents a single sound read from appropriate directory.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISound : IFileReadable
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class Sound : FileReadable, ISound
{
}