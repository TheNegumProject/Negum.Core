using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negum.Core.Cleaners
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationCleaner : IConfigurationCleaner
    {
        private const string CommentSymbol = ";";

        public async Task<IEnumerable<string>> CleanAsync(IEnumerable<string> input) =>
            await Task.FromResult(input
                    .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove empty line
                    .Select(line => line.TrimStart()) // Remove whitespaces at the beginning of the line
                    .Where(line => !line.StartsWith(CommentSymbol)) // Remove lines which start from comment
                    .Select(RemoveComment) // Removes comment at the end of the line
                    .Select(line => line.TrimEnd()) // Remove white spaces at the end of the line);
            );

        private static string RemoveComment(string line)
        {
            var index = line.IndexOf(CommentSymbol, StringComparison.Ordinal);
            return index > 0 ? line.Substring(0, index) : line;
        }
    }
}