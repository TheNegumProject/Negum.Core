using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Negum.Core.Readers.Sff.V2
{
    /// <summary>
    /// Reader used to decode SFF image using back LZ5.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffLz5Reader : IReader<IEnumerable<byte>, IEnumerable<byte>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffLz5Reader : ISffLz5Reader
    {
        public async Task<IEnumerable<byte>> ReadAsync(IEnumerable<byte> input)
        {
            var ret = new List<byte>();
            var stream = new MemoryStream(input.ToArray());
            var binaryReader = new BinaryReader(stream);
            var tmp = new List<byte>();

            while (stream.Position != stream.Length)
            {
                this.ReadLz5ControlPacket(binaryReader, out var flags);

                for (var flag = 0; flag < flags.Length; ++flag)
                {
                    if (stream.Position == stream.Length)
                    {
                        break;
                    }

                    if (flags[flag] == 0)
                    {
                        this.ReadLz5RlePacket(binaryReader, out var color, out var count);

                        for (var i = 0; i < count; ++i)
                        {
                            ret.Add(color);
                        }
                    }
                    else if (flags[flag] == 1)
                    {
                        this.ReadLz5LzPacket(binaryReader,
                            out var length, out var offset,
                            out var recycled, out var recycledBitsFilled);

                        for (var i = 0; i < length; ++i)
                        {
                            var off = ret.Count - offset + i;

                            if (off < ret.Count)
                            {
                                tmp.Add(ret[off]);
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (tmp.Count < length && tmp.Count != 0)
                        {
                            var count = tmp.Count;
                            var len = (length - count) / count;
                            var tmp2 = tmp.GetRange(0, tmp.Count);

                            for (var i = 0; i < len; ++i)
                            {
                                tmp.AddRange(tmp2);
                            }

                            tmp.AddRange(tmp2.GetRange(0, (length - count) % count));
                        }

                        ret.AddRange(tmp);
                    }
                }
            }

            binaryReader.Close();
            stream.Close();

            return await Task.FromResult(ret.ToArray());
        }

        protected virtual void ReadLz5ControlPacket(BinaryReader binaryReader, out byte[] flags)
        {
            flags = new byte[8];

            var firstByte = binaryReader.ReadByte();

            flags[7] = (byte) ((firstByte & 128) / 128);
            flags[6] = (byte) ((firstByte & 64) / 64);
            flags[5] = (byte) ((firstByte & 32) / 32);
            flags[4] = (byte) ((firstByte & 16) / 16);
            flags[3] = (byte) ((firstByte & 8) / 8);
            flags[2] = (byte) ((firstByte & 4) / 4);
            flags[1] = (byte) ((firstByte & 2) / 2);
            flags[0] = (byte) (firstByte & 1);
        }

        protected virtual void ReadLz5RlePacket(BinaryReader binaryReader, out byte color, out int count)
        {
            var b = binaryReader.ReadByte();
            count = (b & 224) >> 5;

            if (count == 0)
            {
                var b2 = binaryReader.ReadByte();
                count = b2 + 8;
            }

            color = (byte) (b & 31);
        }

        protected virtual void ReadLz5LzPacket(BinaryReader binaryReader,
            out int length, out int offset,
            out byte recycled, out byte recycledBitsFilled)
        {
            var b = binaryReader.ReadByte();
            byte b2, b3, tmp;

            length = b & 63;
            recycled = 0;
            recycledBitsFilled = 0;
            offset = 0;

            if (length == 0)
            {
                b2 = binaryReader.ReadByte();
                b3 = binaryReader.ReadByte();
                offset = (b & 192) * 4 + b2 + 1;
                length = b3 + 3;
            }
            else
            {
                length++;
                tmp = (byte) (b & 192);

                if (recycledBitsFilled == 2)
                {
                    tmp >>= 2;
                }

                if (recycledBitsFilled == 4)
                {
                    tmp >>= 4;
                }

                if (recycledBitsFilled == 6)
                {
                    tmp >>= 6;
                }

                recycled += tmp;
                recycledBitsFilled += 2;

                switch (recycledBitsFilled)
                {
                    case < 8:
                        b2 = binaryReader.ReadByte();
                        offset = b2;
                        break;
                    case 8:
                        offset = recycled;
                        recycled = 0;
                        recycledBitsFilled = 0;
                        break;
                }

                offset += 1;
            }
        }
    }
}