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
3/4 | Engines | Engine represent evrything what was read from specified root directory using [IEngineProvider](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Engines/IEngineProvider.cs) | [IEngineProvider](https://github.com/TheNegumProject/Negum.Core/blob/main/Negum.Core/Engines/IEngineProvider.cs)

### 1.2. Features

</br>

## 2. How To Use

### 2.1. Installation (NuGet)
Easiest wat to install Negum.Core library is to do it via NuGet like so:
> dotnet add package Negum.Core

Or check it directly [Here](https://www.nuget.org/packages/Negum.Core/)

### 2.2. Code

</br>

## 3. Default Usage
Default usage of Negum.Core can be found in [Negum.Unity](https://github.com/TheNegumProject/Negum.Unity) </br>
It should not have any external dependencies except .NET libraries.

</br>

## 4. License
[Click Me](https://github.com/TheNegumProject/Negum.Core/blob/main/LICENSE)
