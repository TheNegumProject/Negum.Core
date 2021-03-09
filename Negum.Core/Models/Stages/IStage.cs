using Negum.Core.Managers.Types;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Models.Stages
{
    /// <summary>
    /// Represents single Stage read from appropriate directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStage : IFileReadable
    {
        /// <summary>
        /// Manager used to operate on the current Stage file.
        /// </summary>
        IStageManager Manager { get; }

        /// <summary>
        /// Sprite file connected with the current Stage.
        /// </summary>
        ISprite Sprite { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Stage : FileReadable, IStage
    {
        public IStageManager Manager { get; internal set; }
        public ISprite Sprite { get; internal set; }
    }
}