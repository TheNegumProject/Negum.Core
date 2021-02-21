using System.Linq;
using Negum.Core.Configurations;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle specific configuration file by it's path with multiple subsections.
    /// Subsections are defined under the definition section which have a postfix of "-def".
    /// I.e. "OptionBGdef" and "OptionBG 1", etc.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationWithSubsectionReader : IConfigurationReader
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationWithSubsectionReader : ConfigurationReader, IConfigurationWithSubsectionReader
    {
        protected virtual bool IsSubsection(IConfigurationSection lastSection, IConfigurationSection section)
        {
            if (lastSection == null)
            {
                return false;
            }

            // COMMENT: -3 indicates "def" postfix
            var lastSectionNamePrefix = lastSection.Name.Substring(0, lastSection.Name.Length - 3);

            return section.Name.StartsWith(lastSectionNamePrefix);
        }

        protected override void InitializeConfiguration(IConfiguration configuration)
        {
            foreach (var section in this.Sections)
            {
                var lastSection = configuration.LastOrDefault();

                if (this.IsSubsection(lastSection, section))
                {
                    lastSection.AddSubsection(section);
                }
                else
                {
                    configuration.AddSection(section);
                }
            }
        }
    }
}