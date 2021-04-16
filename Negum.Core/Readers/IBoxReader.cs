using System.Threading.Tasks;
using Negum.Core.Models.Math;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is used to read box.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IBoxReader : IReader<IVector<string>, IBox>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class BoxReader : IBoxReader
    {
        public async Task<IBox> ReadAsync(IVector<string> input)
        {
            IPoint p1 = null, p2 = null;

            if (int.TryParse(input[0], out var x1) && int.TryParse(input[1], out var y1))
            {
                p1 = new Point(x1, y1);
            }

            if (int.TryParse(input[2], out var x2) && int.TryParse(input[3], out var y2))
            {
                p2 = new Point(x2, y2);
            }

            var box = new Box(p1, p2);

            return box;
        }
    }
}