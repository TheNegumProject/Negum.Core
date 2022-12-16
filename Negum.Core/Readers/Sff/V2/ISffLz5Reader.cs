using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Negum.Core.Readers.Sff.V2;

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
        var lz5ControlPacket = new Lz5ControlPacket();
        var lz5RlePacket = new Lz5RlePacket();
        var lz5LzPacket = new Lz5LzPacket();
        var tmp = new List<byte>();

        while (stream.Position != stream.Length)
        {
            lz5ControlPacket.FromStream(binaryReader);

            for (var flag = 0; flag < lz5ControlPacket.Flags.Length; ++flag)
            {
                if (stream.Position == stream.Length)
                {
                    break;
                }

                if (lz5ControlPacket.Flags[flag] == 0)
                {
                    lz5RlePacket.FromStream(binaryReader);

                    for (var i = 0; i < lz5RlePacket.Count; ++i)
                    {
                        ret.Add(lz5RlePacket.Color);
                    }
                }
                else if (lz5ControlPacket.Flags[flag] == 1)
                {
                    lz5LzPacket.FromStream(binaryReader);

                    for (var i = 0; i < lz5LzPacket.Length; ++i)
                    {
                        var off = ret.Count - lz5LzPacket.Offset + i;

                        if (off < ret.Count)
                        {
                            tmp.Add(ret[off]);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (tmp.Count < lz5LzPacket.Length && tmp.Count != 0)
                    {
                        var count = tmp.Count;
                        var len = (lz5LzPacket.Length - count) / count;
                        var tmp2 = tmp.GetRange(0, tmp.Count);

                        for (var i = 0; i < len; ++i)
                        {
                            tmp.AddRange(tmp2);
                        }

                        tmp.AddRange(tmp2.GetRange(0, (lz5LzPacket.Length - count) % count));
                    }

                    ret.AddRange(tmp);
                }
            }
        }

        binaryReader.Close();
        stream.Close();

        return await Task.FromResult(ret.ToArray());
    }
}

public interface ILz5StreamReader
{
    void FromStream(BinaryReader br);
}
    
public class Lz5ControlPacket : ILz5StreamReader
{
    public byte[] Flags { get; private set; } = Array.Empty<byte>();
        
    public void FromStream(BinaryReader br)
    {
        Flags = new byte[8];

        var firstByte = br.ReadByte();

        Flags[7] = (byte) ((firstByte & 128) / 128);
        Flags[6] = (byte) ((firstByte & 64) / 64);
        Flags[5] = (byte) ((firstByte & 32) / 32);
        Flags[4] = (byte) ((firstByte & 16) / 16);
        Flags[3] = (byte) ((firstByte & 8) / 8);
        Flags[2] = (byte) ((firstByte & 4) / 4);
        Flags[1] = (byte) ((firstByte & 2) / 2);
        Flags[0] = (byte) (firstByte & 1);
    }
}

public class Lz5RlePacket : ILz5StreamReader
{
    public byte Color { get; private set; }
    public int Count { get; private set; }
        
    public void FromStream(BinaryReader br)
    {
        var b = br.ReadByte();
        Count = (b & 224) >> 5;

        if (Count == 0)
        {
            var b2 = br.ReadByte();
            Count = b2 + 8;
        }

        Color = (byte) (b & 31);
    }
}

public class Lz5LzPacket : ILz5StreamReader
{
    public int Length { get; private set; }
    public int Offset { get; private set; }
    public byte Recycled { get; private set; }
    public byte RecycledBitsFilled { get; private set; }
        
    public void FromStream(BinaryReader br)
    {
        var b = br.ReadByte();
        byte b2, b3, tmp;

        Length = b & 63;

        if (Length == 0)
        {
            b2 = br.ReadByte();
            b3 = br.ReadByte();
            Offset = (b & 192) * 4 + b2 + 1;
            Length = b3 + 3;
        }
        else
        {
            Length++;
            tmp = (byte) (b & 192);

            if (RecycledBitsFilled == 2)
            {
                tmp >>= 2;
            }

            if (RecycledBitsFilled == 4)
            {
                tmp >>= 4;
            }

            if (RecycledBitsFilled == 6)
            {
                tmp >>= 6;
            }

            Recycled += tmp;
            RecycledBitsFilled += 2;

            switch (RecycledBitsFilled)
            {
                case < 8:
                    b2 = br.ReadByte();
                    Offset = b2;
                    break;
                case 8:
                    Offset = Recycled;
                    Recycled = 0;
                    RecycledBitsFilled = 0;
                    break;
            }

            Offset += 1;
        }
    }
}