using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

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
    IStoryboardSceneDef SceneDef => GetSection<IStoryboardSceneDef>("SceneDef");
    IEnumerable<IStoryboardScene> Scenes => GetSubsections<IStoryboardScene>("SceneDef");
}

public interface IStoryboardSceneDef : IManagerSection
{
    /// <summary>
    /// Path to the sprite file.
    /// </summary>
    string? SpriteFile => GetValue<string>("spr");

    /// <summary>
    /// Stating scene number (for debugging).
    /// </summary>
    int? StartScene => GetValue<int>("startscene");
}

public interface IStoryboardScene : IManagerSection
{
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    IVectorEntry? FadeInColor => GetValue<IVectorEntry>("fadein.col");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    IVectorEntry? FadeOutColor => GetValue<IVectorEntry>("fadeout.col");
    IVectorEntry? ClearColor => GetValue<IVectorEntry>("clearcolor");
    IVectorEntry? LayerAllPosition => GetValue<IVectorEntry>("layerall.pos");
    IImageEntry? Layer0 => GetValue<IImageEntry>("layer0");
    IImageEntry? Layer1 => GetValue<IImageEntry>("layer1");
    IAudioEntry? BackgroundMusic => GetValue<IAudioEntry>("bgm");
    ITimeEntry? TotalTime => GetValue<ITimeEntry>("end.time");
}