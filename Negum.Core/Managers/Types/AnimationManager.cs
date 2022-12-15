using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;
using Negum.Core.Configurations.Animations;
using Negum.Core.Containers;
using Negum.Core.Models.Math;
using Negum.Core.Readers;

namespace Negum.Core.Managers.Types;

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class AnimationManager : Manager, IAnimationManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) => new AnimationManagerSection(sectionName, configSection);
}

public class AnimationManagerSection :
    ManagerSection,
    IAnimationDefinition
{
    public int ActionNumber { get; }
    public IEnumerable<IAnimationPart> Parts { get; }

    public AnimationManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
        ActionNumber = ((IAnimationSection) Section).ActionNumber;

        Parts = ((IAnimationSection) Section)
            .Cast<IAnimationSectionEntry>()
            .Select(entry => new AnimationPart(entry))
            .ToList();
    }
}

public class AnimationPart : IAnimationPart
{
    /// <summary>
    /// Keep for the reference.
    /// </summary>
    protected IAnimationSectionEntry Entry { get; }

    public bool IsDefault { get; }
    public int TypeId { get; }
    public IEnumerable<IBox> Boxes { get; }
    public IEnumerable<IAnimationFrame> Frames { get; }

    public AnimationPart(IAnimationSectionEntry entry)
    {
        Entry = entry;

        IsDefault = Entry.IsDefault;
        TypeId = Entry.TypeId;

        var vectorReader = NegumContainer.Resolve<IStringVectorReader>();
        var boxReader = NegumContainer.Resolve<IBoxReader>();

        Boxes = Entry.Boxes
            .Select(boxData =>
            {
                var vector = vectorReader.ReadAsync(boxData).Result;
                var box = boxReader.ReadAsync(vector).Result;
                return box;
            })
            .ToList();

        Frames = Entry.AnimationElements
            .Select(frame => new AnimationFrame(frame))
            .ToList();
    }
}

public class AnimationFrame : IAnimationFrame
{
    /// <summary>
    /// Keep for the reference.
    /// </summary>
    private IAnimationElement? Frame { get; }

    public int? SpriteGroup { get; }
    public int? SpriteImage { get; }
    public int? OffsetX { get; }
    public int? OffsetY { get; }
    public int? DisplayTime { get; }
    public string? Flip { get; }
    public string? Color { get; }

    public AnimationFrame(IAnimationElement? frame)
    {
        Frame = frame;

        SpriteGroup = Frame?.SpriteGroup;
        SpriteImage = Frame?.SpriteImage;
        OffsetX = Frame?.OffsetX;
        OffsetY = Frame?.OffsetY;
        DisplayTime = Frame?.DisplayTime;
        Flip = Frame?.Flip;
        Color = Frame?.Color;
    }
}