using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Negum.Core.Tests
{
    public class FileReadingTests
    {
        [Fact]
        public void Should_Read_CFG_File()
        {
            const string path = "/Users/kdobrzynski/Downloads/mugen-1.1b1/data/mugen.cfg";
            var file = File
                .ReadAllLines(path)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.TrimStart())
                .Where(line => !line.StartsWith(';'))
                .ToList();

            var text = File.ReadAllText(path);
            var bytes = Encoding.ASCII.GetBytes(text);
            var stream = new MemoryStream(bytes);
            var reader = new StreamReader(stream);
            var readText = reader.ReadToEnd();
            var lines = readText.Replace('\r', char.Parse(" ")).Split(Environment.NewLine);

            Assert.True(file.Count > 0);
        }
    }
}