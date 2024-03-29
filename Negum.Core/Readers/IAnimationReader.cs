using Negum.Core.Configurations;
using Negum.Core.Configurations.Animations;
using Negum.Core.Containers;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is designed to handle AIR aka Animation files.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IAnimationReader : IConfigurationReader
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class AnimationReader : ConfigurationReader, IAnimationReader
{
    public const string SectionName = "Begin Action";

    protected override void InitializeConfigurationSection(IConfiguration configuration,
        IConfigurationSection section)
    {
        if (!section.Name.ToLower().StartsWith(SectionName.ToLower()))
        {
            return;
        }

        var animationSection = new AnimationSection();

        ParseAnimationSectionData(section.Name, animationSection);
        ParseCollisions(section, animationSection);

        configuration.AddSection(animationSection);
    }

    protected virtual void ParseAnimationSectionData(string sectionName, AnimationSection animationSection)
    {
        // Technically anything else should be understand as an error.
        animationSection.Name = SectionName;

        var numberString = sectionName.Split(" ");
        var number = int.Parse(numberString[^1]); // We want to make sure that it is a valid number
        animationSection.ActionNumber = number;
    }

    protected virtual void ParseCollisions(IConfigurationSection section, AnimationSection animationSection)
    {
        AnimationSectionEntry? animationEntry = null;

        foreach (var entry in section)
        {
            if (entry.Value is not null && entry.Value.StartsWith("Clsn") && entry.Value.Contains(":"))
            {
                if (animationEntry != null)
                {
                    animationSection.Entries.Add(animationEntry);
                }

                animationEntry = new AnimationSectionEntry();
                ParseHeaderData(animationEntry, entry.Value);
            }
            else if (entry.Key.StartsWith("Clsn") && entry.Key.Contains("["))
            {
                ParseBoxData(animationEntry, entry.Value);
            }
            else if (entry.Value is not null && char.IsDigit(entry.Value[0]))
            {
                animationEntry ??= new AnimationSectionEntry();
                ParseAnimationData(animationEntry, entry.Value);
            }
        }

        if (animationEntry != null)
        {
            animationSection.Entries.Add(animationEntry);
        }
    }

    protected virtual void ParseHeaderData(AnimationSectionEntry animationEntry, string value)
    {
        animationEntry.IsDefault = value.Contains("Default");
        animationEntry.TypeId = int.Parse(value.Substring(4, 1));
    }

    protected virtual void ParseBoxData(AnimationSectionEntry? animationEntry, string? value)
    {
        if (value is null)
        {
            return;
        }
            
        animationEntry?.AddBox(value);
    }

    protected virtual void ParseAnimationData(AnimationSectionEntry animationEntry, string value)
    {
        var reader = NegumContainer.Resolve<IStringVectorReader>();
        var vector = reader.ReadAsync(value).Result;

        var animation = new AnimationElement
        {
            SpriteGroup = int.Parse(vector[0]),
            SpriteImage = int.Parse(vector[1]),
            OffsetX = int.Parse(vector[2]),
            OffsetY = int.Parse(vector[3]),
            DisplayTime = int.Parse(vector[4])
        };

        if (vector.Length > 5)
        {
            animation.Flip = vector[5];
        }

        if (vector.Length > 6)
        {
            animation.Color = vector[6];
        }

        animationEntry.AddAnimationElement(animation);
    }
}