using System.IO;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Data;
using Negum.Core.Models.Sounds;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Models.Characters
{
    /// <summary>
    /// Represents single Character read from appropriate directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacter : IFileReadable
    {
        /// <summary>
        /// Directory from which the current character was loaded.
        /// </summary>
        DirectoryInfo Directory { get; }

        /// <summary>
        /// Manager which wraps main DEF file.
        /// </summary>
        ICharacterManager CharacterManager { get; }

        /// <summary>
        /// Manager which wraps character's commands.
        /// </summary>
        ICharacterCommandsManager CommandsManager { get; }

        /// <summary>
        /// Manager which wraps character's constants.
        /// </summary>
        ICharacterConstantsManager ConstantsManager { get; }

        /// <summary>
        /// Manager which wraps character's states.
        /// </summary>
        ICharacterConstantsManager StatesManager { get; }

        /// <summary>
        /// Manager which wraps common states.
        /// </summary>
        ICharacterConstantsManager CommonStatesManager { get; }

        /// <summary>
        /// Character's sprite.
        /// </summary>
        ISprite Sprite { get; }

        /// <summary>
        /// Manager which wraps character's animations.
        /// </summary>
        IAnimationManager AnimationManager { get; }

        /// <summary>
        /// Character's sound.
        /// </summary>
        ISound Sound { get; }

        /// <summary>
        /// Character's AI hints.
        /// </summary>
        ICharacterAiHints AiHints { get; }

        /// <summary>
        /// Manager which wraps character's storyboard intro.
        /// </summary>
        IStoryboard Intro { get; }

        /// <summary>
        /// Manager which wraps character's storyboard ending.
        /// </summary>
        IStoryboard Ending { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Character : FileReadable, ICharacter
    {
        public DirectoryInfo Directory { get; internal set; }
        public ICharacterManager CharacterManager { get; internal set; }
        public ICharacterCommandsManager CommandsManager { get; internal set; }
        public ICharacterConstantsManager ConstantsManager { get; internal set; }
        public ICharacterConstantsManager StatesManager { get; internal set; }
        public ICharacterConstantsManager CommonStatesManager { get; internal set; }
        public ISprite Sprite { get; internal set; }
        public IAnimationManager AnimationManager { get; internal set; }
        public ISound Sound { get; internal set; }
        public ICharacterAiHints AiHints { get; internal set; }
        public IStoryboard Intro { get; internal set; }
        public IStoryboard Ending { get; internal set; }
    }
}