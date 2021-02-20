namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Demo Mode entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDemoModeFightEntry : IManagerSectionEntry<IDemoModeFightEntry>
    {
        /// <summary>
        /// Time to display the fight before returning to title.
        /// </summary>
        ITimeEntry EndTime { get; }

        /// <summary>
        /// Set to true to enable in-fight BGM, false to disable.
        /// </summary>
        bool PlayBackgroundMusic { get; }

        /// <summary>
        /// Set to true to stop title BGM (only if playbgm = true).
        /// </summary>
        bool StopBackgroundMusic { get; }

        /// <summary>
        /// Set to true to display lifebar, false to disable.
        /// </summary>
        bool DisplayBars { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class DemoModeFightEntry : ManagerSectionEntry<IDemoModeFightEntry>, IDemoModeFightEntry
    {
        public ITimeEntry EndTime { get; private set; }
        public bool PlayBackgroundMusic { get; private set; }
        public bool StopBackgroundMusic { get; private set; }
        public bool DisplayBars { get; private set; }

        public override IDemoModeFightEntry Get()
        {
            this.EndTime = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".endtime");
            this.PlayBackgroundMusic = this.Section.GetValue<bool>(this.FieldKey + ".playbgm");
            this.StopBackgroundMusic = this.Section.GetValue<bool>(this.FieldKey + ".stopbgm");
            this.DisplayBars = this.Section.GetValue<bool>(this.FieldKey + ".bars.display");

            return this;
        }
    }
}