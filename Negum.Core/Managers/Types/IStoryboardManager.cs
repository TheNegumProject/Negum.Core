using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Storyboard configuration.
    ///
    /// NOTE:
    /// Similar to ICharacterStoryboardSceneManager but for different purposes.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStoryboardManager : IManager
    {
        IStoryboardSceneDef SceneDef => this.GetSection<IStoryboardSceneDef>("SceneDef");
        IEnumerable<IStoryboardScene> Scenes => this.GetSubsections<IStoryboardScene>("SceneDef");
    }

    public interface IStoryboardSceneDef : IManagerSection
    {
        string SpriteFile => this.GetValue<string>("spr");

        /// <summary>
        /// Stating scene number (for debugging).
        /// </summary>
        int StartScene => this.GetValue<int>("startscene");
    }

    public interface IStoryboardScene : IManagerSection
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