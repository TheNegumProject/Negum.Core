using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Exceptions;
using Negum.Core.Extensions;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Characters;
using Negum.Core.Readers;

namespace Negum.Core.Loaders;

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
        var characterDirectoriesNames = engine.Data?.SelectionManager?.Characters.Characters
            .Select(character => character.Name)
            .Distinct()
            .ToList();

        var characterDirectories = GetDirectory(engine, "chars")
            .GetDirectories()
            .Where(dir => characterDirectoriesNames?.Contains(dir.Name) ?? false)
            .ToList();

        return await LoadMultipleAsync(characterDirectories, GetCharacterAsync);
    }

    protected virtual async Task<ICharacter> GetCharacterAsync(DirectoryInfo dir)
    {
        var characterDefFile = dir
            .GetFiles()
            .FirstOrDefault(file => file.Name.Equals(dir.Name + ".def") && file.Extension.Equals(".def"));

        if (characterDefFile == null)
        {
            throw new ArgumentException($"Missing DEF file in: \"{dir.FullName}\" with name: \"{dir.Name}.def\"");
        }

        var character = new Character
        {
            File = characterDefFile,
            Directory = dir
        };

        var reader = NegumContainer.Resolve<IFilePathReader>();

        character.CharacterManager = await ReadManagerAsync<ICharacterManager>(characterDefFile, characterDefFile.Name);
        character.CommandsManager = await ReadManagerAsync<ICharacterCommandsManager>(characterDefFile, character.CharacterManager?.Files.CommandFile);
        character.ConstantsManager = await ReadManagerAsync<ICharacterConstantsManager>(characterDefFile, character.CharacterManager?.Files.ConstantsFile);
        character.StatesManager = await ReadManagerAsync<ICharacterConstantsManager>(characterDefFile, character.CharacterManager?.Files.StatesFile);
        character.CommonStatesManager = await ReadCommonStatesAsync(characterDefFile, character.CharacterManager?.Files.CommonStatesFile);
        character.Sprite = await reader.GetSpriteAsync(characterDefFile.GetDirectoryNameOrThrow(), character.CharacterManager?.Files.SpriteFiles);
        character.AnimationManager = await FindManagerAsync<IAnimationManager>(characterDefFile.GetDirectoryNameOrThrow(), character.CharacterManager?.Files.AnimationFile);
        character.Sound = await reader.GetSoundAsync(characterDefFile.GetDirectoryNameOrThrow(), character.CharacterManager?.Files.SoundFile);
        character.AiHints = ReadAiHints(characterDefFile.GetDirectoryNameOrThrow(), character.CharacterManager?.Files.AiHintsDataFile);
        character.Intro = await ReadStoryboardAsync(characterDefFile.FullName, character.CharacterManager?.Arcade.IntroStoryboardFile);
        character.Ending = await ReadStoryboardAsync(characterDefFile.FullName, character.CharacterManager?.Arcade.EndingStoryboardFile);
            
        return character;
    }

    protected virtual ICharacterAiHints ReadAiHints(string dirName, string? dataFile)
    {
        if (string.IsNullOrWhiteSpace(dataFile))
        {
            throw new NegumException($"Cannot read ai hints in directory: {dirName}");
        }
            
        var aiHints = new CharacterAiHints
        {
            File = new FileInfo(Path.Combine(dirName, dataFile))
        };

        return aiHints;
    }

    protected virtual async Task<ICharacterConstantsManager?> ReadCommonStatesAsync(FileInfo characterDefFile, string? path)
    {
        if (path is null)
        {
            return null;
        }
        
        var fullPath = Path.Combine(characterDefFile.GetDirectoryNameOrThrow(), path);

        if (File.Exists(fullPath))
        {
            return await ReadManagerAsync<ICharacterConstantsManager>(characterDefFile, path); 
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
            throw new NegumException($"Cannot read common states starting from: {fullPath}");
        }

        var commonFilePath = Path.Combine(parentDir.FullName, path);
        var commonFile = new FileInfo(commonFilePath);
            
        return await ReadManagerAsync<ICharacterConstantsManager>(commonFile, path);
    }
}