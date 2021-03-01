using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Character Constants file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterConstantsManager : IConstantsManager
    {
        ICharacterConstantsData Data => this.GetSection<ICharacterConstantsData>("Data");
        ICharacterConstantsSize Size => this.GetSection<ICharacterConstantsSize>("Size");
        ICharacterConstantsVelocity Velocity => this.GetSection<ICharacterConstantsVelocity>("Velocity");
        ICharacterConstantsMovement Movement => this.GetSection<ICharacterConstantsMovement>("Movement");
        ICharacterConstantsQuotes Quotes => this.GetSection<ICharacterConstantsQuotes>("Quotes");
    }

    public interface ICharacterConstantsData : IManagerSection
    {
        /// <summary>
        /// Amount of life to start with.
        /// </summary>
        int Life => this.GetValue<int>("life");

        /// <summary>
        /// Attack power (more is stronger).
        /// </summary>
        int Attack => this.GetValue<int>("attack");

        /// <summary>
        /// Defensive power (more is stronger).
        /// </summary>
        int Defence => this.GetValue<int>("defence");

        /// <summary>
        /// Percentage to increase defense everytime player is knocked down.
        /// </summary>
        int FallDefenceUp => this.GetValue<int>("fall.defence_up");

        /// <summary>
        /// Time which player lies down for, before getting up.
        /// </summary>
        int LieDownTime => this.GetValue<int>("liedown.time");

        /// <summary>
        /// Number of points for juggling.
        /// </summary>
        int AirJuggle => this.GetValue<int>("airjuggle");

        /// <summary>
        /// Default hit spark number for HitDefs.
        /// </summary>
        int SparkNo => this.GetValue<int>("sparkno");

        /// <summary>
        /// Default guard spark number.
        /// </summary>
        int GuardSparkNo => this.GetValue<int>("guard.sparkno");

        /// <summary>
        /// True to enable echo on KO.
        /// </summary>
        bool KoEcho => this.GetValue<bool>("KO.echo");

        /// <summary>
        /// Volume offset (negative for softer).
        /// </summary>
        int Volume => this.GetValue<int>("volume");

        /// <summary>
        /// Variables with this index and above will not have their values reset to 0 between rounds or matches.
        /// There are 60 int variables, indexed from 0 to 59.
        /// If omitted, then it defaults to 60 and 40 for integer and float variables respectively, meaning that none are persistent, i.e. all are reset.
        /// If you want your variables to persist between matches, you need to override state 5900 from common1.cns.
        /// </summary>
        int IntPersistIndex => this.GetValue<int>("IntPersistIndex");

        /// <summary>
        /// Variables with this index and above will not have their values reset to 0 between rounds or matches.
        /// There are 40 float variables, indexed from 0 to 39.
        /// If omitted, then it defaults to 60 and 40 for integer and float variables respectively, meaning that none are persistent, i.e. all are reset.
        /// If you want your variables to persist between matches, you need to override state 5900 from common1.cns.
        /// </summary>
        int FloatPersistIndex => this.GetValue<int>("FloatPersistIndex");
    }

    public interface ICharacterConstantsSize : IManagerSection
    {
        /// <summary>
        /// Horizontal scaling factor.
        /// </summary>
        float ScaleX => this.GetValue<float>("xscale");

        /// <summary>
        /// Vertical scaling factor.
        /// </summary>
        float ScaleY => this.GetValue<float>("yscale");

        /// <summary>
        /// Player width (back, ground).
        /// </summary>
        int GroundBack => this.GetValue<int>("ground.back");

        /// <summary>
        /// Player width (front, ground).
        /// </summary>
        int GroundFront => this.GetValue<int>("ground.front");

        /// <summary>
        /// Player width (back, air).
        /// </summary>
        int AirBack => this.GetValue<int>("air.back");

        /// <summary>
        /// Player width (front, air).
        /// </summary>
        int AirFront => this.GetValue<int>("air.front");

        /// <summary>
        /// Height of player (for opponent to jump over).
        /// </summary>
        int Height => this.GetValue<int>("height");

        /// <summary>
        /// Default attack distance.
        /// </summary>
        int AttackDistance => this.GetValue<int>("attack.dist");

        /// <summary>
        /// Default attack distance for projectiles.
        /// </summary>
        int ProjectileAttackDistance => this.GetValue<int>("proj.attack.dist");

        /// <summary>
        /// Set to true to scale projectiles too.
        /// </summary>
        bool ProjectileDoScale => this.GetValue<bool>("proj.doscale");

        /// <summary>
        /// Approximate position of head.
        /// </summary>
        IVectorEntry HeadPosition => this.GetValue<IVectorEntry>("head.pos");

        /// <summary>
        /// Approximate position of midsection.
        /// </summary>
        IVectorEntry MidSectionPosition => this.GetValue<IVectorEntry>("mid.pos");

        /// <summary>
        /// Number of pixels to vertically offset the shadow.
        /// </summary>
        int ShadowOffset => this.GetValue<int>("shadowoffset");

        /// <summary>
        /// Player drawing offset in pixels (x, y). Recommended 0,0.
        /// </summary>
        IVectorEntry DrawingOffset => this.GetValue<IVectorEntry>("draw.offset");
    }

    public interface ICharacterConstantsVelocity : IManagerSection
    {
        /// <summary>
        /// Walk.
        /// </summary>
        IMovementEntry Walk => this.GetValue<IMovementEntry>("walk");

        /// <summary>
        /// Run.
        /// </summary>
        IMovementEntry Run => this.GetValue<IMovementEntry>("run");

        /// <summary>
        /// Jump.
        /// </summary>
        IMovementEntry Jump => this.GetValue<IMovementEntry>("jump");

        /// <summary>
        /// Running jump.
        /// </summary>
        IMovementEntry RunJump => this.GetValue<IMovementEntry>("runjump");

        /// <summary>
        /// Air jump.
        /// </summary>
        IMovementEntry AirJump => this.GetValue<IMovementEntry>("airjump");

        /// <summary>
        /// Velocity for ground recovery state (x, y).
        /// </summary>
        IVectorEntry GroundRecover => this.GetValue<IVectorEntry>("air.gethit.groundrecover");

        /// <summary>
        /// Extra (x, y)-velocity for holding direction during air recovery.
        /// </summary>
        IMovementEntry AirRecover => this.GetValue<IMovementEntry>("air.gethit.airrecover");

        /// <summary>
        /// Multiplier for air recovery velocity (x, y).
        /// </summary>
        IVectorEntry AirRecoveryMultiplier => this.GetValue<IVectorEntry>("air.gethit.airrecover.mul");

        /// <summary>
        /// Velocity offset for air recovery (x, y).
        /// </summary>
        IVectorEntry AirRecoveryVelocityOffset => this.GetValue<IVectorEntry>("air.gethit.airrecover.add");
    }

    public interface ICharacterConstantsMovement : IManagerSection
    {
    }

    public interface ICharacterConstantsQuotes : IManagerSection
    {
    }
}