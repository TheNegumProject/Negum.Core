namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents Sprite with Sound entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSoundEntry : IManagerSectionEntry<ISpriteSoundEntry>
    {
        IVectorEntry Sprite { get; }
        IVectorEntry Sound { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSoundEntry : ManagerSectionEntry<ISpriteSoundEntry>, ISpriteSoundEntry
    {
        public IVectorEntry Sprite { get; private set; }
        public IVectorEntry Sound { get; private set; }

        public override ISpriteSoundEntry Get()
        {
            this.Sprite = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".spr");
            this.Sound = this.Section.GetValue<IVectorEntry>(this.FieldKey + ".snd");

            return this;
        }
    }
}