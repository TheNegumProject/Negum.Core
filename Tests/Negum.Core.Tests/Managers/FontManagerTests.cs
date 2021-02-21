using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Managers.Types;
using Xunit;

namespace Negum.Core.Tests.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontManagerTests : TestBase
    {
        [Theory]
        [InlineData("/Users/kdobrzynski/Downloads/mugen-1.1b1/font/f-4x6.def")]
        public async Task Should_Parse_Font(string path)
        {
            this.InitializeContainer();
            
            var config = await this.Parse(path);
            var manager = (IFontManager) NegumContainer.Resolve<IFontManager>().UseConfiguration(config);

            Assert.True(manager.Def.Type.Equals("bitmap"));
        }
    }
}