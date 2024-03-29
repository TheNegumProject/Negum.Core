namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents an Audio entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IAudioEntry : IManagerSectionEntry<IAudioEntry>
{
    /// <summary>
    /// Audio file.
    /// </summary>
    string? File { get; }

    /// <summary>
    /// Volume scaling factor in percent.
    /// 100 is default.
    /// </summary>
    int? Volume { get; }

    /// <summary>
    /// Set to true to allow looping.
    /// Set to false to prevent looping.
    /// </summary>
    bool? Loop { get; }

    int? LoopStart { get; }

    int? LoopEnd { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class AudioEntry : ManagerSectionEntry<IAudioEntry>, IAudioEntry
{
    public string? File { get; private set; }
    public int? Volume { get; private set; }
    public bool? Loop { get; private set; }
    public int? LoopStart { get; private set; }
    public int? LoopEnd { get; private set; }

    public override IAudioEntry Read()
    {
        File = Section?.GetValue<string>(FieldKey);
        Volume = Section?.GetValue<int>(FieldKey + ".volume");
        Loop = Section?.GetValue<bool>(FieldKey + ".loop");
        LoopStart = Section?.GetValue<int>(FieldKey + ".loopstart");
        LoopEnd = Section?.GetValue<int>(FieldKey + ".loopend");

        return this;
    }
}