namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents an Image entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IImageEntry : IManagerSectionEntry<IImageEntry>
{
    /// <summary>
    /// Image to be displayed.
    /// </summary>
    IVectorEntry? Sprite { get; }

    /// <summary>
    /// Offset by which current image should be moved.
    /// Position offset.
    /// </summary>
    IVectorEntry? Offset { get; }

    /// <summary>
    /// Scales the image.
    /// </summary>
    IVectorEntry? Scale { get; }

    /// <summary>
    /// Direction of image facing.
    /// </summary>
    int? Facing { get; }

    IVectorEntry? Window { get; }

    /// <summary>
    /// Animation action number.
    /// </summary>
    int? Animation { get; }

    /// <summary>
    /// Describes how long to display current image.
    /// </summary>
    ITimeEntry? Time { get; }

    /// <summary>
    /// Time to start display.
    /// </summary>
    ITimeEntry? StartTime { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ImageEntry : ManagerSectionEntry<IImageEntry>, IImageEntry
{
    public IVectorEntry? Sprite { get; private set; }
    public IVectorEntry? Offset { get; private set; }
    public IVectorEntry? Scale { get; private set; }
    public int? Facing { get; private set; }
    public IVectorEntry? Window { get; private set; }
    public int? Animation { get; private set; }
    public ITimeEntry? Time { get; private set; }
    public ITimeEntry? StartTime { get; private set; }

    public override IImageEntry Read()
    {
        Sprite = Section?.GetValue<IVectorEntry>(FieldKey + ".spr");
        Offset = Section?.GetValue<IVectorEntry>(FieldKey + ".offset");
        Scale = Section?.GetValue<IVectorEntry>(FieldKey + ".scale");
        Facing = Section?.GetValue<int>(FieldKey + ".facing");
        Window = Section?.GetValue<IVectorEntry>(FieldKey + ".window");
        Animation = Section?.GetValue<int>(FieldKey + ".anim");
        Time = Section?.GetValue<ITimeEntry>(FieldKey + ".time");
        StartTime = Section?.GetValue<ITimeEntry>(FieldKey + ".starttime");

        return this;
    }
}