namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Keys.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IKeysEntry : IScrapperEntry<IKeysEntry>
    {
        public int Jump { get; }
        public int Crouch { get; }
        public int Left { get; }
        public int Right { get; }
        public int A { get; }
        public int B { get; }
        public int C { get; }
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public int Start { get; }
    }
}