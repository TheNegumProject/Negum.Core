namespace Negum.Core.Managers.Entries
{
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
        IVectorEntry Sprite { get; }

        /// <summary>
        /// Offset by which current image should be moved.
        /// Position offset.
        /// </summary>
        IVectorEntry Offset { get; }

        /// <summary>
        /// Scales the image.
        /// </summary>
        IVectorEntry Scale { get; }

        /// <summary>
        /// Direction of image facing.
        /// </summary>
        int Facing { get; }

        IVectorEntry Window { get; }

        /// <summary>
        /// Animation action number.
        /// </summary>
        int Animation { get; }

        /// <summary>
        /// Describes how long to display current image.
        /// </summary>
        ITimeEntry Time { get; }

        /// <summary>
        /// Time to start display.
        /// </summary>
        ITimeEntry StartTime { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ImageEntry : ManagerSectionEntry<IImageEntry>, IImageEntry
    {
        public IVectorEntry Sprite { get; private set; }
        public IVectorEntry Offset { get; private set; }
        public IVectorEntry Scale { get; private set; }
        public int Facing { get; private set; }
        public IVectorEntry Window { get; private set; }
        public int Animation { get; private set; }
        public ITimeEntry Time { get; private set; }
        public ITimeEntry StartTime { get; private set; }

        public override IImageEntry Get()
        {
            this.Sprite = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".spr");
            this.Offset = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".offset");
            this.Scale = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".scale");
            this.Facing = this.Section.GetValue<int>(this.FieldKey + ".facing");
            this.Window = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".window");
            this.Animation = this.Section.GetValue<int>(this.FieldKey + ".anim");
            this.Time = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".time");
            this.StartTime = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".starttime");

            return this;
        }
    }
}