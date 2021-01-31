namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Options section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationOptionsSection : INegumConfigurationSection
    {
        public const string DifficultyKey = "Difficulty";
        public const string LifeKey = "Life";
        public const string TimeKey = "Time";
        public const string GameSpeedKey = "GameSpeed";
        public const string Team1VS2LifeKey = "Team.1VS2Life";
        public const string TeamLoseInKOKey = "Team.LoseOnKO";
        public const string MotifKey = "motif";

        int Difficulty
        {
            get => this.GetOrDefault(DifficultyKey, 4);
            set => this.SetNewValue(DifficultyKey, value);
        }

        int Life
        {
            get => this.GetOrDefault(LifeKey, 100);
            set => this.SetNewValue(LifeKey, value);
        }

        int Time
        {
            get => this.GetOrDefault(TimeKey, 99);
            set => this.SetNewValue(TimeKey, value);
        }

        int GameSpeed
        {
            get => this.GetOrDefault(GameSpeedKey, 0);
            set => this.SetNewValue(GameSpeedKey, value);
        }

        int Team1VS2Life
        {
            get => this.GetOrDefault(Team1VS2LifeKey, 150);
            set => this.SetNewValue(Team1VS2LifeKey, value);
        }

        bool TeamLoseInKO
        {
            get => this.GetOrDefault(TeamLoseInKOKey, false);
            set => this.SetNewValue(TeamLoseInKOKey, value);
        }

        /// <summary>
        /// Set the motif to use.
        /// Motifs are themes that define the look and feel of engine.
        /// This is not accessible in options screen.
        /// 
        /// Note: If you install a motif that overwrites system files (not recommended)
        /// you may need to set the motif line to use data/system.def instead.
        /// motif = data/system.def  - Use this line if using a motif that overwrites system files.
        /// </summary>
        string Motif
        {
            get => this.GetOrDefault(MotifKey, "data/system.def");
            set => this.SetNewValue(MotifKey, value);
        }
    }
}