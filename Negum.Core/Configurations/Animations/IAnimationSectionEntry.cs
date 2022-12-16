using System.Collections.Generic;

namespace Negum.Core.Configurations.Animations;

/// <summary>
/// Represents a definition of an entry in a section in configuration which describe AIR aka Animation file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IAnimationSectionEntry : IConfigurationSectionEntry
{
    /// <summary>
    /// Indicates if this collision box can be described as default.
    /// </summary>
    bool IsDefault { get; }

    /// <summary>
    /// Each sprite entry can have its own collision boxes.
    /// Clsn2 refers to a plain collision box and Clsn1 refers to an "attacking" box.
    /// You use attacking boxes when making attacking actions such as punching and kicking or special moves.
    /// 
    /// 1 - Attacking Box
    /// 2 - Plain Box
    /// </summary>
    int TypeId { get; }

    /// <summary>
    /// Collection of boxes describing current animations.
    /// Each box is build out of 4 values which describe x1, y1, x2, y2 values.
    /// </summary>
    IEnumerable<string> Boxes { get; }

    /// <summary>
    /// Animation elements connected with the current entry.
    /// </summary>
    IEnumerable<IAnimationElement> AnimationElements { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class AnimationSectionEntry : ConfigurationSectionEntry, IAnimationSectionEntry
{
    public bool IsDefault { get; internal set; }
    public int TypeId { get; internal set; }
    public IEnumerable<string> Boxes { get; } = new List<string>();
    public IEnumerable<IAnimationElement> AnimationElements { get; } = new List<IAnimationElement>();

    public void AddBox(string box) =>
        ((List<string>) Boxes).Add(box);

    public void AddAnimationElement(IAnimationElement element) =>
        ((List<IAnimationElement>) AnimationElements).Add(element);
}