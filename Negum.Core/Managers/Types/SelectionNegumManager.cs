namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SelectionNegumManager : NegumManager, ISelectionNegumManager
    {
    }

    public class SelectionNegumManagerSection :
        NegumManagerSection,
        ISelectionNegumCharacters,
        ISelectionNegumExtraStages,
        ISelectionNegumOptions
    {
    }
}