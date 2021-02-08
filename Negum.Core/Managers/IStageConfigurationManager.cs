using System.Collections.Generic;
using Negum.Core.Containers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Stage configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageConfigurationManager : IConfigurationManager<IStageConfigurationManager>
    {
        IStageConfigurationInfo Info =>
            NegumContainer.Resolve<IStageConfigurationInfo>().Setup(this.Scrapper.GetSection("Info"));

        IStageConfigurationCamera Camera =>
            NegumContainer.Resolve<IStageConfigurationCamera>().Setup(this.Scrapper.GetSection("Camera"));

        IStageConfigurationPlayerInfo PlayerInfo =>
            NegumContainer.Resolve<IStageConfigurationPlayerInfo>().Setup(this.Scrapper.GetSection("PlayerInfo"));

        IStageConfigurationBound Bound =>
            NegumContainer.Resolve<IStageConfigurationBound>().Setup(this.Scrapper.GetSection("Bound"));

        IStageConfigurationStageInfo StageInfo =>
            NegumContainer.Resolve<IStageConfigurationStageInfo>().Setup(this.Scrapper.GetSection("StageInfo"));

        IStageConfigurationShadow Shadow =>
            NegumContainer.Resolve<IStageConfigurationShadow>().Setup(this.Scrapper.GetSection("Shadow"));

        IStageConfigurationReflection Reflection =>
            NegumContainer.Resolve<IStageConfigurationReflection>().Setup(this.Scrapper.GetSection("Reflection"));

        IStageConfigurationMusic Music =>
            NegumContainer.Resolve<IStageConfigurationMusic>().Setup(this.Scrapper.GetSection("Music"));

        IStageConfigurationBackgroundDef BackgroundDef =>
            NegumContainer.Resolve<IStageConfigurationBackgroundDef>().Setup(this.Scrapper.GetSection("BGdef"));

        IEnumerable<IStageConfigurationBackground> Backgrounds =>
            NegumContainer.Resolve<ISectionCollectionProvider>()
                .SetupMultiple<IStageConfigurationBackground>(this.Scrapper.GetSections("BG "));
    }

    public interface IStageConfigurationInfo : IConfigurationManagerSection<IStageConfigurationInfo>
    {
    }

    public interface IStageConfigurationCamera : IConfigurationManagerSection<IStageConfigurationCamera>
    {
    }

    public interface IStageConfigurationPlayerInfo : IConfigurationManagerSection<IStageConfigurationPlayerInfo>
    {
    }

    public interface IStageConfigurationBound : IConfigurationManagerSection<IStageConfigurationBound>
    {
    }

    public interface IStageConfigurationStageInfo : IConfigurationManagerSection<IStageConfigurationStageInfo>
    {
    }

    public interface IStageConfigurationShadow : IConfigurationManagerSection<IStageConfigurationShadow>
    {
    }

    public interface IStageConfigurationReflection : IConfigurationManagerSection<IStageConfigurationReflection>
    {
    }

    public interface IStageConfigurationMusic : IConfigurationManagerSection<IStageConfigurationMusic>
    {
    }

    public interface IStageConfigurationBackgroundDef : IConfigurationManagerSection<IStageConfigurationBackgroundDef>
    {
    }

    public interface IStageConfigurationBackground : IConfigurationManagerSection<IStageConfigurationBackground>
    {
    }
}