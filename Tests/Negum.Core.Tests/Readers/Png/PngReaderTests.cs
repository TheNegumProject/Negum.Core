using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;
using Negum.Core.Readers.Sff.V2;
using Xunit;

namespace Negum.Core.Tests.Readers.Png
{
    public class PngReaderTests
    {
        [Theory]
        [InlineData("control3-60x10-256-noI-noT-noD.png")]
        [InlineData("control3-60x10-256-I-noT-noD.png")]
        [InlineData("control3-60x10-256-noI-T-noD.png")]
        [InlineData("control3-60x10-256-I-T-noD.png")]
        public async Task Should_Read_PNG(string pictureName)
        {
            const string directoryPath = "/Users/kdobrzynski/Dev/Negum.Core/Tests/Negum.Core.Tests/Readers/Png/Pics";

            var path = Path.Combine(directoryPath, pictureName);
            
            NegumContainer.RegisterKnownTypes();
            
            var rawBytes = await File.ReadAllBytesAsync(path);

            var reader = NegumContainer.Resolve<ISffPngReader>();

            var context = new SffPngReaderContext
            {
                PngFormat = 8,
                RawImage = rawBytes
            };
            
            var parsedImage = await reader.ReadAsync(context);
            
            Assert.NotNull(parsedImage);
        }
    }
}