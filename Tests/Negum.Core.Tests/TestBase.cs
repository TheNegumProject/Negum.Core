using Negum.Core.Containers;

namespace Negum.Core.Tests
{
    /// <summary>
    /// Base class for all tests.
    /// All tests are performed for as much raw engine as possible.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class TestBase
    {
        protected void InitializeContainer()
        {
            NegumContainer.RegisterKnownTypes();
        }
    }
}