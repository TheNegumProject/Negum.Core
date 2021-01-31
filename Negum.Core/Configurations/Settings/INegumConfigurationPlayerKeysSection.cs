namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Player Keys section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationPlayerKeysSection : INegumConfigurationSection
    {
        public const string JumpKey = "Jump";
        public const string CrouchKey = "Crouch";
        public const string LeftKey = "Left";
        public const string RightKey = "Right";
        public const string AKey = "A";
        public const string BKey = "B";
        public const string CKey = "C";
        public const string XKey = "X";
        public const string YKey = "Y";
        public const string ZKey = "Z";
        public const string StartKey = "Start";

        int Jump
        {
            get => this.GetOrDefault(JumpKey, 273);
            set => this.SetNewValue(JumpKey, value);
        }

        int Crouch
        {
            get => this.GetOrDefault(CrouchKey, 274);
            set => this.SetNewValue(CrouchKey, value);
        }

        int Left
        {
            get => this.GetOrDefault(LeftKey, 276);
            set => this.SetNewValue(LeftKey, value);
        }

        int Right
        {
            get => this.GetOrDefault(RightKey, 275);
            set => this.SetNewValue(RightKey, value);
        }

        int A
        {
            get => this.GetOrDefault(AKey, 44);
            set => this.SetNewValue(AKey, value);
        }

        int B
        {
            get => this.GetOrDefault(BKey, 46);
            set => this.SetNewValue(BKey, value);
        }

        int C
        {
            get => this.GetOrDefault(CKey, 47);
            set => this.SetNewValue(CKey, value);
        }

        int X
        {
            get => this.GetOrDefault(XKey, 108);
            set => this.SetNewValue(XKey, value);
        }

        int Y
        {
            get => this.GetOrDefault(YKey, 59);
            set => this.SetNewValue(YKey, value);
        }

        int Z
        {
            get => this.GetOrDefault(ZKey, 39);
            set => this.SetNewValue(ZKey, value);
        }

        int Start
        {
            get => this.GetOrDefault(StartKey, 13);
            set => this.SetNewValue(StartKey, value);
        }
    }
}