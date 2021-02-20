namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Fighting Player entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationPlayerEntry : IManagerSectionEntry<IFightConfigurationPlayerEntry>
    {
        IVectorEntry Position { get; }
        IImageEntry Bg0 { get; }
        IImageEntry Bg1 { get; }
        IImageEntry Mid { get; }
        IImageEntry Front { get; }
        IVectorEntry RangeX { get; }
        ITextEntry Counter { get; }
        IImageEntry Face { get; }
        ITextEntry Name { get; }
        IVectorEntry IconOffset { get; }
        IFightConfigurationWinEntry Win { get; }
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
        public IVectorEntry Position { get; private set; }
        public IImageEntry Bg0 { get; private set; }
        public IImageEntry Bg1 { get; private set; }
        public IImageEntry Mid { get; private set; }
        public IImageEntry Front { get; private set; }
        public IVectorEntry RangeX { get; private set; }
        public ITextEntry Counter { get; private set; }
        public IImageEntry Face { get; private set; }
        public ITextEntry Name { get; private set; }
        public IVectorEntry IconOffset { get; private set; }
        public IFightConfigurationWinEntry Win { get; private set; }

        public override IFightConfigurationPlayerEntry Get()
        {
            this.Position = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".pos");
            this.Bg0 = this.Section.GetValue<IImageEntry>(this.FieldKey + ".bg0");
            this.Bg1 = this.Section.GetValue<IImageEntry>(this.FieldKey + ".bg1");
            this.Mid = this.Section.GetValue<IImageEntry>(this.FieldKey + ".mid");
            this.Front = this.Section.GetValue<IImageEntry>(this.FieldKey + ".front");
            this.RangeX = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".range.x");
            this.Counter = this.Section.GetValue<ITextEntry>(this.FieldKey + ".counter");
            this.Face = this.Section.GetValue<IImageEntry>(this.FieldKey + ".face");
            this.Name = this.Section.GetValue<ITextEntry>(this.FieldKey + ".name");
            this.IconOffset = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".iconoffset");
            this.Win = this.Section.GetValue<IFightConfigurationWinEntry>(this.FieldKey);

            return this;
        }
    }
}