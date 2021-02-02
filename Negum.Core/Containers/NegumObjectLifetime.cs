namespace Negum.Core.Containers
{
    /// <summary>
    /// Describes a lifetime of an object.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public enum NegumObjectLifetime
    {
        /// <summary>
        /// Every time new instance will be created.
        /// </summary>
        Transient,

        /// <summary>
        /// A single instance will be created.
        /// </summary>
        Singleton
    }
}