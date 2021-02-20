namespace Negum.Core.Managers.Entries
{
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
        IFileEntry File { get; }

        /// <summary>
        /// Volume scaling factor in percent.
        /// 100 is default.
        /// </summary>
        int Volume { get; }

        /// <summary>
        /// Set to true to allow looping.
        /// Set to false to prevent looping.
        /// </summary>
        bool Loop { get; }

        int LoopStart { get; }

        int LoopEnd { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class AudioEntry : ManagerSectionEntry<IAudioEntry>, IAudioEntry
    {
        public IFileEntry File { get; private set; }
        public int Volume { get; private set; }
        public bool Loop { get; private set; }
        public int LoopStart { get; private set; }
        public int LoopEnd { get; private set; }

        public override IAudioEntry Get()
        {
            this.File = this.Section.GetValue<IFileEntry>(this.FieldKey);
            this.Volume = this.Section.GetValue<int>(this.FieldKey + ".volume");
            this.Loop = this.Section.GetValue<bool>(this.FieldKey + ".loop");
            this.LoopStart = this.Section.GetValue<int>(this.FieldKey + ".loopstart");
            this.LoopEnd = this.Section.GetValue<int>(this.FieldKey + ".loopend");

            return this;
        }
    }
}