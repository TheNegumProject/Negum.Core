namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Arcade section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationArcadeSection : INegumConfigurationSection
    {
        public const string AiRandomColorKey = "AI.RandomColor";
        public const string AiCheatKey = "AI.Cheat";
        public const string ArcadeAiRampStartKey = "arcade.AIramp.start";
        public const string ArcadeAiRampEndKey = "arcade.AIramp.end";
        public const string TeamAiRampStartKey = "team.AIramp.start";
        public const string TeamAiRampEndKey = "team.AIramp.end";
        public const string SurvivalAiRampStartKey = "survival.AIramp.start";
        public const string SurvivalAiRampEndKey = "survival.AIramp.end";

        /// <summary>
        /// Set to false for computer to choose color 1 if possible.
        /// Set to true for computer to randomly choose a color.
        /// </summary>
        bool AiRandomColor
        {
            get => this.GetOrDefault(AiRandomColorKey, true);
            set => this.SetNewValue(AiRandomColorKey, value);
        }

        /// <summary>
        /// This option allows the AI to input commands without having to actually press any keys (in effect, cheating).
        /// Set to true to enable, false to disable.
        /// </summary>
        bool AiCheat
        {
            get => this.GetOrDefault(AiCheatKey, true);
            set => this.SetNewValue(AiCheatKey, value);
        }

        /// <summary>
        /// Arcade Mode AI ramping.
        /// For both parameters below,
        /// the first number corresponds to the number of matches won,
        /// and the second number to the AI difficulty offset.
        /// The actual difficulty is the sum of the AI difficulty level
        /// (set in the options menu) and the value of the offset at a particular match.
        ///     AIramp.start = start_match, start_diff
        ///     AIramp.end   = end_match, end_diff
        /// The difficulty offset function is a constant value of start_diff from
        /// the first match until start_match matches have been won. From then the
        /// offset value increases linearly from start_diff to end_diff. After
        /// end_diff matches have been won, the offset value is end_diff.
        ///  e_d            /----------
        ///               /
        ///  s_d _______/
        ///     ^      ^     ^        ^
        ///   1st_m   s_m   e_m     last_m
        /// For example, if you have:
        ///     AIramp.start = 2,0
        ///     AIramp.end   = 4,2
        /// For 6 matches at level 4, the difficulty will be (by match):
        ///     4,4,4,5,6,6
        /// </summary>
        string ArcadeAiRampStart
        {
            get => this.GetOrDefault(ArcadeAiRampStartKey, "2,0");
            set => this.SetNewValue(ArcadeAiRampStartKey, value);
        }

        string ArcadeAiRampEnd
        {
            get => this.GetOrDefault(ArcadeAiRampEndKey, "4,2");
            set => this.SetNewValue(ArcadeAiRampEndKey, value);
        }

        /// <summary>
        /// Team Mode AI ramping.
        /// </summary>
        string TeamAiRampStart
        {
            get => this.GetOrDefault(TeamAiRampStartKey, "1,0");
            set => this.SetNewValue(TeamAiRampStartKey, value);
        }

        string TeamAiRampEnd
        {
            get => this.GetOrDefault(TeamAiRampEndKey, "3,2");
            set => this.SetNewValue(TeamAiRampEndKey, value);
        }

        /// <summary>
        /// Survival Mode AI ramping.
        /// </summary>
        string SurvivalAiRampStart
        {
            get => this.GetOrDefault(SurvivalAiRampStartKey, "0,-3");
            set => this.SetNewValue(SurvivalAiRampStartKey, value);
        }

        string SurvivalAiRampEnd
        {
            get => this.GetOrDefault(SurvivalAiRampEndKey, "16,4");
            set => this.SetNewValue(SurvivalAiRampEndKey, value);
        }
    }
}