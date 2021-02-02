namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// Title BG section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationTitleBgSection : INegumConfigurationSection
    {
        public const string TypeKey = "type";
        public const string SpriteNoKey = "spriteno";
        public const string StartKey = "start";
        public const string WidthKey = "width";
        public const string YScaleStartKey = "yscalestart";
        public const string YScaleDeltaKey = "yscaledelta";
        public const string TileKey = "tile";
        public const string VelocityKey = "velocity";
        public const string TransKey = "trans";
        public const string MaskKey = "mask";

        /// <summary>
        /// Available values: normal, parallax.
        /// </summary>
        string Type
        {
            get => this.GetOrDefault(TypeKey, "normal");
            set => this.SetNewValue(TypeKey, value);
        }

        string SpriteNo
        {
            get => this.GetOrDefault(SpriteNoKey, "0,0");
            set => this.SetNewValue(SpriteNoKey, value);
        }

        string Start
        {
            get => this.GetOrDefault(StartKey, "0,10");
            set => this.SetNewValue(StartKey, value);
        }

        string Width
        {
            get => this.GetOrDefault(WidthKey, "400,1200");
            set => this.SetNewValue(WidthKey, value);
        }

        int YScaleStart
        {
            get => this.GetOrDefault(YScaleStartKey, 100);
            set => this.SetNewValue(YScaleStartKey, value);
        }

        int YScaleDelta
        {
            get => this.GetOrDefault(YScaleDeltaKey, 1);
            set => this.SetNewValue(YScaleDeltaKey, value);
        }

        string Tile
        {
            get => this.GetOrDefault(TileKey, "0,0");
            set => this.SetNewValue(TileKey, value);
        }

        int Velocity
        {
            get => this.GetOrDefault(VelocityKey, -1);
            set => this.SetNewValue(VelocityKey, value);
        }

        /// <summary>
        /// Available values: add, sub.
        /// </summary>
        string Trans
        {
            get => this.GetOrDefault(TransKey, "add");
            set => this.SetNewValue(TransKey, value);
        }

        int Mask
        {
            get => this.GetOrDefault(MaskKey, 0);
            set => this.SetNewValue(MaskKey, value);
        }
    }
}