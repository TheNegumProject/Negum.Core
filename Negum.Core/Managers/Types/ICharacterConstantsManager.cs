using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Character Constants file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ICharacterConstantsManager : IConstantsManager
{
    ICharacterConstantsData Data => GetSection<ICharacterConstantsData>("Data");
    ICharacterConstantsSize Size => GetSection<ICharacterConstantsSize>("Size");
    ICharacterConstantsVelocity Velocity => GetSection<ICharacterConstantsVelocity>("Velocity");
    ICharacterConstantsMovement Movement => GetSection<ICharacterConstantsMovement>("Movement");
    ICharacterConstantsQuotes Quotes => GetSection<ICharacterConstantsQuotes>("Quotes");
}

public interface ICharacterConstantsData : IManagerSection
{
    /// <summary>
    /// Amount of life to start with.
    /// </summary>
    int? Life => GetValue<int>("life");

    /// <summary>
    /// Attack power (more is stronger).
    /// </summary>
    int? Attack => GetValue<int>("attack");

    /// <summary>
    /// Defensive power (more is stronger).
    /// </summary>
    int? Defence => GetValue<int>("defence");

    /// <summary>
    /// Percentage to increase defense everytime player is knocked down.
    /// </summary>
    int? FallDefenceUp => GetValue<int>("fall.defence_up");

    /// <summary>
    /// Time which player lies down for, before getting up.
    /// </summary>
    int? LieDownTime => GetValue<int>("liedown.time");

    /// <summary>
    /// Number of points for juggling.
    /// </summary>
    int? AirJuggle => GetValue<int>("airjuggle");

    /// <summary>
    /// Default hit spark number for HitDefs.
    /// </summary>
    int? SparkNo => GetValue<int>("sparkno");

    /// <summary>
    /// Default guard spark number.
    /// </summary>
    int? GuardSparkNo => GetValue<int>("guard.sparkno");

    /// <summary>
    /// True to enable echo on KO.
    /// </summary>
    bool? KoEcho => GetValue<bool>("KO.echo");

    /// <summary>
    /// Volume offset (negative for softer).
    /// </summary>
    int? Volume => GetValue<int>("volume");

    /// <summary>
    /// Variables with this index and above will not have their values reset to 0 between rounds or matches.
    /// There are 60 int variables, indexed from 0 to 59.
    /// If omitted, then it defaults to 60 and 40 for integer and float variables respectively, meaning that none are persistent, i.e. all are reset.
    /// If you want your variables to persist between matches, you need to override state 5900 from common1.cns.
    /// </summary>
    int? IntPersistIndex => GetValue<int>("IntPersistIndex");

    /// <summary>
    /// Variables with this index and above will not have their values reset to 0 between rounds or matches.
    /// There are 40 float variables, indexed from 0 to 39.
    /// If omitted, then it defaults to 60 and 40 for integer and float variables respectively, meaning that none are persistent, i.e. all are reset.
    /// If you want your variables to persist between matches, you need to override state 5900 from common1.cns.
    /// </summary>
    int? FloatPersistIndex => GetValue<int>("FloatPersistIndex");
}

public interface ICharacterConstantsSize : IManagerSection
{
    /// <summary>
    /// Horizontal scaling factor.
    /// </summary>
    float? ScaleX => GetValue<float>("xscale");

    /// <summary>
    /// Vertical scaling factor.
    /// </summary>
    float? ScaleY => GetValue<float>("yscale");

    /// <summary>
    /// Player width (back, ground).
    /// </summary>
    int? GroundBack => GetValue<int>("ground.back");

    /// <summary>
    /// Player width (front, ground).
    /// </summary>
    int? GroundFront => GetValue<int>("ground.front");

    /// <summary>
    /// Player width (back, air).
    /// </summary>
    int? AirBack => GetValue<int>("air.back");

    /// <summary>
    /// Player width (front, air).
    /// </summary>
    int? AirFront => GetValue<int>("air.front");

    /// <summary>
    /// Height of player (for opponent to jump over).
    /// </summary>
    int? Height => GetValue<int>("height");

    /// <summary>
    /// Default attack distance.
    /// </summary>
    int? AttackDistance => GetValue<int>("attack.dist");

    /// <summary>
    /// Default attack distance for projectiles.
    /// </summary>
    int? ProjectileAttackDistance => GetValue<int>("proj.attack.dist");

    /// <summary>
    /// Set to true to scale projectiles too.
    /// </summary>
    bool? ProjectileDoScale => GetValue<bool>("proj.doscale");

    /// <summary>
    /// Approximate position of head.
    /// </summary>
    IVectorEntry? HeadPosition => GetValue<IVectorEntry>("head.pos");

    /// <summary>
    /// Approximate position of midsection.
    /// </summary>
    IVectorEntry? MidSectionPosition => GetValue<IVectorEntry>("mid.pos");

    /// <summary>
    /// Number of pixels to vertically offset the shadow.
    /// </summary>
    int? ShadowOffset => GetValue<int>("shadowoffset");

    /// <summary>
    /// Player drawing offset in pixels (x, y). Recommended 0,0.
    /// </summary>
    IVectorEntry? DrawingOffset => GetValue<IVectorEntry>("draw.offset");
}

public interface ICharacterConstantsVelocity : IManagerSection
{
    /// <summary>
    /// Walk.
    /// </summary>
    IVelocityEntry? Walk => GetValue<IVelocityEntry>("walk");

    /// <summary>
    /// Run.
    /// </summary>
    IVelocityEntry? Run => GetValue<IVelocityEntry>("run");

    /// <summary>
    /// Jump.
    /// </summary>
    IVelocityEntry? Jump => GetValue<IVelocityEntry>("jump");

    /// <summary>
    /// Running jump.
    /// </summary>
    IVelocityEntry? RunJump => GetValue<IVelocityEntry>("runjump");

    /// <summary>
    /// Air jump.
    /// </summary>
    IVelocityEntry? AirJump => GetValue<IVelocityEntry>("airjump");

    /// <summary>
    /// Velocity for ground recovery state (x, y).
    /// </summary>
    IVectorEntry? GroundRecover => GetValue<IVectorEntry>("air.gethit.groundrecover");

    /// <summary>
    /// Extra (x, y)-velocity for holding direction during air recovery.
    /// </summary>
    IVelocityEntry? AirRecover => GetValue<IVelocityEntry>("air.gethit.airrecover");

    /// <summary>
    /// Multiplier for air recovery velocity (x, y).
    /// </summary>
    IVectorEntry? AirRecoveryMultiplier => GetValue<IVectorEntry>("air.gethit.airrecover.mul");

    /// <summary>
    /// Velocity offset for air recovery (x, y).
    /// </summary>
    IVectorEntry? AirRecoveryVelocityOffset => GetValue<IVectorEntry>("air.gethit.airrecover.add");
}

public interface ICharacterConstantsMovement : IManagerSection
{
    /// <summary>
    /// Number of air jumps allowed (opt) (default = 1).
    /// </summary>
    int? AirJumpNumber => GetValue<int>("airjump.num");

    /// <summary>
    /// Minimum distance from ground before you can air jump (opt) (default = 140).
    /// </summary>
    int? AirJumpHeight => GetValue<int>("airjump.height");

    /// <summary>
    /// Vertical acceleration.
    /// </summary>
    float? AccelY => GetValue<float>("yaccel");

    /// <summary>
    /// Friction coefficient when standing.
    /// </summary>
    float? StandFriction => GetValue<float>("stand.friction");

    /// <summary>
    /// Friction coefficient when crouching.
    /// </summary>
    float? CrouchFriction => GetValue<float>("crouch.friction");

    /// <summary>
    /// If player's speed drops below this threshold while standing, stop his movement.
    /// </summary>
    float? StandFrictionThreshold => GetValue<float>("stand.friction.threshold");
        
    /// <summary>
    /// If player's speed drops below this threshold while crouching, stop his movement.
    /// </summary>
    float? CrouchFrictionThreshold => GetValue<float>("crouch.friction.threshold");

    /// <summary>
    /// Y-position at which a falling player is considered to hit the ground.
    /// </summary>
    int? GroundLevel => GetValue<int>("air.gethit.groundlevel");

    /// <summary>
    /// Y-position below which falling player can use the recovery command.
    /// </summary>
    float? GroundRecoverThreshold => GetValue<float>("air.gethit.groundrecover.ground.threshold");

    /// <summary>
    /// Y-position at which player in the ground recovery state touches the ground.
    /// </summary>
    int? GroundRecoverGroundLevel => GetValue<int>("air.gethit.groundrecover.groundlevel");

    /// <summary>
    /// Y-velocity above which player may use the air recovery command.
    /// </summary>
    float? AirRecoverThreshold => GetValue<float>("air.gethit.airrecover.threshold");

    /// <summary>
    /// Vertical acceleration for player in the air recovery state.
    /// </summary>
    float? AirRecoverAccelY => GetValue<float>("air.gethit.airrecover.yaccel");

    /// <summary>
    /// Y-position at which player in the tripped state touches the ground.
    /// </summary>
    int? TripGroundLevel => GetValue<int>("air.gethit.trip.groundlevel");

    /// <summary>
    /// Offset for player bouncing off the ground (x, y).
    /// </summary>
    IVectorEntry? DownBounceOffset => GetValue<IVectorEntry>("down.bounce.offset");

    /// <summary>
    /// Vertical acceleration for player bouncing off the ground.
    /// </summary>
    float? DownBounceAccelY => GetValue<float>("down.bounce.yaccel");

    /// <summary>
    /// Y-position at which player bouncing off the ground touches the ground again.
    /// </summary>
    int? DownBounceGroundLevel => GetValue<int>("down.bounce.groundlevel");

    /// <summary>
    /// If the player's speed drops below this threshold while lying down, stop his movement.
    /// </summary>
    float? DownFrictionThreshold => GetValue<float>("down.friction.threshold");
}

public interface ICharacterConstantsQuotes : IManagerSection
{
    /// <summary>
    /// The default language victory quotes should be implemented in English.
    /// </summary>
    IEnumerable<string> Victories => GetValues<string>("victory");
}