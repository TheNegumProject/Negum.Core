namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// Title BG Def section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationTitleBgDefSection : INegumConfigurationSection
    {
        public const string BgClearColorKey = "bgclearcolor";

        string BgClearColor
        {
            get => this.GetOrDefault(BgClearColorKey, "0,0,0");
            set => this.SetNewValue(BgClearColorKey, value);
        }
    }
}