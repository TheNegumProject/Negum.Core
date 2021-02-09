using System;
using System.Collections.Generic;
using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Stage configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageConfigurationManager : IConfigurationManager<IStageConfigurationManager>
    {
        IStageConfigurationInfo Info =>
            NegumContainer.Resolve<IStageConfigurationInfo>().Setup(this.Scrapper.GetSection("Info"));

        IStageConfigurationCamera Camera =>
            NegumContainer.Resolve<IStageConfigurationCamera>().Setup(this.Scrapper.GetSection("Camera"));

        IStageConfigurationPlayerInfo PlayerInfo =>
            NegumContainer.Resolve<IStageConfigurationPlayerInfo>().Setup(this.Scrapper.GetSection("PlayerInfo"));

        IStageConfigurationBound Bound =>
            NegumContainer.Resolve<IStageConfigurationBound>().Setup(this.Scrapper.GetSection("Bound"));

        IStageConfigurationStageInfo StageInfo =>
            NegumContainer.Resolve<IStageConfigurationStageInfo>().Setup(this.Scrapper.GetSection("StageInfo"));

        IStageConfigurationShadow Shadow =>
            NegumContainer.Resolve<IStageConfigurationShadow>().Setup(this.Scrapper.GetSection("Shadow"));

        IStageConfigurationReflection Reflection =>
            NegumContainer.Resolve<IStageConfigurationReflection>().Setup(this.Scrapper.GetSection("Reflection"));

        IStageConfigurationMusic Music =>
            NegumContainer.Resolve<IStageConfigurationMusic>().Setup(this.Scrapper.GetSection("Music"));

        IStageConfigurationBackgroundDef BackgroundDef =>
            NegumContainer.Resolve<IStageConfigurationBackgroundDef>().Setup(this.Scrapper.GetSection("BGdef"));

        IEnumerable<IStageConfigurationBackground> Backgrounds =>
            NegumContainer.Resolve<ISectionCollectionProvider>()
                .SetupMultiple<IStageConfigurationBackground>(this.Scrapper.GetSections("BG "));
    }

    public interface IStageConfigurationInfo : IConfigurationManagerSection<IStageConfigurationInfo>
    {
        string Name => Scrapper.GetString("name");
        string DisplayName => Scrapper.GetString("displayname");
        DateTime VersionDate => Scrapper.GetDate("versiondate");
        string Version => Scrapper.GetString("mugenversion");
        string Author => Scrapper.GetString("author");
    }

    public interface IStageConfigurationCamera : IConfigurationManagerSection<IStageConfigurationCamera>
    {
        /// <summary>
        /// Camera starting X position.
        /// </summary>
        int StartX => Scrapper.GetInt("startx");

        /// <summary>
        /// Camera starting Y position.
        /// </summary>
        int StartY => Scrapper.GetInt("starty");

        /// <summary>
        /// Left bound of Camera.
        /// </summary>
        int BoundLeft => Scrapper.GetInt("boundleft");

        /// <summary>
        /// Right bound of Camera.
        /// </summary>
        int BoundRight => Scrapper.GetInt("boundright");

        /// <summary>
        /// High bound of Camera.
        /// High is a negative number.
        /// Make it more negative if you want a Camera to be able to move higher.
        /// </summary>
        int BoundHigh => Scrapper.GetInt("boundhigh");

        /// <summary>
        /// Low bound of Camera.
        /// Low should usually be 0.
        /// </summary>
        int BoundLow => Scrapper.GetInt("boundlow");

        /// <summary>
        /// This is how much the camera will move vertically towards the highest player.
        /// Valid values are from 0 to 1.
        /// A value of 0 will mean the camera does not move up at all.
        /// A value of 1 will makes the camera follow the highest player.
        /// Typically .2 for normal-sized backgrounds.
        /// You may need to pull this value up for taller backgrounds.
        /// </summary>
        float VerticalFollow => Scrapper.GetFloat("verticalfollow");

        /// <summary>
        /// Minimum vertical distance the highest player has to be from the floor, before the camera starts to move up to follow him.
        /// For extremely tall stages, a floor tension of about 20-30 coupled with a vertical-follow of .8 allows the camera to follow the action.
        /// </summary>
        float FloorTension => Scrapper.GetFloat("floortension");

        /// <summary>
        /// Horizontal distance player is from edge before camera starts to move left or right.
        /// Typically 50 or 60.
        /// </summary>
        int Tension => Scrapper.GetInt("tension");

        /// <summary>
        /// Number of pixels beyond the top and bottom of the screen that may be drawn.
        /// Overdraw specifies the how much can be seen during an EnvShake.
        /// Overdraw pixels will also be used when the screen aspect is taller than the stage aspect.
        /// </summary>
        int OverdrawHigh => Scrapper.GetInt("overdrawhigh");

        /// <summary>
        /// Number of pixels beyond the top and bottom of the screen that may be drawn.
        /// Overdraw specifies the how much can be seen during an EnvShake.
        /// Overdraw pixels will also be used when the screen aspect is taller than the stage aspect.
        /// </summary>
        int OverdrawLow => Scrapper.GetInt("overdrawlow");

        /// <summary>
        /// Number of pixels into the top of the screen that may be cut from drawing when the screen aspect is shorter than the stage aspect.
        /// This parameter suggest a guideline, and the actual number of pixels cut depends on the difference in aspect.
        /// </summary>
        int CutHigh => Scrapper.GetInt("cuthigh");

        /// <summary>
        /// Number of pixels into the bottom of the screen that may be cut from drawing when the screen aspect is shorter than the stage aspect.
        /// This parameter suggest a guideline, and the actual number of pixels cut depends on the difference in aspect.
        /// </summary>
        int CutLow => Scrapper.GetInt("cutlow");
    }

    public interface IStageConfigurationPlayerInfo : IConfigurationManagerSection<IStageConfigurationPlayerInfo>
    {
        /// <summary>
        /// Player's 1 starting coordinate X.
        /// This is typically -70.
        /// </summary>
        int Player1StartX => Scrapper.GetInt("p1startx");

        /// <summary>
        /// Player's 1 starting coordinate Y.
        /// Should be 0.
        /// </summary>
        int Player1StartY => Scrapper.GetInt("p1starty");

        /// <summary>
        /// Direction player faces: 1 = right, -1 = left.
        /// </summary>
        int Player1Facing => Scrapper.GetInt("p1facing");

        /// <summary>
        /// Player's 2 starting coordinate X.
        /// This is typically 70.
        /// </summary>
        int Player2StartX => Scrapper.GetInt("p2startx");

        /// <summary>
        /// Player's 2 starting coordinate Y.
        /// Should be 0.
        /// </summary>
        int Player2StartY => Scrapper.GetInt("p2starty");

        /// <summary>
        /// Direction player faces: 1 = right, -1 = left.
        /// </summary>
        int Player2Facing => Scrapper.GetInt("p2facing");

        /// <summary>
        /// Left bound (x-movement).
        /// </summary>
        int LeftBound => Scrapper.GetInt("leftbound");

        /// <summary>
        /// Right bound.
        /// </summary>
        int RightBound => Scrapper.GetInt("rightbound");
    }

    public interface IStageConfigurationBound : IConfigurationManagerSection<IStageConfigurationBound>
    {
        /// <summary>
        /// Distance from left edge of screen that player can move to.
        /// Typically 15.
        /// </summary>
        int ScreenLeft => Scrapper.GetInt("screenleft");

        /// <summary>
        /// Distance from right edge of screen that player can move to.
        /// Typically 15.
        /// </summary>
        int ScreenRight => Scrapper.GetInt("screenright");
    }

    public interface IStageConfigurationStageInfo : IConfigurationManagerSection<IStageConfigurationStageInfo>
    {
        /// <summary>
        /// "Ground" level where players stand at, measured in pixels from the top of the screen.
        /// Adjust this value to move the ground level up/down in the screen.
        /// </summary>
        int OffsetZ => Scrapper.GetInt("zoffset");

        /// <summary>
        /// Leave this at 1.
        /// It makes the players face each other
        /// </summary>
        int AutoTurn => Scrapper.GetInt("autoturn");

        /// <summary>
        /// Set the following to 1 to have the background reset itself between rounds.
        /// </summary>
        int ResetBg => Scrapper.GetInt("resetBG");

        /// <summary>
        /// Width and height of the local coordinate space of the stage.
        /// </summary>
        IVectorEntry LocalCoord => Scrapper.GetVector("localcoord");

        /// <summary>
        /// Horizontal scaling factor for drawing.
        /// </summary>
        int ScaleX => Scrapper.GetInt("xscale");

        /// <summary>
        /// Vertical scaling factor for drawing.
        /// </summary>
        int ScaleY => Scrapper.GetInt("yscale");
    }

    public interface IStageConfigurationShadow : IConfigurationManagerSection<IStageConfigurationShadow>
    {
        /// <summary>
        /// This is the shadow darkening intensity.
        /// Valid values range from 0 (lightest) to 256 (darkest).
        /// Defaults to 128 if omitted.
        /// </summary>
        int Intensity => Scrapper.GetInt("intensity");

        /// <summary>
        /// This is the shadow color given in r,g,b.
        /// Valid values for each range from 0 (lightest) to 255 (darkest).
        /// Defaults to 0,0,0 if omitted.
        /// Intensity and color's effects add up to give the final shadow result.
        /// </summary>
        IVectorEntry Color => Scrapper.GetVector("color");

        /// <summary>
        /// This is the scale factor of the shadow.
        /// Use a big scale factor to make the shadow longer.
        /// You can use a NEGATIVE scale factor to make the shadow fall INTO the screen.
        /// Defaults to 0.4 if omitted.
        /// </summary>
        float ScaleY => Scrapper.GetFloat("yscale");

        /// <summary>
        /// This parameter lets you set the range over which the shadow is visible.
        /// The first value is the high level, and the second is the middle level.
        /// Both represent y-coordinates of the player.
        /// A shadow is invisible if the player is above the high level, and fully visible if below the middle level.
        /// The shadow is faded in between the two levels.
        /// This gives an effect of the shadow fading away as the player gets farther away from the ground.
        /// If omitted, defaults to no level effects (shadow is always fully visible).
        /// </summary>
        IVectorEntry FadeRange => Scrapper.GetVector("fade.range");
    }

    public interface IStageConfigurationReflection : IConfigurationManagerSection<IStageConfigurationReflection>
    {
        /// <summary>
        /// Intensity of reflection (from 0 to 256).
        /// Set to 0 to have no reflection.
        /// Defaults to 0.
        /// </summary>
        int Intensity => Scrapper.GetInt("intensity");
    }

    public interface IStageConfigurationMusic : IConfigurationManagerSection<IStageConfigurationMusic>
    {
    }

    public interface IStageConfigurationBackgroundDef : IConfigurationManagerSection<IStageConfigurationBackgroundDef>
    {
    }

    public interface IStageConfigurationBackground : IConfigurationManagerSection<IStageConfigurationBackground>
    {
    }
}