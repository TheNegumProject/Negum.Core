namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Keys entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IKeysEntry : IManagerSectionEntry<IKeysEntry>
    {
        int Jump { get; }
        int Crouch { get; }
        int Left { get; }
        int Right { get; }
        int A { get; }
        int B { get; }
        int C { get; }
        int X { get; }
        int Y { get; }
        int Z { get; }
        int Start { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class KeysEntry : ManagerSectionEntry<IKeysEntry>, IKeysEntry
    {
        public int Jump { get; private set; }
        public int Crouch { get; private set; }
        public int Left { get; private set; }
        public int Right { get; private set; }
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int Start { get; private set; }

        public override IKeysEntry Get()
        {
            this.Jump = this.Section.GetValue<int>("Jump");
            this.Crouch = this.Section.GetValue<int>("Crouch");
            this.Left = this.Section.GetValue<int>("Left");
            this.Right = this.Section.GetValue<int>("Right");
            this.A = this.Section.GetValue<int>("A");
            this.B = this.Section.GetValue<int>("B");
            this.C = this.Section.GetValue<int>("C");
            this.X = this.Section.GetValue<int>("X");
            this.Y = this.Section.GetValue<int>("Y");
            this.Z = this.Section.GetValue<int>("Z");
            this.Start = this.Section.GetValue<int>("Start");

            return this;
        }
    }
}