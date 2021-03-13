using System;
using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;
using Negum.Core.Engines;
using Negum.Core.Loaders;
using Negum.Core.Managers;
using Negum.Core.Managers.Entries;
using Negum.Core.Managers.Types;
using Negum.Core.Readers;

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
        /// <param name="interfaceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="lifetime"></param>
        public static void Register(Type interfaceType, Type implementationType,
            NegumObjectLifetime lifetime = NegumObjectLifetime.Transient)
        {
            if (!interfaceType.IsInterface || !implementationType.IsClass)
            {
                return;
            }

            Registerer(lifetime, interfaceType, implementationType);
        }

        /// <summary>
        /// Registers new type.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <typeparam name="TClass">Implementation type.</typeparam>
        public static void Register<TInterface, TClass>(NegumObjectLifetime lifetime = NegumObjectLifetime.Transient)
            where TClass : class, TInterface =>
            Register(typeof(TInterface), typeof(TClass), lifetime);

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
            // Configurations
            RegisterMultiple(typeof(IConfiguration).Namespace, typeof(IConfiguration),
                (type, baseType) => type);

            // Readers
            RegisterInterfaceClassPairs(typeof(IReader<,>).Namespace, typeof(IReader<,>));

            // Negum Manager Section Entries
            RegisterMultiple(typeof(StringEntry).Namespace, typeof(IManagerSectionEntry<>),
                (type, baseType) => type.GetInterfaces().FirstOrDefault(i => i.GetGenericTypeDefinition() == baseType));

            // Managers Entries + Sections
            RegisterMultiple(typeof(IConfigurationManager).Namespace, typeof(IManager),
                (type, baseType) =>
                {
                    type.GetInterfaces()
                        .Where(i => i.GetGenericArguments().Length == 0)
                        .ToList()
                        .ForEach(sectionInterfaceType => Register(sectionInterfaceType, type));

                    return type;
                });

            // Loaders
            RegisterInterfaceClassPairs(typeof(ILoader<,>).Namespace, typeof(ILoader<,>));
            
            // Engine
            RegisterInterfaceClassPairs(typeof(IEngineProvider).Namespace, typeof(IEngineProvider));
        }

        /// <summary>
        /// Registers multiple types from given namespace using a principle that class name must be equal with interface name without "I" prefix.
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="rootType"></param>
        public static void RegisterInterfaceClassPairs(string @namespace, Type rootType)
        {
            RegisterMultiple(@namespace, rootType,
                (type, baseType) =>
                    type.GetInterfaces().FirstOrDefault(i =>
                        i.GetGenericArguments().Length == 0 && i.Name.Equals("I" + type.Name)));
        }

        /// <summary>
        /// Registers multiple types from given namespace.
        /// </summary>
        /// <param name="namespace">Namespace name</param>
        /// <param name="baseType"></param>
        public static void RegisterMultiple(string @namespace, Type baseType, Func<Type, Type, Type> func)
        {
            baseType.Assembly.GetTypes()
                .Where(t => t.Namespace.StartsWith(@namespace) && t.IsClass && !t.IsAbstract)
                .ToList()
                .ForEach(type =>
                {
                    var inType = func?.Invoke(type, baseType);

                    if (inType == null)
                    {
                        return;
                    }

                    Register(inType, type);
                });
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