using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Engines;
using Negum.Core.Managers.Types;
using Negum.Core.Models.Fonts;
using Negum.Core.Readers;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Loader used to get all currently available Fonts.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFontLoader : IEngineModuleLoader<IEnumerable<IFont>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontLoader : AbstractLoader, IFontLoader
    {
        public async Task<IEnumerable<IFont>> LoadAsync(IEngine engine)
        {
            var sources = this.GetFiles(engine, "font")
                .Where(file => file.Extension.Equals(".def") || file.Extension.Equals(".fnt"));

            return await this.LoadMultipleAsync(sources, this.GetFontAsync);
        }

        protected virtual async Task<IFont> GetFontAsync(FileInfo file)
        {
            var font = new Font
            {
                File = file,
                IsRaw = file.Extension.Equals(".fnt")
            };

            if (!font.IsRaw)
            {
                var reader = NegumContainer.Resolve<IConfigurationWithSubsectionReader>();
                var configuration = await reader.ReadAsync(file.FullName);

                font.Manager = (IFontManager) NegumContainer.Resolve<IFontManager>().UseConfiguration(configuration);

                var path = Path.Combine(file.DirectoryName, font.Manager.Def.File);

                if (File.Exists(path))
                {
                    var spritePathReader = NegumContainer.Resolve<ISpritePathReader>();
                    var glyphs = await spritePathReader.ReadAsync(path);

                    font.Sprite = glyphs;
                }
            }

            return font;
        }
    }
}