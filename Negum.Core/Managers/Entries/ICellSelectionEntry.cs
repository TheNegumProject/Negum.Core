namespace Negum.Core.Managers.Entries
{
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
        IVectorEntry CellSize { get; }

        /// <summary>
        /// Space between each cell.
        /// </summary>
        int CellSpacing { get; }

        /// <summary>
        /// Background image of the current cell.
        /// </summary>
        ISpriteSoundEntry CellBg { get; }

        /// <summary>
        /// Icon for random select.
        /// </summary>
        ISpriteSoundEntry CellRandom { get; }

        /// <summary>
        /// Time to wait before changing to another random portrait.
        /// </summary>
        string CellRandomSwitchTime { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CellSelectionEntry : ManagerSectionEntry<ICellSelectionEntry>, ICellSelectionEntry
    {
        public IVectorEntry CellSize { get; private set; }
        public int CellSpacing { get; private set; }
        public ISpriteSoundEntry CellBg { get; private set; }
        public ISpriteSoundEntry CellRandom { get; private set; }
        public string CellRandomSwitchTime { get; private set; }

        public override ICellSelectionEntry Get()
        {
            this.CellSize = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".size");
            this.CellSpacing = this.Section.GetValue<int>(this.FieldKey + ".spacing");
            this.CellBg = this.Section.GetValue<ISpriteSoundEntry>(this.FieldKey + ".bg");
            this.CellRandom = this.Section.GetValue<ISpriteSoundEntry>(this.FieldKey + ".random");
            this.CellRandomSwitchTime = this.Section.GetValue<string>(this.FieldKey + ".random.switchtime");

            return this;
        }
    }
}