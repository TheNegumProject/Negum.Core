namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Input section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationInputSection : INegumConfigurationSection
    {
        public const string P1UseKeyboardKey = "P1.UseKeyboard";
        public const string P2UseKeyboardKey = "P2.UseKeyboard";
        public const string P1JoystickKey = "P1.Joystick.type";
        public const string P2JoystickKey = "P2.Joystick.type";
        public const string AnyKeyUnpausesKey = "AnyKeyUnpauses";

        bool P1UseKeyboard
        {
            get => this.GetOrDefault(P1UseKeyboardKey, true);
            set => this.SetNewValue(P1UseKeyboardKey, value);
        }

        bool P2UseKeyboard
        {
            get => this.GetOrDefault(P2UseKeyboardKey, true);
            set => this.SetNewValue(P2UseKeyboardKey, value);
        }

        bool P1Joystick
        {
            get => this.GetOrDefault(P1JoystickKey, true);
            set => this.SetNewValue(P1JoystickKey, value);
        }

        bool P2Joystick
        {
            get => this.GetOrDefault(P2JoystickKey, true);
            set => this.SetNewValue(P2JoystickKey, value);
        }

        /// <summary>
        /// false - Only pause key will unpause
        /// true - Any key unpauses if there is no menu
        /// </summary>
        bool AnyKeyUnpauses
        {
            get => this.GetOrDefault(AnyKeyUnpausesKey, false);
            set => this.SetNewValue(AnyKeyUnpausesKey, value);
        }
    }
}