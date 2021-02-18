namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Text entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ITextEntry : INegumManagerSectionEntry<ITextEntry>
    {
        /// <summary>
        /// Position of the text.
        /// </summary>
        IVectorEntry Offset { get; }

        /// <summary>
        /// Font the text.
        /// Set for -1 for none / no display.
        /// </summary>
        IVectorEntry Font { get; }

        IVectorEntry Spacing { get; }
        string Text { get; }
        IVectorEntry Window { get; }
        string TextWrap { get; }
        ITimeEntry DisplayTime { get; }
        int Layer { get; }
        IVectorEntry Scale { get; }

        /// <summary>
        /// Set to true to shake the text.
        /// </summary>
        bool Shake { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class TextEntry : NegumManagerSectionEntry<ITextEntry>, ITextEntry
    {
        public IVectorEntry Offset { get; private set; }
        public IVectorEntry Font { get; private set; }
        public IVectorEntry Spacing { get; private set; }
        public string Text { get; private set; }
        public IVectorEntry Window { get; private set; }
        public string TextWrap { get; private set; }
        public ITimeEntry DisplayTime { get; private set; }
        public int Layer { get; private set; }
        public IVectorEntry Scale { get; private set; }
        public bool Shake { get; private set; }

        public override ITextEntry Get()
        {
            this.Offset = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".offset");
            this.Font = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".font");
            this.Spacing = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".spacing");
            this.Text = this.Section.GetValue<string>(this.FieldKey + ".text");
            this.Window = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".window");
            this.TextWrap = this.Section.GetValue<string>(this.FieldKey + ".textwrap");
            this.DisplayTime = this.Section.GetValue<ITimeEntry>(this.FieldKey + ".displaytime");
            this.Layer = this.Section.GetValue<int>(this.FieldKey + ".layerno");
            this.Scale = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".scale");
            this.Shake = this.Section.GetValue<bool>(this.FieldKey + ".shake");

            return this;
        }
    }
}