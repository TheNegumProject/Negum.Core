using System;
using System.Collections.Generic;
using Negum.Core.Configurations;
using Negum.Core.Configurations.Settings;

namespace Negum.Core
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
        public static Action<Type, Type> Registerer { get; set; } = (interfaceType, implementationType) =>
            NegumDummyContainer.Register(interfaceType, implementationType);

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
        public static void Register<TInterface, TClass>() where TClass : class, TInterface =>
            Registerer(typeof(TInterface), typeof(TClass));

        /// <summary>
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns>Resolved interface type or null if no found.</returns>
        public static TInterface Resolve<TInterface>() =>
            (TInterface) Resolver(typeof(TInterface));

        /// <summary>
        /// Registers known types to container.
        ///
        /// REMEMBER:
        /// Call it at least once before calling NegumEngine.Instance
        /// </summary>
        public static void RegisterKnownTypes()
        {
            // Core interfaces
            Register<INegumEngine, NegumEngine>();
            Register<INegumConfiguration, NegumConfiguration>();

            // Configurations
            Register<INegumSettings, NegumSettings>();
            // Register<INegumSelection, >();
            // Register<INegumSystem, >();

            // Sections -> Settings
            Register<INegumConfigurationOptionsSection, NegumSettingsSection>();
            Register<INegumConfigurationRulesSection, NegumSettingsSection>();
            Register<INegumConfigurationConfigSection, NegumSettingsSection>();
            Register<INegumConfigurationDebugSection, NegumSettingsSection>();
            Register<INegumConfigurationVideoSection, NegumSettingsSection>();
            Register<INegumConfigurationSoundSection, NegumSettingsSection>();
            Register<INegumConfigurationMiscSection, NegumSettingsSection>();
            Register<INegumConfigurationArcadeSection, NegumSettingsSection>();
            Register<INegumConfigurationInputSection, NegumSettingsSection>();
            Register<INegumConfigurationPlayerKeysSection, NegumSettingsSection>();
        }
    }

    internal static class NegumDummyContainer
    {
        /// <summary>
        /// Contains all types registered for the application.
        /// </summary>
        private static IDictionary<Type, Type> Types { get; } = new Dictionary<Type, Type>();

        static NegumDummyContainer()
        {
        }

        public static object Resolve(Type type) =>
            Types.ContainsKey(type) ? Activator.CreateInstance(Types[type]) : null;

        public static void Register(Type interfaceType, Type implementationType) =>
            Types.Add(interfaceType, implementationType);
    }
}