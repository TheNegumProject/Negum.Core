namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Video section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationVideoSection : INegumConfigurationSection
    {
        public const string RenderModeKey = "RenderMode";
        public const string SafeModeKey = "SafeMode";
        public const string DepthKey = "Depth";
        public const string VRetraceKey = "VRetrace";
        public const string FullScreenKey = "FullScreen";
        public const string ResizableKey = "Resizable";
        public const string KeepAspectKey = "KeepAspect";
        public const string BlitModeKey = "BlitMode";
        public const string StageFitKey = "StageFit";
        public const string SystemFitKey = "SystemFit";

        /// <summary>
        /// Screen rendering mode.
        /// </summary>
        string RenderMode
        {
            get => this.GetOrDefault(RenderModeKey, "OpenGL");
            set => this.SetNewValue(RenderModeKey, value);
        }

        /// <summary>
        /// Set to true to enable "safe" mode for older graphics cards.
        /// </summary>
        bool SafeMode
        {
            get => this.GetOrDefault(SafeModeKey, false);
            set => this.SetNewValue(SafeModeKey, value);
        }

        /// <summary>
        /// This is the color depth at which to run engine.
        /// </summary>
        int Depth
        {
            get => this.GetOrDefault(DepthKey, 32);
            set => this.SetNewValue(DepthKey, value);
        }

        /// <summary>
        /// Set to true to enable vertical retrace synchronization.
        /// </summary>
        bool VRetrace
        {
            get => this.GetOrDefault(VRetraceKey, false);
            set => this.SetNewValue(VRetraceKey, value);
        }

        /// <summary>
        /// Set to true to start in fullscreen mode, 0 for windowed.
        /// This enables exclusive fullscreen, which may give better performance than windowed mode.
        /// </summary>
        bool FullScreen
        {
            get => this.GetOrDefault(FullScreenKey, false);
            set => this.SetNewValue(FullScreenKey, value);
        }

        /// <summary>
        /// Set to true to make the window resizable when in windowed mode.
        /// </summary>
        bool Resizable
        {
            get => this.GetOrDefault(ResizableKey, true);
            set => this.SetNewValue(ResizableKey, value);
        }

        /// <summary>
        /// Set to false to stretch the video to fit the whole window.
        /// Set to true to keep a fixed aspect ratio.
        /// </summary>
        bool KeepAspect
        {
            get => this.GetOrDefault(KeepAspectKey, true);
            set => this.SetNewValue(KeepAspectKey, value);
        }

        /// <summary>
        /// Drawing mode.
        /// Choose from Normal (fast) and PageFlip (less image "tearing").
        /// </summary>
        string BlitMode
        {
            get => this.GetOrDefault(BlitModeKey, "Normal");
            set => this.SetNewValue(BlitModeKey, value);
        }

        /// <summary>
        /// Stage fit mode.
        /// 0 - stage drawn to width of screen (may crop stages with tall aspect)
        /// 1 - stage shrunk to fit into screen
        /// </summary>
        int StageFit
        {
            get => this.GetOrDefault(StageFitKey, 1);
            set => this.SetNewValue(StageFitKey, value);
        }

        /// <summary>
        /// System fit mode.
        /// 0 - system drawn to width of screen (may crop motifs with tall aspect)
        /// 1 - system shrunk to fit into screen
        /// </summary>
        int SystemFit
        {
            get => this.GetOrDefault(SystemFitKey, 1);
            set => this.SetNewValue(SystemFitKey, value);
        }
    }
}