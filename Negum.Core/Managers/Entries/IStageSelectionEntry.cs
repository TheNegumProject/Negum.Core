namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Stage entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageSelectionEntry : IManagerSectionEntry<IStageSelectionEntry>
    {
        IVectorEntry Position { get; }
        ITextEntry Active { get; }
        ITextEntry Active2 { get; }
        ITextEntry Done { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageSelectionEntry : ManagerSectionEntry<IStageSelectionEntry>, IStageSelectionEntry
    {
        public IVectorEntry Position { get; private set; }
        public ITextEntry Active { get; private set; }
        public ITextEntry Active2 { get; private set; }
        public ITextEntry Done { get; private set; }

        public override IStageSelectionEntry Get()
        {
            this.Position = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".pos");
            this.Active = this.Section.GetValue<ITextEntry>(this.FieldKey + ".active");
            this.Active2 = this.Section.GetValue<ITextEntry>(this.FieldKey + ".active2");
            this.Done = this.Section.GetValue<ITextEntry>(this.FieldKey + ".done");

            return this;
        }
    }
}