using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Characters;
using Negum.Core.Models.Sprites;
using Negum.Core.Readers;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Loader used to get all currently available Characters.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICharacterLoader : IEngineModuleLoader<IEnumerable<ICharacter>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterLoader : AbstractLoader, ICharacterLoader
    {
        public async Task<IEnumerable<ICharacter>> LoadAsync(IEngine engine) =>
            await this.LoadMultipleAsync(this.GetDirectory(engine, "chars").GetDirectories(), this.GetCharacterAsync);

        protected virtual async Task<ICharacter> GetCharacterAsync(DirectoryInfo dir)
        {
            var characterDefFile = dir
                .GetFiles()
                .FirstOrDefault(file => file.Name.Equals(dir.Name + ".def") && file.Extension.Equals(".def"));

            if (characterDefFile == null)
            {
                throw new ArgumentException($"Missing DEF file in: \"{dir.FullName}\" with name: \"{ dir.Name }.def\"");
            }

            var character = new Character
            {
                File = characterDefFile,
                Directory = dir
            };

            character.CharacterManager = await this.ReadManagerAsync<ICharacterManager>(characterDefFile, characterDefFile.Name);
            character.CommandsManager = await this.ReadManagerAsync<ICharacterCommandsManager>(characterDefFile, character.CharacterManager.Files.CommandFile);
            character.ConstantsManager = await this.ReadManagerAsync<ICharacterConstantsManager>(characterDefFile, character.CharacterManager.Files.ConstantsFile);
            character.StatesManager = await this.ReadManagerAsync<ICharacterConstantsManager>(characterDefFile, character.CharacterManager.Files.StatesFile);
            character.CommonStatesManager = await this.ReadCommonStatesAsync(characterDefFile, character.CharacterManager.Files.CommonStatesFile);

            var spritePath = Path.Combine(characterDefFile.DirectoryName, character.CharacterManager.Files.SpriteFiles);
            character.Sprite = await NegumContainer.Resolve<ISpritePathReader>().ReadAsync(spritePath);

            var animationPath = Path.Combine(characterDefFile.DirectoryName, character.CharacterManager.Files.AnimationFile);
            var animationConfiguration = await NegumContainer.Resolve<IAnimationReader>().ReadAsync(animationPath);
            character.AnimationManager = (IAnimationManager) NegumContainer.Resolve<IAnimationManager>().UseConfiguration(animationConfiguration);

            var soundPath = Path.Combine(characterDefFile.DirectoryName, character.CharacterManager.Files.SoundFile);
            var soundReader = NegumContainer.Resolve<ISoundPathReader>();
            character.Sound = await soundReader.ReadAsync(soundPath);

            if (character.CharacterManager.Files.AiHintsDataFile != null)
            {
                character.AiHints = new CharacterAiHints
                {
                    File = new FileInfo(Path.Combine(characterDefFile.DirectoryName, character.CharacterManager.Files.AiHintsDataFile))
                };
            }

            var introStoryboardFile = character.CharacterManager.Arcade.IntroStoryboardFile;
            if (!string.IsNullOrWhiteSpace(introStoryboardFile))
            {
                var (introManager, introSprite) = await this.ReadCharacterStoryboardAsync(characterDefFile, introStoryboardFile);
                character.IntroManager = introManager;
                character.IntroSprite = introSprite;
            }

            var endingStoryboardFile = character.CharacterManager.Arcade.EndingStoryboardFile;
            if (!string.IsNullOrWhiteSpace(endingStoryboardFile))
            {
                var (endingManager, endingSprite) = await this.ReadCharacterStoryboardAsync(characterDefFile, endingStoryboardFile);
                character.EndingManager = endingManager;
                character.EndingSprite = endingSprite;
            }
            
            return character;
        }

        protected virtual async Task<ICharacterConstantsManager> ReadCommonStatesAsync(FileInfo characterDefFile, string path)
        {
            var fullPath = Path.Combine(characterDefFile.DirectoryName, path);

            if (File.Exists(fullPath))
            {
                return await this.ReadManagerAsync<ICharacterConstantsManager>(characterDefFile, path); 
            }

            const string dataDirName = "data";
            var parentDir = characterDefFile.Directory;

            while (parentDir != null)
            {
                var dataDir = parentDir
                    .GetDirectories()
                    .FirstOrDefault(childDir => childDir.Name.ToLower().Equals(dataDirName));

                if (dataDir == null)
                {
                    parentDir = parentDir.Parent;
                }
                else
                {
                    parentDir = dataDir;
                    break;
                }
            }

            if (parentDir == null)
            {
                return null;
            }

            var commonFilePath = Path.Combine(parentDir.FullName, path);
            var commonFile = new FileInfo(commonFilePath);
            
            return await this.ReadManagerAsync<ICharacterConstantsManager>(commonFile, path);
        }

        protected virtual async Task<(ICharacterStoryboardSceneManager, ISprite)> ReadCharacterStoryboardAsync(FileInfo file, string path)
        {
            var manager = await this.ReadManagerAsync<ICharacterStoryboardSceneManager>(file, path);
            var spritePath = Path.Combine(file.DirectoryName, manager.SceneDef.SpriteFile);
            var sprite = await NegumContainer.Resolve<ISpritePathReader>().ReadAsync(spritePath);

            return (manager, sprite);
        }
    }
}