namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Fighting Team entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationTeamEntry : INegumManagerSectionEntry<IFightConfigurationTeamEntry>
    {
        IVectorEntry Position { get; }
        int StartX { get; }
        ITextEntry Counter { get; }
        ITextEntry Text { get; }
        ITimeEntry DisplayTime { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FightConfigurationTeamEntry : NegumManagerSectionEntry<IFightConfigurationTeamEntry>,
        IFightConfigurationTeamEntry
    {
        public IVectorEntry Position { get; private set; }
        public int StartX { get; private set; }
        public ITextEntry Counter { get; private set; }
        public ITextEntry Text { get; private set; }
        public ITimeEntry DisplayTime { get; private set; }

        public override IFightConfigurationTeamEntry Get()
        {
            this.Position = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".pos");
            this.StartX = this.Section.GetValue<int>(this.FieldKey + ".start.x");
            this.Counter = this.Section.GetValue<ITextEntry>(this.FieldKey + ".counter");
            this.Text = this.Section.GetValue<ITextEntry>(this.FieldKey + ".text");
            this.DisplayTime = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".displaytime");

            return this;
        }
    }
}