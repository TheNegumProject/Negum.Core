using Negum.Core.Managers.Types;
using Negum.Core.Models.Sounds;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Models.Data;

/// <summary>
/// Represents core data read from main configuration ("data") directory.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IData
{
    /// <summary>
    /// Manager which wraps core game configuration.
    /// </summary>
    IConfigurationManager? ConfigManager { get; }

    /// <summary>
    /// Manager which wraps motif's definition.
    /// </summary>
    IMotifManager? MotifManager { get; }

    /// <summary>
    /// Sprite read from motif file.
    /// </summary>
    ISprite? MotifSprite { get; }

    /// <summary>
    /// Sound read from motif file.
    /// </summary>
    ISound? MotifSound { get; }

    /// <summary>
    /// Manager which wraps selection definition.
    /// </summary>
    ISelectionManager? SelectionManager { get; }

    /// <summary>
    /// Manager which wraps fight definition.
    /// </summary>
    IFightManager? FightManager { get; }

    /// <summary>
    /// Defines Logo-related information.
    /// </summary>
    IStoryboard? Logo { get; }

    /// <summary>
    /// Defines Intro-related information.
    /// </summary>
    IStoryboard? Intro { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class NegumData : IData
{
    public IConfigurationManager? ConfigManager { get; internal set; }
    public IMotifManager? MotifManager { get; internal set; }
    public ISprite? MotifSprite { get; internal set; }
    public ISound? MotifSound { get; internal set; }
    public ISelectionManager? SelectionManager { get; internal set; }
    public IFightManager? FightManager { get; internal set; }
    public IStoryboard? Logo { get; internal set; }
    public IStoryboard? Intro { get; internal set; }
}