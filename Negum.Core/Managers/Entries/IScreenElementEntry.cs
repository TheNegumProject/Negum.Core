namespace Negum.Core.Managers.Entries
{
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
        ITimeEntry Time { get; }

        /// <summary>
        /// Image to be displayed.
        /// </summary>
        IImageEntry Image { get; }

        /// <summary>
        /// Sound to play.
        /// </summary>
        IVectorEntry Sound { get; }

        /// <summary>
        /// Time to play sound.
        /// </summary>
        ITimeEntry SoundTime { get; }

        /// <summary>
        /// Text to display.
        /// </summary>
        ITextEntry Text { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ScreenElementEntry : ManagerSectionEntry<IScreenElementEntry>, IScreenElementEntry
    {
        public ITimeEntry Time { get; private set; }
        public IImageEntry Image { get; private set; }
        public IVectorEntry Sound { get; private set; }
        public ITimeEntry SoundTime { get; private set; }
        public ITextEntry Text { get; private set; }

        public override IScreenElementEntry Get()
        {
            this.Time = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".time");
            this.Image = this.Section.GetValue<IImageEntry>(this.FieldKey);
            this.Sound = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".snd");
            this.SoundTime = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".sndtime");
            this.Text = this.Section.GetValue<ITextEntry>(this.FieldKey);

            return this;
        }
    }
}