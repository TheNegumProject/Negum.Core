namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Responsible for parsing single boolean value.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class BooleanEntry : NegumManagerSectionEntry<bool>
    {
        public override bool Get() =>
            this.Entry.Value switch
            {
                "0" => false,
                "1" => true,
                _ => bool.Parse(this.Entry.Value)
            };
    }
}