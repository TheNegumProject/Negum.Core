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
        /// 1 to enable echo on KO.
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
    }

    public interface ICharacterConstantsVelocity : IManagerSection
    {
    }

    public interface ICharacterConstantsMovement : IManagerSection
    {
    }

    public interface ICharacterConstantsQuotes : IManagerSection
    {
    }
}