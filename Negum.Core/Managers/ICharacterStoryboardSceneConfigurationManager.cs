using System.Collections.Generic;
using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Character's Storyboard Scene configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterStoryboardSceneConfigurationManager :
        IConfigurationManager<ICharacterStoryboardSceneConfigurationManager>
    {
        ICharacterStoryboardSceneConfigurationSceneDef SceneDef =>
            NegumContainer.Resolve<ICharacterStoryboardSceneConfigurationSceneDef>()
                .Setup(this.Scrapper.GetSection("SceneDef"));

        IEnumerable<ICharacterStoryboardSceneConfigurationScene> Scenes =>
            NegumContainer.Resolve<ISectionCollectionProvider>()
                .SetupMultiple<ICharacterStoryboardSceneConfigurationScene>(this.Scrapper.GetSections("Scene "));
    }

    public interface ICharacterStoryboardSceneConfigurationSceneDef :
        IConfigurationManagerSection<ICharacterStoryboardSceneConfigurationSceneDef>
    {
        IFileEntry SpriteFile => Scrapper.GetFile("spr");

        /// <summary>
        /// Stating scene number (for debugging).
        /// </summary>
        int StartScene => Scrapper.GetInt("startscene");
    }

    public interface ICharacterStoryboardSceneConfigurationScene :
        IConfigurationManagerSection<ICharacterStoryboardSceneConfigurationScene>
    {
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        IVectorEntry FadeInColor => Scrapper.GetVector("fadein.col");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        IVectorEntry FadeOutColor => Scrapper.GetVector("fadeout.col");
        IVectorEntry ClearColor => Scrapper.GetVector("clearcolor");
        IVectorEntry LayerAllPosition => Scrapper.GetVector("layerall.pos");
        IImageEntry Layer0 => Scrapper.GetImage("layer0");
        IImageEntry Layer1 => Scrapper.GetImage("layer1");
        IAudioEntry BackgroundMusic => Scrapper.GetAudio("bgm");
        ITimeEntry TotalTime => Scrapper.GetTime("end.time");
    }
}