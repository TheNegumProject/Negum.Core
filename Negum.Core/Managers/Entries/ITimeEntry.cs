using System;

namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Time entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ITimeEntry : IManagerSectionEntry<ITimeEntry>
    {
        /// <summary>
        /// </summary>
        /// <returns>Current time value in a form of DateTime.</returns>
        DateTime GetDateTime();

        /// <summary>
        /// </summary>
        /// <returns>Current time value in a form of TimeSpan.</returns>
        TimeSpan GetTimeSpan();
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class TimeEntry : ManagerSectionEntry<ITimeEntry>, ITimeEntry
    {
        public override ITimeEntry Get() => this;
        public DateTime GetDateTime() => DateTime.Parse(this.Entry.Value);
        public TimeSpan GetTimeSpan() => TimeSpan.FromTicks(long.Parse(this.Entry.Value));
    }
}