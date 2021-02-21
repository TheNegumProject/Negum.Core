using System;
using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Readers;

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
            try
            {
                NegumContainer.RegisterKnownTypes();
            }
            catch (Exception e)
            {
                /***
                 * Multiple tests may try to register it multiple times.
                 * This should not happen is real-life scenario.
                 */
            }
        }

        protected async Task<IConfiguration> Parse(string path)
        {
            var reader = NegumContainer.Resolve<IConfigurationReader>();
            var data = await reader.ReadAsync(path);
            return data;
        }
        
        protected async Task<IConfiguration> ParseWithSubsections(string path)
        {
            var reader = NegumContainer.Resolve<IConfigurationWithSubsectionReader>();
            var data = await reader.ReadAsync(path);
            return data;
        }
    }
}