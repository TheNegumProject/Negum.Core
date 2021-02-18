using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Stage configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageNegumManager : INegumManager
    {
        IStageNegumInfo Info => this.GetSection<IStageNegumInfo>("Info");
        IStageNegumCamera Camera => this.GetSection<IStageNegumCamera>("Camera");
        IStageNegumPlayerInfo PlayerInfo => this.GetSection<IStageNegumPlayerInfo>("PlayerInfo");
        IStageNegumBound Bound => this.GetSection<IStageNegumBound>("Bound");
        IStageNegumStageInfo StageInfo => this.GetSection<IStageNegumStageInfo>("StageInfo");
        IStageNegumShadow Shadow => this.GetSection<IStageNegumShadow>("Shadow");
        IStageNegumReflection Reflection => this.GetSection<IStageNegumReflection>("Reflection");
        IStageNegumMusic Music => this.GetSection<IStageNegumMusic>("Music");
        IStageNegumBackgroundDef BackgroundDef => this.GetSection<IStageNegumBackgroundDef>("BGdef");

        IEnumerable<IStageNegumBackground> Backgrounds =>
            this.GetSections<IStageNegumBackground>("BG ");
    }

    public interface IStageNegumInfo : INegumManagerSection
    {
        string Name => Scrapper.GetString("name");
        string DisplayName => Scrapper.GetString("displayname");
        ITimeEntry VersionDate => Scrapper.GetTime("versiondate");
        string Version => Scrapper.GetString("mugenversion");
        string Author => Scrapper.GetString("author");
    }

    public interface IStageNegumCamera : INegumManagerSection
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

    public interface IStageNegumPlayerInfo : INegumManagerSection
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

    public interface IStageNegumBound : INegumManagerSection
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

    public interface IStageNegumStageInfo : INegumManagerSection
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

    public interface IStageNegumShadow : INegumManagerSection
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

    public interface IStageNegumReflection : INegumManagerSection
    {
        /// <summary>
        /// Intensity of reflection (from 0 to 256).
        /// Set to 0 to have no reflection.
        /// Defaults to 0.
        /// </summary>
        int Intensity => Scrapper.GetInt("intensity");
    }

    public interface IStageNegumMusic : INegumManagerSection
    {
        /// <summary>
        /// Put a filename for a MOD, MP3 or MIDI here, or just leave it blank if you don't want music.
        /// If an invalid filename is given, then no music will play.
        /// </summary>
        IFileEntry BackgroundMusicFile => Scrapper.GetFile("bgmusic");

        int BackgroundMusicLoopStart => Scrapper.GetInt("bgmloopstart");
        int BackgroundMusicLoopEnd => Scrapper.GetInt("bgmloopend");

        /// <summary>
        /// Adjust the volume. 100 is for 100%.
        /// </summary>
        int BackgroundMusicVolume => Scrapper.GetInt("bgmvolume");
    }

    public interface IStageNegumBackgroundDef : INegumManagerSection
    {
        /// <summary>
        /// Filename of sprite data.
        /// </summary>
        IFileEntry SpriteFile => Scrapper.GetFile("spr");

        /// <summary>
        /// Set to true if you want to clear the screen to magenta before drawing layer 0 (the default background).
        /// Good for spotting "holes" in your background.
        /// Remember to turn this off when you are done debugging the background, because it slows down performance.
        /// </summary>
        bool DebugBackground => Scrapper.GetBoolean("debugbg");
    }

    public interface IStageNegumBackground : INegumManagerSection
    {
        /// <summary>
        /// The background type goes here: for now, only NORMAL and PARALLAX.
        /// If this line is omitted, the type will be assumed to be normal.
        /// </summary>
        string Type => Scrapper.GetString("type");

        /// <summary>
        /// The sprite number to use for the background (from the SFF specified above).
        /// It's the group-number, followed by a comma, then the sprite-number.
        /// </summary>
        IVectorEntry SpriteNumber => Scrapper.GetVector("spriteno");

        /// <summary>
        /// This is the layer number, which determines where the sprite is drawn to.
        /// Valid values are 0 and 1.
        /// 0 for background (behind characters),
        /// 1 for foreground (in front).
        /// If this line is omitted, the default value of 0 will be assumed.
        /// </summary>
        int LayerNumber => Scrapper.GetInt("layerno");

        /// <summary>
        /// This is the starting location of the background in the format (x, y).
        /// If this line is omitted, the default value of 0,0 will be assumed.
        /// </summary>
        IVectorEntry StartPosition => Scrapper.GetVector("start");

        /// <summary>
        /// These are the number of pixels the background moves for every single unit of camera movement, in the format (x, y).
        /// For the main background (eg. the floor the players stand on) you'll want to use a delta of 1,1.
        /// Things farther away should have a smaller delta, like 0.5 for example.
        /// Things near the camera should have a larger delta.
        /// If this line is omitted, the default value of 1,1 will be assumed.
        /// </summary>
        IVectorEntry Delta => Scrapper.GetVector("delta");

        /// <summary>
        /// Here is the transparency setting of the background.
        /// Valid values are:
        ///     - "none" for normal drawing
        ///     - "add" for colour addition (like a spotlight effect)
        ///     - "add1" for colour addition with background dimmed to 50% brightness
        ///     - "addalpha" for colour addition with control over alpha values (you need an "alpha" parameter if you use this)
        ///     - "sub" for colour subtraction (like a shadow effect)
        /// If this line is omitted, it's assumed that there will be no transparency.
        /// </summary>
        string Transparency => Scrapper.GetString("trans");

        /// <summary>
        /// Use this parameter only if "trans = addalpha".
        /// First value is the alpha of the source (sprite), and the second is the alpha of the destination (background).
        /// The values range from 0 to 256.
        /// </summary>
        IVectorEntry Alpha => Scrapper.GetVector("alpha");

        /// <summary>
        /// Mask means whether or not to draw colour zero of a sprite.
        /// If you turn masking off, the background will take less CPU power to draw, so remember to turn it off on sprites that don't use it.
        /// If this line is omitted, it's assumed that there will be no masking.
        /// </summary>
        int Mask => Scrapper.GetInt("mask");

        /// <summary>
        /// The format for tiling is (x, y).
        /// For each of them, the value is:
        ///     - 0 to use no tiling,
        ///     - 1 to tile,
        ///     - n where (n>1) to tile n times.
        /// If this line is omitted, it's assumed that there will be no tiling.
        /// </summary>
        IVectorEntry Tile => Scrapper.GetVector("tile");

        /// <summary>
        /// This is the x and y space between each tile, for tiled backgrounds.
        /// If omitted, default value is 0,0.
        /// </summary>
        IVectorEntry TileSpacing => Scrapper.GetVector("tilespacing");

        /// <summary>
        /// This defines the drawing space, or "window" of the background.
        /// It's given in the form (x1,y1, x2,y2) where (x1,y1)-(x2,y2) define a rectangular box.
        /// Make the window smaller if you only want to draw part of the background.
        /// You normally do not have to use this setting.
        /// Value values range from 0-319 for x, and 0-239 for y.
        /// The values are 0,0, 319,239 by default (full screen).
        /// </summary>
        IVectorEntry Window => Scrapper.GetVector("window");

        /// <summary>
        /// Similar to the delta parameter, this one affects the movement of the window.
        /// Defaults to 0,0.
        /// </summary>
        IVectorEntry WindowDelta => Scrapper.GetVector("windowdelta");
    }
}