namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Sound section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationSoundSection : INegumConfigurationSection
    {
        public const string SoundKey = "Sound";
        public const string SampleRateKey = "SampleRate";
        public const string BufferSizeKey = "BufferSize";
        public const string StereoEffectsKey = "StereoEffects";
        public const string PanningWidthKey = "PanningWidth";
        public const string ReverseStereoKey = "ReverseStereo";
        public const string WavChannelsKey = "WavChannels";
        public const string MasterVolumeKey = "MasterVolume";
        public const string WavVolumeKey = "WavVolume";
        public const string BGMVolumeKey = "BGMVolume";
        public const string SFXResampleMethodKey = "SFXResampleMethod";
        public const string SFXResampleQualityKey = "SFXResampleQuality";
        public const string BGMResampleQualityKey = "BGMResampleQuality";

        /// <summary>
        /// Set the following to true to enable sound effects and music.
        /// Set to false to disable.
        /// </summary>
        bool Sound
        {
            get => this.GetOrDefault(SoundKey, true);
            set => this.SetNewValue(SoundKey, value);
        }

        /// <summary>
        /// Set the sample rate of the game audio.
        /// Higher rates produce better quality but require more system resources.
        /// Lower the rate if you are having problems with sound performance.
        /// Recommended values are 22050, 44100, or 48000.
        /// </summary>
        int SampleRate
        {
            get => this.GetOrDefault(SampleRateKey, 44100);
            set => this.SetNewValue(SampleRateKey, value);
        }

        /// <summary>
        /// Sets the audio buffer size.
        /// Larger buffers take less CPU but cause more latency when playing sounds.
        /// Smaller buffers give less latency but take more CPU.
        /// Also, if the buffer size is smaller than your system can handle, you may experience audio problems.
        ///
        /// The buffer size is set to 2^n samples, where n is the value you specify here.
        /// Optimal values for n are between 8 and 15.
        ///
        /// A good rule of thumb is to pick 10 for 22050 Hz audio, or 11 for 44100 Hz and 48000 Hz.
        /// Slower machines may require a larger buffer size.
        /// </summary>
        int BufferSize
        {
            get => this.GetOrDefault(BufferSizeKey, 11);
            set => this.SetNewValue(BufferSizeKey, value);
        }

        /// <summary>
        /// Set the following to true to enable stereo effects in-game.
        /// Set to false to disable.
        /// </summary>
        bool StereoEffects
        {
            get => this.GetOrDefault(StereoEffectsKey, true);
            set => this.SetNewValue(StereoEffectsKey, value);
        }

        /// <summary>
        /// This is the width of the sound panning field.
        /// If you Increase this number, the stereo effects will sound closer to the middle.
        /// Set to a smaller number to get more stereo separation on sound effects.
        /// Only valid if StereoEffects is set to true.
        /// </summary>
        int PanningWidth
        {
            get => this.GetOrDefault(PanningWidthKey, 240);
            set => this.SetNewValue(PanningWidthKey, value);
        }

        /// <summary>
        /// Set the following to 1 to reverse left and right channels on your sound card.
        /// </summary>
        bool ReverseStereo
        {
            get => this.GetOrDefault(ReverseStereoKey, false);
            set => this.SetNewValue(ReverseStereoKey, value);
        }

        /// <summary>
        /// Number of voice channels to use.
        /// </summary>
        int WavChannels
        {
            get => this.GetOrDefault(WavChannelsKey, 32);
            set => this.SetNewValue(WavChannelsKey, value);
        }

        /// <summary>
        /// This is the master volume for all sounds, in percent (0-100).
        /// </summary>
        int MasterVolume
        {
            get => this.GetOrDefault(MasterVolumeKey, 100);
            set => this.SetNewValue(MasterVolumeKey, value);
        }

        /// <summary>
        /// This is the volume for sound effects and voices, in percent (0-100).
        /// </summary>
        int WavVolume
        {
            get => this.GetOrDefault(WavVolumeKey, 80);
            set => this.SetNewValue(WavVolumeKey, value);
        }

        /// <summary>
        /// This is the master volume for music, (0-100).
        /// </summary>
        int BGMVolume
        {
            get => this.GetOrDefault(BGMVolumeKey, 75);
            set => this.SetNewValue(BGMVolumeKey, value);
        }

        /// <summary>
        /// Method used for rate conversion of sound effects.
        /// </summary>
        string SFXResampleMethod
        {
            get => this.GetOrDefault(SFXResampleMethodKey, "libresample");
            set => this.SetNewValue(SFXResampleMethodKey, value);
        }

        /// <summary>
        /// Quality parameter for resampling.
        /// Valid values are 0 (medium quality) or 1 (high quality).
        /// </summary>
        int SFXResampleQuality
        {
            get => this.GetOrDefault(SFXResampleQualityKey, 0);
            set => this.SetNewValue(SFXResampleQualityKey, value);
        }

        /// <summary>
        /// Quality parameter for BGM resampling.
        /// Valid values are 0 (medium quality) or 1 (high quality).
        /// </summary>
        int BGMResampleQuality
        {
            get => this.GetOrDefault(BGMResampleQualityKey, 0);
            set => this.SetNewValue(BGMResampleQualityKey, value);
        }
    }
}