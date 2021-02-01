namespace Negum.Core.Configurations.Selections
{
    /// <summary>
    /// Options section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationSelectionOptionsSection : INegumConfigurationSection
    {
        public const string ArcadeMaxMatchesKey = "arcade.maxmatches";
        public const string TeamMaxMatchesKey = "team.maxmatches";

        /// <summary>
        /// Here you set the maximum number of matches to fight before game ends in Arcade Mode.
        /// The first number is the number of matches against characters with order=1, followed by order=2 and order=3 respectively.
        /// For example, for 4,3,1 you will fight up to 4 randomly-picked characters who have order=1, followed by 3 with order=2 and 1 with order=3.
        /// Up to 30 entries allowed.
        /// </summary>
        string ArcadeMaxMatches
        {
            get => this.GetOrDefault(ArcadeMaxMatchesKey, "6,1,1,0,0,0,0,0,0,0");
            set => this.SetNewValue(ArcadeMaxMatchesKey, value);
        }

        /// <summary>
        /// Maximum number of matches to fight before game ends in Team Mode.
        /// Like arcade.maxmatches, but applies to Team Battle.
        /// </summary>
        string TeamMaxMatches
        {
            get => this.GetOrDefault(TeamMaxMatchesKey, "4,1,1,0,0,0,0,0,0,0");
            set => this.SetNewValue(TeamMaxMatchesKey, value);
        }
    }
}