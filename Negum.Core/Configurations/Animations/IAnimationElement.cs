namespace Negum.Core.Configurations.Animations
{
    /// <summary>
    /// Represents a single animation frame defined in an AIR file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IAnimationElement
    {
        /// <summary>
        /// 1st number is the sprite's group number.
        /// </summary>
        int SpriteGroup { get; }

        /// <summary>
        /// 2nd number is the sprite's image number.
        /// </summary>
        int SpriteImage { get; }

        /// <summary>
        /// The 3rd and 4th numbers of the element are the X and Y offsets from this sprite's axis.
        /// If you want the sprite to appear 5 pixels forwards, put "5" for the 3rd number.
        /// </summary>
        int OffsetX { get; }

        /// <summary>
        /// The 3rd and 4th numbers of the element are the X and Y offsets from this sprite's axis.
        /// To make the sprite 15 pixels up, put "-15" for the 4th number, and so on.
        /// </summary>
        int OffsetY { get; }

        /// <summary>
        /// 5th number is the length of time to display the element before moving onto the next, measured in game-ticks.
        /// There are 60 game-ticks in one second at normal game speed.
        /// For the 5th number, you can specify "-1" if you want that element to be displayed indefinitely (or until you switch to a different action).
        /// If you choose to do this, do it only on the last element of the action.
        /// </summary>
        int DisplayTime { get; }

        /// <summary>
        /// If you want to flip the sprite horizontally and/or vertically, you will need to use the "flip" parameters:
        /// V - for vertical flip,
        /// H - for horizontal flip.
        /// These parameters will be 6th on the line.
        /// 
        /// Flipping the sprite around is especially useful for making throws.
        /// The opponent who is being thrown will temporarily get the player's animation data, and enter the "being thrown" animation action.
        /// You'll might have to flip the sprites around to make the "thrown" action look correct.
        /// </summary>
        string Flip { get; }
        
        /// <summary>
        /// For certain things such as hit sparks, you might like to use color addition to draw the sprite, making it look "transparent".
        /// You won't need to use this to make a character, so you don't have to worry about this if you choose not to.
        /// The parameters for color addition and subtraction are "A" and "S" respectively, and should go as the 7th on the line.
        ///
        /// If you wish to specify alpha values for color addition, use the parameter format "AS???D???",
        /// where ??? represents the values of the source and destination alpha respectively.
        /// Values range from 0 (low) to 256 (high).
        /// For example, "AS64D192" stands for "Add Source_64 to Dest_192".
        /// Also, "AS256D256" is equivalent to just "A". A shorthand for "AS256D128" is "A1".
        /// </summary>
        string Color { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class AnimationElement : IAnimationElement
    {
        public int SpriteGroup { get; internal set; }
        public int SpriteImage { get; internal set; }
        public int OffsetX { get; internal set; }
        public int OffsetY { get; internal set; }
        public int DisplayTime { get; internal set; }
        public string Flip { get; internal set; }
        public string Color { get; internal set; }
    }
}