using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SelectionManager : Manager, ISelectionManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) => new SelectionManagerSection(sectionName, configSection);
}

public class SelectionManagerSection :
    ManagerSection,
    ISelectionCharacters,
    ISelectionExtraStages,
    ISelectionOptions
{
    public SelectionManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
    }
}