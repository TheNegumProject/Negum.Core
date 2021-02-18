namespace Negum.Core.Managers
{
    /// <summary>
    /// Root manager's section definition.
    /// Sections are what configurations are divided by.
    /// It represent single area of configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumManagerSection
    {
        /// <summary>
        /// Name of the current section.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>Value parsed to specified type</returns>
        TValue GetValue<TValue>(string fieldKey);
    }
}