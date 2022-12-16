namespace Negum.Core.Managers.Entries;

/// <summary>
/// Represents a Fighting Player entry in section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFightConfigurationPlayerEntry : IManagerSectionEntry<IFightConfigurationPlayerEntry>
{
    IVectorEntry? Position { get; }
    IImageEntry? Bg0 { get; }
    IImageEntry? Bg1 { get; }
    IImageEntry? Mid { get; }
    IImageEntry? Front { get; }
    IVectorEntry? RangeX { get; }
    ITextEntry? Counter { get; }
    IImageEntry? Face { get; }
    ITextEntry? Name { get; }
    IVectorEntry? IconOffset { get; }
    IFightConfigurationWinEntry? Win { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FightConfigurationPlayerEntry : ManagerSectionEntry<IFightConfigurationPlayerEntry>,
    IFightConfigurationPlayerEntry
{
    public IVectorEntry? Position { get; private set; }
    public IImageEntry? Bg0 { get; private set; }
    public IImageEntry? Bg1 { get; private set; }
    public IImageEntry? Mid { get; private set; }
    public IImageEntry? Front { get; private set; }
    public IVectorEntry? RangeX { get; private set; }
    public ITextEntry? Counter { get; private set; }
    public IImageEntry? Face { get; private set; }
    public ITextEntry? Name { get; private set; }
    public IVectorEntry? IconOffset { get; private set; }
    public IFightConfigurationWinEntry? Win { get; private set; }

    public override IFightConfigurationPlayerEntry Read()
    {
        Position = Section?.GetValue<IVectorEntry>(FieldKey + ".pos");
        Bg0 = Section?.GetValue<IImageEntry>(FieldKey + ".bg0");
        Bg1 = Section?.GetValue<IImageEntry>(FieldKey + ".bg1");
        Mid = Section?.GetValue<IImageEntry>(FieldKey + ".mid");
        Front = Section?.GetValue<IImageEntry>(FieldKey + ".front");
        RangeX = Section?.GetValue<IVectorEntry>(FieldKey + ".range.x");
        Counter = Section?.GetValue<ITextEntry>(FieldKey + ".counter");
        Face = Section?.GetValue<IImageEntry>(FieldKey + ".face");
        Name = Section?.GetValue<ITextEntry>(FieldKey + ".name");
        IconOffset = Section?.GetValue<IVectorEntry>(FieldKey + ".iconoffset");
        Win = Section?.GetValue<IFightConfigurationWinEntry>(FieldKey);

        return this;
    }
}