using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConstantsManager : Manager, IConstantsManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) => new ConstantsManagerSection(sectionName, configSection);

    public IConstantsStatedef GetStateDef(int id) =>
        GetSection<IConstantsStatedef>("Statedef " + id);

    public IEnumerable<IConstantsState> GetStates(int id) => 
        GetSubsections<IConstantsState>("Statedef " + id);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConstantsManagerSection :
    ManagerSection,
    IConstantsState
{
    public ConstantsManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
    }
}