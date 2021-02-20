using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Character's Storyboard Scene configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterStoryboardSceneManager : IManager
    {
        ICharacterStoryboardSceneSceneDef SceneDef =>
            this.GetSection<ICharacterStoryboardSceneSceneDef>("SceneDef");

        IEnumerable<ICharacterStoryboardSceneScene> Scenes =>
            this.GetSections<ICharacterStoryboardSceneScene>("Scene ");
    }

    public interface ICharacterStoryboardSceneSceneDef : IManagerSection
    {
        IFileEntry SpriteFile => this.GetValue<IFileEntry>("spr");

        /// <summary>
        /// Stating scene number (for debugging).
        /// </summary>
        int StartScene => this.GetValue<int>("startscene");
    }

    public interface ICharacterStoryboardSceneScene : IManagerSection
    {
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        IVectorEntry FadeInColor => this.GetValue<IVectorEntry>("fadein.col");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        IVectorEntry FadeOutColor => this.GetValue<IVectorEntry>("fadeout.col");
        IVectorEntry ClearColor => this.GetValue<IVectorEntry>("clearcolor");
        IVectorEntry LayerAllPosition => this.GetValue<IVectorEntry>("layerall.pos");
        IImageEntry Layer0 => this.GetValue<IImageEntry>("layer0");
        IImageEntry Layer1 => this.GetValue<IImageEntry>("layer1");
        IAudioEntry BackgroundMusic => this.GetValue<IAudioEntry>("bgm");
        ITimeEntry TotalTime => this.GetValue<ITimeEntry>("end.time");
    }
}