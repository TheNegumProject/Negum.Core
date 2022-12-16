using System;
using System.Collections.Generic;
using Negum.Core.Models.Characters;
using Negum.Core.Models.Data;
using Negum.Core.Models.Fonts;
using Negum.Core.Models.Sounds;
using Negum.Core.Models.Stages;

namespace Negum.Core.Engines;

/// <summary>
/// Represents core object which contains all data read from game directory.
/// IEngine should be created using IEngineProvider.Initialize(...)
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IEngine
{
    /// <summary>
    /// Path to the root directory or URL from which the engine was initialized.
    /// </summary>
    string? Path { get; }

    /// <summary>
    /// Represents information read from "data" directory.
    /// </summary>
    IData? Data { get; }

    /// <summary>
    /// Represents information read from "font" directory.
    /// </summary>
    IEnumerable<IFont> Fonts { get; }

    /// <summary>
    /// Represents information read from "sound" directory.
    /// </summary>
    IEnumerable<ISound> Sounds { get; }
        
    /// <summary>
    /// Represents information read from "stages" directory.
    /// </summary>
    IEnumerable<IStage> Stages { get; }
        
    /// <summary>
    /// Represents information read from "chars" directory.
    /// </summary>
    IEnumerable<ICharacter> Characters { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class EngineInstance : IEngine
{
    public string? Path { get; internal init; }
    public IData? Data { get; internal set; }
    public IEnumerable<IFont> Fonts { get; internal set; } = Array.Empty<IFont>();
    public IEnumerable<ISound> Sounds { get; internal set; } = Array.Empty<ISound>();
    public IEnumerable<IStage> Stages { get; internal set; } = Array.Empty<IStage>();
    public IEnumerable<ICharacter> Characters { get; internal set; } = Array.Empty<ICharacter>();
}