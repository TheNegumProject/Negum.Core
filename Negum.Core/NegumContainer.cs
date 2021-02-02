using System;
using System.Collections.Generic;

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
        }
    }

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
            if (!Instances.ContainsKey(interfaceType) && Types.ContainsKey(interfaceType))
            {
                Instances.Add(interfaceType, Activator.CreateInstance(Types[interfaceType]));
            }

            return Instances.ContainsKey(interfaceType) ? Instances[interfaceType] : null;
        }

        public static void Register(Type interfaceType, Type implementationType) =>
            Types.Add(interfaceType, implementationType);
    }
}