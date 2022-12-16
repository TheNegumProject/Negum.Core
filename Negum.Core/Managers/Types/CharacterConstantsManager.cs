using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class CharacterConstantsManager : ConstantsManager, ICharacterConstantsManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) => new CharacterConstantsManagerSection(sectionName, configSection);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class CharacterConstantsManagerSection :
    ConstantsManagerSection,
    ICharacterConstantsData,
    ICharacterConstantsSize,
    ICharacterConstantsVelocity,
    ICharacterConstantsMovement,
    ICharacterConstantsQuotes
{
    public CharacterConstantsManagerSection(string name, IConfigurationSection section) : 
        base(name, section)
    {
    }
}