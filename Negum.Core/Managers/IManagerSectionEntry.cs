using Negum.Core.Configurations;

namespace Negum.Core.Managers;

/// <summary>
/// Represents single entry returned from Manager's Section.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IManagerSectionEntry<out TEntryType>
{
    /// <summary>
    /// Section from which the current entry was created.
    /// </summary>
    IManagerSection? Section { get; }

    /// <summary>
    /// Prefix from which the current field was created.
    /// </summary>
    string? FieldKey { get; }

    /// <summary>
    /// Initializes current entry with values.
    /// This should be called only once per every new instance of the entry.
    /// Do not call it directly.
    /// </summary>
    /// <param name="section"></param>
    /// <param name="fieldKey"></param>
    /// <param name="entry"></param>
    void Initialize(IManagerSection section, string fieldKey, IConfigurationSectionEntry entry);

    /// <summary>
    /// </summary>
    /// <returns>Parsed value.</returns>
    TEntryType Read();
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public abstract class ManagerSectionEntry<TEntry> : IManagerSectionEntry<TEntry>
{
    protected IConfigurationSectionEntry? Entry { get; set; }

    public IManagerSection? Section { get; private set; }
    public string? FieldKey { get; private set; }

    public void Initialize(IManagerSection section, string fieldKey, IConfigurationSectionEntry entry)
    {
        Section = section;
        FieldKey = fieldKey;
        Entry = entry;
    }

    public abstract TEntry Read();
}