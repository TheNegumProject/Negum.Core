using System;

namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// Info section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationInfoSection : INegumConfigurationSection
    {
        public const string NameKey = "name";
        public const string AuthorKey = "author";
        public const string VersionDateKey = "versiondate";
        public const string VersionKey = "version";
        public const string LocalCoordKey = "localcoord";

        /// <summary>
        /// Name of motif.
        /// </summary>
        string Name
        {
            get => this.GetOrDefault(NameKey, "Negum");
            set => this.SetNewValue(NameKey, value);
        }

        /// <summary>
        /// Motif author name.
        /// </summary>
        string Author
        {
            get => this.GetOrDefault(AuthorKey, "The Negum Project");
            set => this.SetNewValue(AuthorKey, value);
        }

        /// <summary>
        /// Version date of motif.
        /// </summary>
        DateTime VersionDate
        {
            get => this.GetOrDefault(VersionDateKey, DateTime.Parse("2021-02-01"));
            set => this.SetNewValue(VersionDateKey, value);
        }

        /// <summary>
        /// Version of motif is compatible with.
        /// </summary>
        float Version
        {
            get => this.GetOrDefault(VersionKey, 0.1f);
            set => this.SetNewValue(VersionKey, value);
        }

        /// <summary>
        /// Local coordinate space width and height.
        /// </summary>
        string LocalCoord
        {
            get => this.GetOrDefault(LocalCoordKey, "320,240");
            set => this.SetNewValue(LocalCoordKey, value);
        }
    }
}