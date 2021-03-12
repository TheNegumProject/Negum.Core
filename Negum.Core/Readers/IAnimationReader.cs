using Negum.Core.Configurations;
using Negum.Core.Configurations.Animations;

namespace Negum.Core.Readers
{
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
            var animationSection = new AnimationSection();

            this.ParseAnimationSectionData(section.Name, animationSection);
            this.ParseCollisions(section, animationSection);
            
            configuration.AddSection(animationSection);
        }

        protected virtual void ParseAnimationSectionData(string sectionName, AnimationSection animationSection)
        {
            // Technically anything else should be understand as an error.
            animationSection.Name = SectionName;
            
            var numberString = sectionName.Split(" ");
            var number = int.Parse(numberString[^1]);
            animationSection.ActionNumber = number;
        }

        protected virtual void ParseCollisions(IConfigurationSection section, AnimationSection animationSection)
        {
            AnimationSectionEntry animationEntry = null;
            
            foreach (var entry in section)
            {
                if (entry.Value.StartsWith("Clsn") && entry.Value.Contains(":"))
                {
                    if (animationEntry != null)
                    {
                        animationSection.Entries.Add(animationEntry);
                    }
                    
                    animationEntry = new AnimationSectionEntry();
                    this.ParseHeaderData(animationEntry, entry.Value);
                }
                else if (entry.Key.StartsWith("Clsn") && entry.Key.Contains("["))
                {
                    this.ParseBoxData(animationEntry, entry.Value);
                }
                else if (char.IsDigit(entry.Value[0]))
                {
                    if (animationEntry == null)
                    {
                        animationEntry = new AnimationSectionEntry();
                    }
                    
                    this.ParseAnimationData(animationEntry, entry.Value);
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

        protected virtual void ParseBoxData(AnimationSectionEntry animationEntry, string value) => 
            animationEntry.AddBox(value);

        protected virtual void ParseAnimationData(AnimationSectionEntry animationEntry, string value)
        {
            var parts = value.Replace(" ", "").Split(",");

            var animation = new AnimationElement
            {
                SpriteGroup = int.Parse(parts[0]),
                SpriteImage = int.Parse(parts[1]),
                OffsetX = int.Parse(parts[2]),
                OffsetY = int.Parse(parts[3]),
                DisplayTime = int.Parse(parts[4])
            };

            if (parts.Length > 5)
            {
                animation.Flip = parts[5];
            }

            if (parts.Length > 6)
            {
                animation.Color = parts[6];
            }

            animationEntry.AddAnimationElement(animation);
        }
    }
}