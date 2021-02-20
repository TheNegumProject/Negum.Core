namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Responsible for parsing single string value.
    /// This is simple mock-up for string values to work in the system.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StringEntry : NegumManagerSectionEntry<string>
    {
        public override string Get() => this.Entry.Value;
    }
}