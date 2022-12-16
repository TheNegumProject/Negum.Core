namespace Negum.Core.Configurations.Animations;

/// <summary>
/// Represents a definition of a section in configuration which describe AIR aka Animation file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IAnimationSection : IConfigurationSection
{
    /// <summary>
    /// Number of the current action.
    /// Action Number are generally next to the Section Name.
    /// i.e. [Begin Action 810] where 810 is an Action Number.
    /// </summary>
    int ActionNumber { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class AnimationSection : ConfigurationSection, IAnimationSection
{
    public int ActionNumber { get; internal set; }
}