namespace Negum.Core.Managers
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