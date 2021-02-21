namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Fighting Player Win Types entry in section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationWinEntry : IManagerSectionEntry<IFightConfigurationWinEntry>
    {
        /// <summary>
        /// Win by normal.
        /// </summary>
        IImageEntry Normal { get; }

        /// <summary>
        /// Win by special.
        /// </summary>
        IImageEntry Special { get; }

        /// <summary>
        /// Win by hyper (super).
        /// </summary>
        IImageEntry Hyper { get; }

        /// <summary>
        /// Win by normal throw.
        /// </summary>
        IImageEntry Throw { get; }

        /// <summary>
        /// Win by cheese.
        /// </summary>
        IImageEntry Cheese { get; }

        /// <summary>
        /// Win by time over.
        /// </summary>
        IImageEntry TimeOver { get; }

        /// <summary>
        /// Win by suicide.
        /// </summary>
        IImageEntry Suicide { get; }

        /// <summary>
        /// Opponent beaten by his own teammate.
        /// </summary>
        IImageEntry Teammate { get; }

        /// <summary>
        /// Win by perfect.
        /// </summary>
        IImageEntry Perfect { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FightConfigurationWinEntry : ManagerSectionEntry<IFightConfigurationWinEntry>,
        IFightConfigurationWinEntry
    {
        public IImageEntry Normal { get; private set; }
        public IImageEntry Special { get; private set; }
        public IImageEntry Hyper { get; private set; }
        public IImageEntry Throw { get; private set; }
        public IImageEntry Cheese { get; private set; }
        public IImageEntry TimeOver { get; private set; }
        public IImageEntry Suicide { get; private set; }
        public IImageEntry Teammate { get; private set; }
        public IImageEntry Perfect { get; private set; }

        public override IFightConfigurationWinEntry Get()
        {
            this.Normal = this.Section.GetValue<IImageEntry>(this.FieldKey + ".n");
            this.Special = this.Section.GetValue<IImageEntry>(this.FieldKey + ".s");
            this.Hyper = this.Section.GetValue<IImageEntry>(this.FieldKey + ".h");
            this.Throw = this.Section.GetValue<IImageEntry>(this.FieldKey + ".throw");
            this.Cheese = this.Section.GetValue<IImageEntry>(this.FieldKey + ".c");
            this.TimeOver = this.Section.GetValue<IImageEntry>(this.FieldKey + ".t");
            this.Suicide = this.Section.GetValue<IImageEntry>(this.FieldKey + ".suicide");
            this.Teammate = this.Section.GetValue<IImageEntry>(this.FieldKey + ".teammate");
            this.Perfect = this.Section.GetValue<IImageEntry>(this.FieldKey + ".perfect");

            return this;
        }
    }
}