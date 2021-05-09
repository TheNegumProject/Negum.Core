using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Readers;
using Xunit;

namespace Negum.Core.Tests.Readers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontReaderTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/UnpackedMugen-main/font/jg.fnt")]
        public async Task Should_Read_Font_NoDef(string path)
        {
            NegumContainer.RegisterKnownTypes();

            var reader = NegumContainer.Resolve<IFontPathReader>();
            var font = await reader.ReadAsync(path);

            Assert.NotNull(font);
        }
    }
}