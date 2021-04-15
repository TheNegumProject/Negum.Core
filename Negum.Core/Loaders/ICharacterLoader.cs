using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Engines;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Characters;

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
        public async Task<IEnumerable<ICharacter>> LoadAsync(IEngine engine)
        {
            var characterDirectoriesNames = engine.Data.SelectionManager.Characters.Characters
                .Select(character => character.Name)
                .Distinct()
                .ToList();

            var characterDirectories = this.GetDirectory(engine, "chars")
                .GetDirectories()
                .Where(dir => characterDirectoriesNames.Contains(dir.Name))
                .ToList();

            return await this.LoadMultipleAsync(characterDirectories, this.GetCharacterAsync);
        }

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
            character.Sprite = await this.GetSpriteAsync(characterDefFile.DirectoryName, character.CharacterManager.Files.SpriteFiles);
            character.AnimationManager = await this.FindManagerAsync<IAnimationManager>(characterDefFile.DirectoryName, character.CharacterManager.Files.AnimationFile);
            character.Sound = await this.GetSoundAsync(characterDefFile.DirectoryName, character.CharacterManager.Files.SoundFile);

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
                character.IntroManager = await this.ReadManagerAsync<ICharacterStoryboardSceneManager>(characterDefFile, introStoryboardFile);
                character.IntroSprite = await this.GetSpriteAsync(characterDefFile.DirectoryName, character.IntroManager.SceneDef.SpriteFile);
            }

            var endingStoryboardFile = character.CharacterManager.Arcade.EndingStoryboardFile;
            if (!string.IsNullOrWhiteSpace(endingStoryboardFile))
            {
                character.EndingManager = await this.ReadManagerAsync<ICharacterStoryboardSceneManager>(characterDefFile, endingStoryboardFile);
                character.EndingSprite = await this.GetSpriteAsync(characterDefFile.DirectoryName, character.EndingManager.SceneDef.SpriteFile);
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
    }
}