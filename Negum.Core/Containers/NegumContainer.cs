using System;
using System.Collections.Generic;
using Negum.Core.Cleaners;
using Negum.Core.Configurations;
using Negum.Core.Managers;
using Negum.Core.Parsers;
using Negum.Core.Readers;
using Negum.Core.Scrappers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Containers
{
    /// <summary>
    /// Container which is used throughout the Negum Engine.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public static class NegumContainer
    {
        /// <summary>
        /// DO NOT USE IT DIRECTLY !!!
        /// Instead, use NegumContainer.Register
        /// 
        /// Entry point for binding any desired IoC container; by default will use dummy container.
        /// </summary>
        public static Action<NegumObjectLifetime, Type, Type> Registerer { get; set; } =
            (lifetime, interfaceType, implementationType) =>
                NegumDummyContainer.Register(lifetime, interfaceType, implementationType);

        /// <summary>
        /// DO NOT USE IT DIRECTLY !!!
        /// Instead, use NegumContainer.Resolve
        /// 
        /// Entry point for binding any desired IoC container; by default will use dummy container.
        /// </summary>
        public static Func<Type, object> Resolver { get; set; } = type =>
            NegumDummyContainer.Resolve(type);

        /// <summary>
        /// Registers new type.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <typeparam name="TClass">Implementation type.</typeparam>
        public static void Register<TInterface, TClass>(NegumObjectLifetime lifetime = NegumObjectLifetime.Transient)
            where TClass : class, TInterface =>
            Registerer(lifetime, typeof(TInterface), typeof(TClass));

        /// <summary>
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <returns>Resolved interface type or null if no found.</returns>
        public static TInterface Resolve<TInterface>() =>
            (TInterface) Resolver(typeof(TInterface));

        /// <summary>
        /// Registers known types to container.
        ///
        /// REMEMBER:
        /// Call it at least once before using the engine.
        /// </summary>
        public static void RegisterKnownTypes()
        {
            // Readers
            Register<IConfigurationReader, ConfigurationReader>(NegumObjectLifetime.Singleton);

            // Cleaners
            Register<IConfigurationCleaner, ConfigurationCleaner>(NegumObjectLifetime.Singleton);

            // Parsers
            Register<IConfigurationParser, ConfigurationParser>(NegumObjectLifetime.Singleton);
            Register<INegumConfigurationParser, NegumConfigurationParser>(NegumObjectLifetime.Singleton);
            Register<IMotifConfigurationParser, MotifConfigurationParser>(NegumObjectLifetime.Singleton);

            // Configurations
            Register<IConfigurationSectionEntry, ConfigurationSectionEntry>();
            Register<IConfigurationSection, ConfigurationSection>();
            Register<IConfigurationDefinition, ConfigurationDefinition>();
            Register<INegumConfiguration, NegumConfiguration>();
            Register<IMotifConfiguration, MotifConfiguration>();

            // Scrapper Entries
            Register<IFileEntry, FileEntry>();
            Register<IEntryCollection<IFileEntry>, EntryCollection<IFileEntry>>();
            Register<IAudioEntry, AudioEntry>();
            Register<IKeysEntry, KeysEntry>();
            Register<ISpriteSoundEntry, SpriteSoundEntry>();
            Register<IAnimationEntry, AnimationEntry>();
            Register<IPlayerSelectionCursorEntry, PlayerSelectionCursorEntry>();
            Register<IPlayerSelectionEntry, PlayerSelectionEntry>();
            Register<IMovementEntry, MovementEntry>();
            Register<IImageEntry, ImageEntry>();
            Register<IPositionEntry, PositionEntry>();
            Register<IBoxEntry, BoxEntry>();
            Register<ITextEntry, TextEntry>();
            Register<IFontEntry, FontEntry>();
            Register<ICellSelectionEntry, CellSelectionEntry>();
            Register<IStageSelectionEntry, StageSelectionEntry>();
            Register<ISpriteEntry, SpriteEntry>();
            Register<ISoundEntry, SoundEntry>();
            Register<IPlayerSelectionTeamMenuEntry, PlayerSelectionTeamMenuEntry>();
            Register<IPlayerSelectionTeamMenuItemEntry, PlayerSelectionTeamMenuItemEntry>();
            Register<IPlayerSelectionTeamMenuValueEntry, PlayerSelectionTeamMenuValueEntry>();

            // Scrappers
            Register<IConfigurationScrapper, ConfigurationScrapper>();

            // Managers
            Register<INegumConfigurationManager, NegumConfigurationManager>();
            Register<IMotifConfigurationManager, MotifConfigurationManager>();

            // Negum Configuration Types
            Register<INegumConfigurationOptions, NegumConfigurationManagerSection>();
            Register<INegumConfigurationRules, NegumConfigurationManagerSection>();
            Register<INegumConfigurationConfig, NegumConfigurationManagerSection>();
            Register<INegumConfigurationDebug, NegumConfigurationManagerSection>();
            Register<INegumConfigurationVideo, NegumConfigurationManagerSection>();
            Register<INegumConfigurationSound, NegumConfigurationManagerSection>();
            Register<INegumConfigurationMisc, NegumConfigurationManagerSection>();
            Register<INegumConfigurationArcade, NegumConfigurationManagerSection>();
            Register<INegumConfigurationInput, NegumConfigurationManagerSection>();
            Register<INegumConfigurationKeys, NegumConfigurationManagerSection>();

            // Motif Configuration Types
            Register<IMotifConfigurationInfo, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationFiles, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationMusic, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationTitleInfo, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationTitleBgDef, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationInfobox, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationSelectInfo, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationSelectBgDef, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationVsScreen, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationVsBgDef, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationDemoMode, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationContinueScreen, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationGameOverScreen, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationVictoryScreen, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationWinScreen, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationDefaultEnding, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationEndCredits, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationSurvivalResultsScreen, MotifConfigurationManagerSection>();
            Register<IMotifConfigurationOptionInfo, MotifConfigurationManagerSection>();
        }
    }

    /// <summary>
    /// Dummy container used as a default solution for the engine.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    internal static class NegumDummyContainer
    {
        /// <summary>
        /// Contains all types registered for the application.
        /// 
        /// Parameters:
        /// Interface Type, Implementation Type
        /// </summary>
        private static IDictionary<Type, Type> Types { get; } = new Dictionary<Type, Type>();

        /// <summary>
        /// Contains already created instances. Dummy way to keep singletons.
        /// 
        /// Parameters:
        /// Interface Type, Implementation Type Instance
        /// 
        /// REMEMBER:
        /// When registering an instance in different IoC framework try to make sure it's registered as singleton.
        /// </summary>
        private static IDictionary<Type, object> Instances { get; } = new Dictionary<Type, object>();

        static NegumDummyContainer()
        {
        }

        public static object Resolve(Type interfaceType)
        {
            if (Instances.ContainsKey(interfaceType))
            {
                return Instances[interfaceType];
            }

            return Types.ContainsKey(interfaceType) ? Activator.CreateInstance(Types[interfaceType]) : null;
        }

        public static void Register(NegumObjectLifetime lifetime, Type interfaceType, Type implementationType)
        {
            if (lifetime == NegumObjectLifetime.Singleton)
            {
                if (Instances.ContainsKey(interfaceType))
                {
                    Instances.Remove(interfaceType);
                }

                Instances.Add(interfaceType, Activator.CreateInstance(implementationType));
            }
            else
            {
                if (Types.ContainsKey(interfaceType))
                {
                    Types.Remove(interfaceType);
                }

                Types.Add(interfaceType, implementationType);
            }
        }
    }
}