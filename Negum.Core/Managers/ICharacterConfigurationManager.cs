using Negum.Core.Containers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Character configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterConfigurationManager : IConfigurationManager<ICharacterConfigurationManager>
    {
        ICharacterConfigurationInfo Info =>
            NegumContainer.Resolve<ICharacterConfigurationInfo>().Setup(this.Scrapper.GetSection("Info"));

        ICharacterConfigurationFiles Files =>
            NegumContainer.Resolve<ICharacterConfigurationFiles>().Setup(this.Scrapper.GetSection("Files"));

        ICharacterConfigurationPaletteKeymap Keymap =>
            NegumContainer.Resolve<ICharacterConfigurationPaletteKeymap>()
                .Setup(this.Scrapper.GetSection("Palette Keymap"));
    }

    public interface ICharacterConfigurationInfo : IConfigurationManagerSection<ICharacterConfigurationInfo>
    {
    }

    public interface ICharacterConfigurationFiles : IConfigurationManagerSection<ICharacterConfigurationFiles>
    {
    }

    public interface ICharacterConfigurationPaletteKeymap :
        IConfigurationManagerSection<ICharacterConfigurationPaletteKeymap>
    {
    }
}