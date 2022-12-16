namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Text entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ITextEntry : IManagerSectionEntry<ITextEntry>
{
    /// <summary>
    /// Position of the text.
    /// </summary>
    IVectorEntry? Offset { get; }

    /// <summary>
    /// Font the text.
    /// Set for -1 for none / no display.
    /// </summary>
    IVectorEntry? Font { get; }

    IVectorEntry? Spacing { get; }
    string? Text { get; }
    IVectorEntry? Window { get; }
    string? TextWrap { get; }
    ITimeEntry? DisplayTime { get; }
    int? Layer { get; }
    IVectorEntry? Scale { get; }

    /// <summary>
    /// Set to true to shake the text.
    /// </summary>
    bool? Shake { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class TextEntry : ManagerSectionEntry<ITextEntry>, ITextEntry
{
    public IVectorEntry? Offset { get; private set; }
    public IVectorEntry? Font { get; private set; }
    public IVectorEntry? Spacing { get; private set; }
    public string? Text { get; private set; }
    public IVectorEntry? Window { get; private set; }
    public string? TextWrap { get; private set; }
    public ITimeEntry? DisplayTime { get; private set; }
    public int? Layer { get; private set; }
    public IVectorEntry? Scale { get; private set; }
    public bool? Shake { get; private set; }

    public override ITextEntry Read()
    {
        Offset = Section?.GetValue<IVectorEntry>(FieldKey + ".offset");
        Font = Section?.GetValue<IVectorEntry>(FieldKey + ".font");
        Spacing = Section?.GetValue<IVectorEntry>(FieldKey + ".spacing");
        Text = Section?.GetValue<string>(FieldKey + ".text");
        Window = Section?.GetValue<IVectorEntry>(FieldKey + ".window");
        TextWrap = Section?.GetValue<string>(FieldKey + ".textwrap");
        DisplayTime = Section?.GetValue<ITimeEntry>(FieldKey + ".displaytime");
        Layer = Section?.GetValue<int>(FieldKey + ".layerno");
        Scale = Section?.GetValue<IVectorEntry>(FieldKey + ".scale");
        Shake = Section?.GetValue<bool>(FieldKey + ".shake");

        return this;
    }
}