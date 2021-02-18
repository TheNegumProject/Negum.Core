namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Responsible for parsing single int value.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class IntEntry : NegumManagerSectionEntry<int>
    {
        public override int Get() => int.Parse(this.SectionEntryContent);
    }
}