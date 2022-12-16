using Negum.Core.Configurations;
using Negum.Core.Configurations.Constants;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is designed to handle CNS aka Constants configuration.
/// Constants configuration contains sections which could starts with either "State", "Statedef" or some name.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConstantsReader : IConfigurationWithSubsectionReader
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConstantsReader : ConfigurationWithSubsectionReader, IConstantsReader
{
    protected override bool IsSubsection(IConfigurationSection? lastSection, IConfigurationSection section)
    {
        if (section.Name.StartsWith("Statedef"))
        {
            return false;
        }
            
        if (section.Name.StartsWith("State"))
        {
            return true;
        }

        return base.IsSubsection(lastSection, section);
    }

    protected override void AddSection(string sectionName)
    {
        var section = new ConstantsSection();

        if (sectionName.StartsWith("Statedef ") || sectionName.StartsWith("State "))
        {
            var parts = sectionName.Split(",");

            section.Id = int.Parse(parts[0].Split(" ")[1]);
                
            section.Name = sectionName.Split(" ")[0] + " " + section.Id;

            if (parts.Length > 1)
            {
                section.Action = parts[1].Trim();
            }
        }
        else
        {
            section.Name = sectionName;
        }

        section.Entries = Entries;
            
        Sections.Add(section);
    }
}