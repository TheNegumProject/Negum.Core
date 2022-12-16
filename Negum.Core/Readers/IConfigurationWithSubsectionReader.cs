using System.Linq;
using Negum.Core.Configurations;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is designed to handle specific configuration file by it's path with multiple subsections.
/// Subsections are defined under the definition section which have a postfix of "-def".
/// I.e. "OptionBGdef" and "OptionBG 1", etc.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConfigurationWithSubsectionReader : IConfigurationReader
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConfigurationWithSubsectionReader : ConfigurationReader, IConfigurationWithSubsectionReader
{
    protected virtual bool IsSubsection(IConfigurationSection? lastSection, IConfigurationSection section)
    {
        if (lastSection == null)
        {
            return false;
        }

        var lastSectionNamePrefix = lastSection.Name.ToLower().EndsWith("def") ? lastSection.Name[..^3] : lastSection.Name;

        return section.Name.StartsWith(lastSectionNamePrefix);
    }

    protected override void InitializeConfigurationSection(IConfiguration configuration,
        IConfigurationSection section)
    {
        var lastSection = configuration.LastOrDefault();

        if (IsSubsection(lastSection, section))
        {
            lastSection?.AddSubsection(section);
        }
        else
        {
            configuration.AddSection(section);
        }
    }
}