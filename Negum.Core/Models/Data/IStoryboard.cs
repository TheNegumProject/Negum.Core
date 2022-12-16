using Negum.Core.Managers.Types;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Models.Data;

/// <summary>
/// Represents Storyboard data read from directory.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IStoryboard
{
    /// <summary>
    /// Main manager which contains information about current Storyboard.
    /// </summary>
    IStoryboardManager? Manager { get; }

    /// <summary>
    /// Manager which contains information about Animations in this Storyboard.
    /// </summary>
    IAnimationManager? Animation { get; }

    /// <summary>
    /// Sprites used by this storyboard.
    /// </summary>
    ISprite? Sprite { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class Storyboard : IStoryboard
{
    public IStoryboardManager? Manager { get; internal init; }
    public IAnimationManager? Animation { get; internal init; }
    public ISprite? Sprite { get; internal set; }
}