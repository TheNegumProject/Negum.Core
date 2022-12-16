namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Cell entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ICellSelectionEntry : IManagerSectionEntry<ICellSelectionEntry>
{
    /// <summary>
    /// (x,y) size of each cell in pixels.
    /// </summary>
    IVectorEntry? CellSize { get; }

    /// <summary>
    /// Space between each cell.
    /// </summary>
    int? CellSpacing { get; }

    /// <summary>
    /// Background image of the current cell.
    /// </summary>
    ISpriteSoundEntry? CellBg { get; }

    /// <summary>
    /// Icon for random select.
    /// </summary>
    ISpriteSoundEntry? CellRandom { get; }

    /// <summary>
    /// Time to wait before changing to another random portrait.
    /// </summary>
    string? CellRandomSwitchTime { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class CellSelectionEntry : ManagerSectionEntry<ICellSelectionEntry>, ICellSelectionEntry
{
    public IVectorEntry? CellSize { get; private set; }
    public int? CellSpacing { get; private set; }
    public ISpriteSoundEntry? CellBg { get; private set; }
    public ISpriteSoundEntry? CellRandom { get; private set; }
    public string? CellRandomSwitchTime { get; private set; }

    public override ICellSelectionEntry Read()
    {
        CellSize = Section?.GetValue<IVectorEntry>(FieldKey + ".size");
        CellSpacing = Section?.GetValue<int>(FieldKey + ".spacing");
        CellBg = Section?.GetValue<ISpriteSoundEntry>(FieldKey + ".bg");
        CellRandom = Section?.GetValue<ISpriteSoundEntry>(FieldKey + ".random");
        CellRandomSwitchTime = Section?.GetValue<string>(FieldKey + ".random.switchtime");

        return this;
    }
}