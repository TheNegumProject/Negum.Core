namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SelectionManager : Manager, ISelectionManager
    {
    }

    public class SelectionManagerSection :
        ManagerSection,
        ISelectionCharacters,
        ISelectionExtraStages,
        ISelectionOptions
    {
    }
}