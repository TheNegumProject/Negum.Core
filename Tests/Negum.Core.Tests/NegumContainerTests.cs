using Xunit;

namespace Negum.Core.Tests
{
    public class NegumContainerTests
    {
        [Fact]
        public void Should_Create_New_Engine_Instance()
        {
            NegumContainer.RegisterKnownTypes();
            var engine = NegumEngine.Instance;
            var value = engine.Configuration.Settings.Sound.BufferSize;
            
            Assert.True(value > 0);

            const int newSize = 100;
            engine.Configuration.Settings.Sound.BufferSize = newSize;
            
            Assert.True(engine.Configuration.Settings.Sound.BufferSize == newSize);
        }
    }
}