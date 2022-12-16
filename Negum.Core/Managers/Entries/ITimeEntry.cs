using System;

namespace Negum.Core.Managers.Entries;

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
    DateTime? GetDateTime();

    /// <summary>
    /// </summary>
    /// <returns>Current time value in a form of TimeSpan.</returns>
    TimeSpan? GetTimeSpan();
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class TimeEntry : ManagerSectionEntry<ITimeEntry>, ITimeEntry
{
    public override ITimeEntry Read() => this;
    public DateTime? GetDateTime() => Entry is null ? null : DateTime.Parse(Entry.Value ?? string.Empty);
    public TimeSpan? GetTimeSpan() => Entry is null ? null : TimeSpan.FromTicks(long.Parse(Entry.Value ?? string.Empty));
}