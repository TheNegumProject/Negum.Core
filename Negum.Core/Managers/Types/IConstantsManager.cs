using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Constants file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConstantsManager : IManager
{
    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Statedef by it's Id.</returns>
    IConstantsStatedef GetStateDef(int id);

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>States from the Statedef by they id.</returns>
    IEnumerable<IConstantsState> GetStates(int id);
}

public interface IConstantsStatedef : IManagerSection
{
    /// <summary>
    /// This is the state type of P1 in that state.
    /// It defines if he is standing, crouching, in the air, or lying down.
    /// The corresponding values are "S", "C" , "A" and "L" respectively (without the quotation marks).
    /// To leave the type unchanged from the previous state, use a value of "U".
    /// If this line is omitted, it assumes the type is "S".
    /// You will most commonly use "S", "C" and "A".
    ///
    /// The type is used to determine several factors, most importantly, how P1 will react to being hit.
    /// For example, being in a "stand"-type state, P1 will react as if he is standing on the ground.
    /// If the type was "air", then P1 would react to the hit accordingly.
    /// </summary>
    string? Type => GetValue<string>("type");

    /// <summary>
    /// This is the type of move P1 is doing: "A" for attack, "I" for idle and "H" for being hit.
    /// To leave the movetype unchanged from the previous state, use a value of "U".
    /// The value is assumed to be "I" if this line is omitted.
    /// "A" and "H" should be self-explanatory.
    /// "I" is used for states where P1 is neither attacking, nor being hit. 
    /// </summary>
    string? MoveType => GetValue<string>("movetype");

    /// <summary>
    /// You need to specify what physics to use in that state.
    /// Valid values are "S" for stand, "C" for crouch, "A" for air, and "N" for none.
    /// To leave the physics unchanged from the previous state, use a value of "U".
    /// If omitted, the value of "N" is assumed.
    /// The kind of physics is used to determine how P1 behaves.
    ///
    /// For "S" physics, P1 will experience friction with the ground. The value for the friction coefficient is set in the Player Variables.
    /// For "C" physics, P1 will experience friction, just like in the "S" state.
    /// For "A" physics, P1 will accelerate downwards, and if his y-position is greater than 0 (ie. he touches the ground) he will immediately go into his landing state.
    /// If you use "N" P1 will not use any of these pre-programmed physics.
    ///
    /// Do not confuse "physics" with the state "type".
    /// They are usually the same, but you are given the choice if you want more control.
    /// For instance, you may choose to use "N" (no physics), and specify your own acceleration and landing detection for an aerial state.
    /// </summary>
    string? Physics => GetValue<string>("physics");

    /// <summary>
    /// This parameter changes the Animation Action of P1.
    /// Specify the action number as the value.
    /// If you do not want P1 to change animation at the start of the state, omit this parameter.
    /// </summary>
    string? Animation => GetValue<string>("anim");

    /// <summary>
    /// You can use velset to set P1's velocity at the beginning of the state.
    /// The format is a number pair, representing the x velocity and the y velocity respectively.
    /// Omitting this line will leave P1's velocity unchanged.
    /// 
    /// There is an exception to this.
    /// Even if you have velset = 0, attacking P2 in the corner will push P1 away.
    /// </summary>
    IVectorEntry? Velocity => GetValue<IVectorEntry>("velset");

    /// <summary>
    /// This parameter will set P1's control.
    /// A value of "0" sets the flag to false, "1" sets it to true.
    /// If omitted, P1's control flag is left unchanged. 
    /// </summary>
    string? Control => GetValue<string>("ctrl");

    /// <summary>
    /// When included, the poweradd parameter adds to the player's power bar.
    /// The value is a number, and can be positive or negative.
    /// This parameter is typically used in attack moves, where you want the player to gain power just by performing the attack. 
    /// </summary>
    string? PowerAdd => GetValue<string>("poweradd");

    /// <summary>
    /// The juggle parameter is useful only for attacks.
    /// It specifies how many points of juggling the move requires.
    /// If omitted for an attack, that attack will juggle if the previous attacking state successfully juggled.
    /// You should include the juggle parameter for all attacks.
    /// If an attack spans more than one state, include the juggle parameter only in the first state of that attack.
    /// </summary>
    string? Juggle => GetValue<string>("juggle");

    /// <summary>
    /// When you include the line facep2 = true, the player will be turned, if necessary, to face the opponent at the beginning of the state.
    /// facep2 has the default value of "false" if omitted.
    /// </summary>
    bool? FaceP2 => GetValue<bool>("facep2");

    /// <summary>
    /// If set to true, any HitDefs which are active at the time of a state transition to this state will remain active.
    /// If set to false, (the default), any such HitDefs will be disabled when the state transition is made.
    /// </summary>
    bool? HitDefPersist => GetValue<bool>("hitdefpersist");

    /// <summary>
    /// If set to true, the move hit information from the previous state (whether the attack hit or missed, guarded, etc) swill be carried over into this state.
    /// If set to false, (the default), this information will be reset upon entry into this state.
    /// </summary>
    bool? MoveHitPersist => GetValue<bool>("movehitpersist");

    /// <summary>
    /// If set to true, the hit counter (how many hits this attack has done) will be carried over from the previous state to this state.
    /// If set to false, (the default), the hit counter will be reset upon state transition.
    /// This parameter does not affect the combo counter which is displayed on the screen. 
    /// </summary>
    bool? HitCountPersist => GetValue<bool>("hitcountpersist");

    /// <summary>
    /// If this parameter is present, the player's sprite layering priority will be set to the value specified.
    /// If omitted, the sprite priority will be left unchanged.
    /// common1.cns (the CNS file that is inherited by every player) defines the sprite priority of standing or crouching players to be 0, and jumping players to be 1.
    /// For most attack states, you will want to set sprpriority = 2, so that the attacker appears in front.
    /// </summary>
    string? SprPriority => GetValue<string>("sprpriority");
}

public interface IConstantsState : IConstantsStatedef
{
    /// <summary>
    /// It specifies a condition that must be true for all triggers.
    /// For instance, consider:
    ///     triggerall = Vel X = 0
    ///     trigger1 = Pos Y > -2
    ///     trigger2 = AnimElem = 3
    ///     trigger3 = Time = [2,9]
    ///
    /// For any of trigger1 to trigger3 to be checked, the triggerall condition must be true too.
    /// In this case, as long as the x-velocity is not 0, then the state controller will not be activated.
    /// You can have more than one triggerall condition if you need.
    /// Note that at least one trigger1 must be present, even if you specify triggerall.
    /// </summary>
    IEnumerable<ITriggerEntry> TriggerAlls => GetValues<ITriggerEntry>(TriggerEntry.TriggerAllKey);

    /// <summary>
    /// The first trigger should always be trigger1, and subsequent triggers should be trigger2, then trigger3 and so on.
    /// The logic for deciding if a controller should be activated is:
    ///     - Are all conditions of trigger1 true? If so, then yes, activate the controller.
    ///     - Otherwise, repeat the test for trigger2, and so on, until no more triggers are found.
    ///
    /// This can be thought of as "OR" logic.
    ///
    /// Be careful; skipping numbers will cause some triggers to be ignored.
    /// For example, if you have triggers trigger1, trigger2 and trigger4 without a trigger3, then trigger4 will be ignored.
    ///
    /// Now what if you want more than one condition to be met before the controller is activated?
    /// Here is an commonly-used example for testing if a player in the air has reached the ground.
    /// The triggers used are:
    ///     trigger1 = Vel Y > 0 ; True if Y-velocity is > 0 (going down)
    ///     trigger1 = Pos Y > 0 ; True if Y-position is > 0 (below ground)
    ///
    /// At this point, you may be confused by the format of the trigger.
    /// Do not worry about it for now.
    /// We will get to it soon.
    ///
    /// As you can see above, both the triggers have the same number.
    /// When several triggers have the same number, it implements "AND" logic.
    /// That is, the controller is activated if every one of the triggers with the same number is true, but not if one or more of them is false.
    ///
    /// You can combine both ideas.
    /// For example:
    ///     trigger1 = Vel Y > 0 ; True if Y-velocity is > 0 (going down)
    ///     trigger1 = Pos Y > 0 ; True if Y-position is > 0 (below ground)
    ///     trigger2 = Time = 5  ; True if state-time is 5
    ///
    /// The controller for this would be activated if the player landed on the ground (y-velocity and y-Position are both > 0), OR if his state time was 5.
    ///
    /// Here is a summary:
    ///     - Triggers with the same number activate the controller only if all of them are true.
    ///     - Triggers with different numbers activate the controller if any one or more of them are true.
    ///
    /// The format of a trigger is:
    ///     trigger? = condition_exp
    ///
    /// condition_exp is an arithmetic expression to be checked for equality to 0.
    /// If condition_exp is 0, then the trigger is false.
    /// If condition_exp is nonzero, then the trigger is true.
    /// The condition_exp is usually a simple relational expression as in the examples above, but can be as simple or as complicated as required.
    ///
    /// It is possible to use logical operators between expressions.
    /// For instance, this is equivalent to the previous example above.
    ///     trigger1 = ((Vel Y > 0) && (Pos Y > 0)) || Time = 5
    /// </summary>
    IEnumerable<ITriggerEntry> Triggers => GetValues<ITriggerEntry>(TriggerEntry.TriggerKey);

    /// <summary>
    /// Should have the number of the state to change to.
    /// </summary>
    string? Value => GetValue<string>("value");
}