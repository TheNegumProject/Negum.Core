using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterManager : Manager, ICharacterManager
    {
        protected override IManagerSection GetNewManagerSection(string sectionName,
            IConfigurationSection configSection) => new CharacterManagerSection(sectionName, configSection);
    }

    public class CharacterManagerSection :
        ManagerSection,
        ICharacterInfo,
        ICharacterFiles,
        ICharacterPaletteKeymap,
        ICharacterArcade
    {
        public CharacterManagerSection(string name, IConfigurationSection section) :
            base(name, section)
        {
        }
    }
}