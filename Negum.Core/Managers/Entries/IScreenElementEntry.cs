namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Screen element entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IScreenElementEntry : IManagerSectionEntry<IScreenElementEntry>
{
    /// <summary>
    /// Time to show current element.
    /// </summary>
    ITimeEntry? Time { get; }

    /// <summary>
    /// Image to be displayed.
    /// </summary>
    IImageEntry? Image { get; }

    /// <summary>
    /// Sound to play.
    /// </summary>
    IVectorEntry? Sound { get; }

    /// <summary>
    /// Time to play sound.
    /// </summary>
    ITimeEntry? SoundTime { get; }

    /// <summary>
    /// Text to display.
    /// </summary>
    ITextEntry? Text { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ScreenElementEntry : ManagerSectionEntry<IScreenElementEntry>, IScreenElementEntry
{
    public ITimeEntry? Time { get; private set; }
    public IImageEntry? Image { get; private set; }
    public IVectorEntry? Sound { get; private set; }
    public ITimeEntry? SoundTime { get; private set; }
    public ITextEntry? Text { get; private set; }

    public override IScreenElementEntry Read()
    {
        Time = Section?.GetValue<ITimeEntry>(FieldKey + ".time");
        Image = Section?.GetValue<IImageEntry>(FieldKey);
        Sound = Section?.GetValue<IVectorEntry>(FieldKey + ".snd");
        SoundTime = Section?.GetValue<ITimeEntry>(FieldKey + ".sndtime");
        Text = Section?.GetValue<ITextEntry>(FieldKey);

        return this;
    }
}