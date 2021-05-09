using System.Collections.Generic;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Contains common code for vector readers.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CommonVectorReader
    {
        protected virtual IEnumerable<string> SplitValues(string input) =>
            input.Replace(" ", "").Split(",");
    }
}