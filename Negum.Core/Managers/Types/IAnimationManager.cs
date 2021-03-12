using System.Collections.Generic;
using Negum.Core.Readers;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Animations.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IAnimationManager : IManager
    {
        /// <summary>
        /// See: IAnimationSection
        /// </summary>
        IEnumerable<IAnimationDefinition> Animations =>
            this.GetSections<IAnimationDefinition>(AnimationReader.SectionName);
    }

    public interface IAnimationDefinition : IManagerSection
    {
        /// <summary>
        /// See: IAnimationSection.ActionNumber
        /// </summary>
        int ActionNumber { get; }

        /// <summary>
        /// See: IAnimationSectionEntry
        /// </summary>
        IEnumerable<IAnimationPart> Parts { get; }
    }

    public interface IAnimationPart
    {
        /// <summary>
        /// See: IAnimationSectionEntry.IsDefault
        /// </summary>
        bool IsDefault { get; }

        /// <summary>
        /// See: IAnimationSectionEntry.TypeId
        /// </summary>
        int TypeId { get; }

        /// <summary>
        /// See: IAnimationSectionEntry.Boxes
        /// </summary>
        IEnumerable<string> Boxes { get; }

        /// <summary>
        /// See: IAnimationSectionEntry.AnimationElements
        /// </summary>
        IEnumerable<IAnimationFrame> Frames { get; }
    }

    public interface IAnimationFrame
    {
        /// <summary>
        /// See: IAnimationElement.SpriteGroup
        /// </summary>
        int SpriteGroup { get; }

        /// <summary>
        /// See: IAnimationElement.SpriteImage
        /// </summary>
        int SpriteImage { get; }

        /// <summary>
        /// See: IAnimationElement.OffsetX
        /// </summary>
        int OffsetX { get; }

        /// <summary>
        /// See: IAnimationElement.OffsetY
        /// </summary>
        int OffsetY { get; }

        /// <summary>
        /// See: IAnimationElement.DisplayTime
        /// </summary>
        int DisplayTime { get; }

        /// <summary>
        /// See: IAnimationElement.Flip
        /// </summary>
        string Flip { get; }

        /// <summary>
        /// See: IAnimationElement.Color
        /// </summary>
        string Color { get; }
    }
}