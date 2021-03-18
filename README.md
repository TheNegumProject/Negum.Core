# Negum.Core

## 1. General Overview
Negum.Core is a library which provides key classes and interfaces for a 2D fighting game engine. <br/>
It allows you to read and parse characters, stages, fonts, etc.

### 1.1. Library structure
Negum.Core was build out of layers which communicate with each other.

Layer | Name | Description | File
------|------|-------------|------
X | Container | Used to create objects and store them in shared space. Can be customized to use 3rd party container. | [NegumContainer](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Containers/NegumContainer.cs)
1 | Configurations | Contains various configuration definitions describing files in directories by their types (AIR, SFF, DEF, ANIM, etc.). | [IConfiguration](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Configurations/IConfiguration.cs)
1 | Readers | Readers are generally used to read File or Stream into appropriate output configuration or other type. | [IReader](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Readers/IReader.cs)
2 | Managers | Managers are used to represent various file types and search through them to find values. | [IManager](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Managers/IManager.cs)
3 | Loaders | Loaders are used to load all entities (characters, stages, fonts, etc.) from specified directory or for specified Engine. | [ILoader](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Loaders/ILoader.cs)
3/4 | Engines | Engine represent everything what was read from specified root directory using [IEngineProvider](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Engines/IEngineProvider.cs) | [IEngineProvider](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Engines/IEngineProvider.cs)

### 1.2. Features
- [X] Read files with extensions: cfg, def, sff (v1, v2, v2.1), air, cns, cmd, snd, act
- [X] Read fields from files
- [X] Load all characters, stages, fonts, etc.
- [X] Load characters and stages only from configuration files
- [X] Load data from config directory
- [X] Generate single object with all data from directory - [IEngine](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Engines/IEngine.cs)
- [ ] Multiplayer support (client, server, packets)
- [ ] Up to 4 players offline
- [ ] Max number of players online (configurable)

</br>

## 2. How To Use

### 2.1. Installation (NuGet)
Easiest wat to install Negum.Core library is to do it via NuGet like so:
> dotnet add package Negum.Core

Or check it directly [Here](https://www.nuget.org/packages/Negum.Core/)

### 2.2. Code / Sample Usage
```csharp
using Negum.Core.Containers; // We want to initialize and use NegumContainer class
using Negum.Core.Engines; // Contains main IEngine and IEngineProvider interfaces

// ...

// This step is optional !!!
// You can override default binding for NegumContainer and assign it to 3rd party Container
NegumContainer.Registerer = (lifetime, interfaceType, implementationType) => { }; // Used for registering new type
NegumContainer.Resolver = (typeToResolve) => null; // Used for resolving type

// ...

// You MUST call it once before doing anything with Negum engine
NegumContainer.RegisterKnownTypes();

// ...

// Take main provider which is used to build IEngine object
IEngineProvider engineProvider = NegumContainer.Resolve<IEngineProvider>();

// Read data from root directory
// Root directory is a directory which contains: chars, data, font, stages, sound, etc.
// This initialization may be used multiple times for various directories
// Every time this method is used, new IEngine object will be returned
IEngine engine = await engineProvider.InitializeAsync("path_to_root_directory");

// ...

// As an example we can take a display name of the first character read from chars directory
string characterName = engine.Characters.FirstOrDefault().CharacterManager.Info.DisplayName;

// ...

```

</br>

## 3. Default Usage
Default usage of Negum.Core can be found in [Negum.Unity](https://github.com/TheNegumProject/Negum.Unity) </br>
It should not have any external dependencies except .NET libraries.

</br>

## 4. License
[Click Me](https://github.com/TheNegumProject/Negum.Core/blob/main/LICENSE)
