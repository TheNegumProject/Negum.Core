using Negum.Core.Configurations;

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
        protected override void InitializeConfigurationSection(IConfiguration configuration,
            IConfigurationSection section)
        {
            // TODO: Implement logic
        }
    }
}