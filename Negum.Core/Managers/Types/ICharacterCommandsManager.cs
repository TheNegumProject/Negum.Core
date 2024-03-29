using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Character commands.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ICharacterCommandsManager : IManager
{
    ICharacterCommandsRemap Remap => GetSection<ICharacterCommandsRemap>("Remap");
    ICharacterCommandsDefaults Defaults => GetSection<ICharacterCommandsDefaults>("Defaults");
    IEnumerable<ICharacterCommandsCommand> Commands => GetSections<ICharacterCommandsCommand>("Command");
    ICharacterCommandsCommandStatedef StateDef => GetSection<ICharacterCommandsCommandStatedef>("Statedef");
    IEnumerable<ICharacterCommandsState> States => GetSubsections<ICharacterCommandsState>("Statedef");
}

public interface ICharacterCommandsRemap : IManagerSection
{
    string? A => GetValue<string>("a");
    string? B => GetValue<string>("b");
    string? C => GetValue<string>("c");
    string? X => GetValue<string>("x");
    string? Y => GetValue<string>("y");
    string? Z => GetValue<string>("z");
    string? S => GetValue<string>("s");
}

public interface ICharacterCommandsDefaults : IManagerSection
{
    /// <summary>
    /// Default value for the "time" parameter of a Command. Minimum 1.
    /// </summary>
    ITimeEntry? CommandTime => GetValue<ITimeEntry>("command.time");

    /// <summary>
    /// Default value for the "buffer.time" parameter of a Command. Minimum 1, maximum 30.
    /// </summary>
    ITimeEntry? CommandBufferTime => GetValue<ITimeEntry>("command.buffer.time");
}

public interface ICharacterCommandsCommand : IManagerSection
{
    /// <summary>
    /// A name to give that command.
    /// You'll use this name to refer to that command in the state entry, as well as the CNS.
    /// It is case-sensitive (QCB_a is NOT the same as Qcb_a or QCB_A).
    /// </summary>
    string? CommandName => GetValue<string>("name");

    /// <summary>
    /// List of buttons or directions, separated by commas.
    /// Each of these buttons or directions is referred to as a "symbol".
    /// Directions and buttons can be preceded by special characters:
    ///     1. slash (/) - means the key must be held down
    ///             egs. command = /D       ;hold the down direction
    ///                  command = /DB, a   ;hold down-back while you press a
    ///     2. tilde (~) - to detect key releases
    ///             egs. command = ~a       ;release the a button
    ///                  command = ~D, F, a ;release down, press fwd, then a
    ///                  If you want to detect "charge moves", you can specify the time the key must be held down for (in game-ticks)
    ///                     egs. command = ~30a     ;hold a for at least 30 ticks, then release
    ///     3. dollar ($) - Direction-only: detect as 4-way
    ///             egs. command = $D       ;will detect if D, DB or DF is held
    ///                  command = $B       ;will detect if B, DB or UB is held
    ///     4. plus (+) - Buttons only: simultaneous press
    ///             egs. command = a+b      ;press a and b at the same time
    ///                  command = x+y+z    ;press x, y and z at the same time
    ///     5. greater-than (>) - means there must be no other keys pressed or released between the previous and the current symbol.
    ///             egs. command = a, >~a   ;press a and release it without having hit or released any other keys in between
    /// You can combine the symbols:
    ///     eg. command = ~30$D, a+b     ;hold D, DB or DF for 30 ticks, release, then press a and b together
    /// Note: Successive direction symbols are always expanded in a manner similar to this example:
    ///     command = F, F
    /// is expanded when engine reads it, to become equivalent to:
    ///     command = F, >~F, >F
    ///
    /// It is recommended that for most "motion" commands, eg. quarter-circle-fwd, you start off with a "release direction".
    /// This makes the command easier to do.
    /// </summary>
    string? Command => GetValue<string>("command");

    /// <summary>
    /// Time allowed to do the command, given in game-ticks.
    /// The default value for this is set in the [Defaults] section below.
    /// A typical value is 15.
    /// </summary>
    ITimeEntry? Time => GetValue<ITimeEntry>("time");

    /// <summary>
    /// Time that the command will be buffered for.
    /// If the command is done successfully, then it will be valid for this time.
    /// The simplest case is to set this to 1.
    /// That means that the command is valid only in the same tick it is performed.
    /// With a higher value, such as 3 or 4, you can get a "looser" feel to the command.
    /// The result is that combos can become easier to do because you can perform the command early.
    /// Attacks just as you regain control (eg. from getting up) also become easier to do.
    /// The side effect of this is that the command is continuously asserted,
    /// so it will seem as if you had performed the move rapidly in succession during the valid time.
    /// To understand this, try setting buffer.time to 30 and hit a fast attack, such as sample light punch.
    /// The default value for this is set in the [Defaults] section below.
    /// This parameter does not affect hold-only commands (eg. /F).
    /// It will be assumed to be 1 for those commands.
    /// </summary>
    ITimeEntry? BufferTime => GetValue<ITimeEntry>("buffer.time");
}

public interface ICharacterCommandsCommandStatedef : IManagerSection
{
}

public interface ICharacterCommandsState : IManagerSection
{
    string? Type => GetValue<string>("type");

    /// <summary>
    /// The number of the state to change to.
    /// </summary>
    int? Value => GetValue<int>("value");

    /// <summary>
    /// Parameters which will be used for all triggers.
    /// </summary>
    IEnumerable<ITriggerEntry> TriggerAlls => GetValues<ITriggerEntry>(TriggerEntry.TriggerAllKey);

    /// <summary>
    /// Useful triggers to know:
    ///     - statetype
    ///         S, C or A : current state-type of player (stand, crouch, air)
    ///     - ctrl
    ///         0 or 1 : 1 if player has control. Unless "interrupting" another move, you'll want ctrl = 1
    ///     - stateno
    ///         number of state player is in - useful for "move interrupts"
    ///     - movecontact
    ///         0 or 1 : 1 if player's last attack touched the opponent useful for "move interrupts"
    ///
    /// Note:
    /// The order of state entry is important.
    /// State entry with a certain command must come before another state entry with a command that is the subset of the first.
    /// For example, command "fwd_a" must be listed before "a", and "fwd_ab" should come before both of the others.
    /// </summary>
    IEnumerable<ITriggerEntry> Triggers => GetValues<ITriggerEntry>(TriggerEntry.TriggerKey);

    /// <summary>
    /// Combo conditions.
    /// </summary>
    IEnumerable<IComboConditionEntry> Vars => GetValues<IComboConditionEntry>("var");
}