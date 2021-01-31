namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Rules section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationRulesSection : INegumConfigurationSection
    {
        public const string GameTypeKey = "GameType";
        public const string DefaultAttackLifeToPowerMulKey = "Default.Attack.LifeToPowerMul";
        public const string DefaultGetHitLifeToPowerMulKey = "Default.GetHit.LifeToPowerMul";
        public const string SuperTargetDefenceMulKey = "Super.TargetDefenceMul";

        /// <summary>
        /// Keep this set at VS. It's the only option supported for now...
        /// </summary>
        string GameType
        {
            get => this.GetOrDefault(GameTypeKey, "VS");
            set => this.SetNewValue(GameTypeKey, value);
        }

        /// <summary>
        /// This is the amount of power the attacker gets when an attack successfully hits the opponent.
        /// It's a multiplier of the damage done.
        /// For example, for a value of 3, a hit that does 10 damage will give 30 power.
        /// </summary>
        float DefaultAttackLifeToPowerMul
        {
            get => this.GetOrDefault(DefaultAttackLifeToPowerMulKey, .7f);
            set => this.SetNewValue(DefaultAttackLifeToPowerMulKey, value);
        }

        /// <summary>
        /// This is like the above, but it's for the person getting hit.
        /// These two multipliers can be overridden in the Hitdef controller in the
        /// CNS by using the "getpower" and "givepower" options.
        /// </summary>
        float DefaultGetHitLifeToPowerMul
        {
            get => this.GetOrDefault(DefaultGetHitLifeToPowerMulKey, .6f);
            set => this.SetNewValue(DefaultGetHitLifeToPowerMulKey, value);
        }

        /// <summary>
        /// This controls how much damage a super does when you combo into it.
        /// It's actually a multiplier for the defensive power of the opponent.
        /// A large number means the opponent takes less damage.
        /// Leave it at 1 if you want supers to do the normal amount of damage when comboed into.
        /// 
        /// Note 1: this increase in defence stays effective until the opponent gets up from the ground.
        /// Note 2: the program knows you've done a super when the "superpause" controller is executed.
        ///         That's the instance when this change becomes effective.
        /// </summary>
        float SuperTargetDefenceMul
        {
            get => this.GetOrDefault(SuperTargetDefenceMulKey, 1.5f);
            set => this.SetNewValue(SuperTargetDefenceMulKey, value);
        }
    }
}