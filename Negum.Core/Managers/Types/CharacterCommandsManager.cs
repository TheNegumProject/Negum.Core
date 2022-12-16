using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class CharacterCommandsManager : Manager, ICharacterCommandsManager
{
    protected override IManagerSection
        GetNewManagerSection(string sectionName, IConfigurationSection configSection) =>
        new CharacterCommandsManagerSection(sectionName, configSection);
}

public class CharacterCommandsManagerSection :
    ManagerSection,
    ICharacterCommandsRemap,
    ICharacterCommandsDefaults,
    ICharacterCommandsCommand,
    ICharacterCommandsCommandStatedef,
    ICharacterCommandsState
{
    public CharacterCommandsManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
    }
}