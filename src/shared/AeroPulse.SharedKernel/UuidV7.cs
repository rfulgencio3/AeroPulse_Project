using System.Security.Cryptography;

namespace AeroPulse.SharedKernel;

public static class UuidV7
{
    public static Guid NewGuid()
    {
        return NewGuid(SystemClock.Instance.UtcNow);
    }

    public static Guid NewGuid(DateTimeOffset timestamp)
    {
        var unixMilliseconds = timestamp.ToUnixTimeMilliseconds();
        if (unixMilliseconds < 0)
        {
            unixMilliseconds = 0;
        }

        Span<byte> bytes = stackalloc byte[16];
        bytes[0] = (byte)(unixMilliseconds >> 40);
        bytes[1] = (byte)(unixMilliseconds >> 32);
        bytes[2] = (byte)(unixMilliseconds >> 24);
        bytes[3] = (byte)(unixMilliseconds >> 16);
        bytes[4] = (byte)(unixMilliseconds >> 8);
        bytes[5] = (byte)unixMilliseconds;

        Span<byte> random = stackalloc byte[10];
        RandomNumberGenerator.Fill(random);

        bytes[6] = (byte)(0x70 | (random[0] & 0x0F));
        bytes[7] = random[1];
        bytes[8] = (byte)(0x80 | (random[2] & 0x3F));
        bytes[9] = random[3];
        bytes[10] = random[4];
        bytes[11] = random[5];
        bytes[12] = random[6];
        bytes[13] = random[7];
        bytes[14] = random[8];
        bytes[15] = random[9];

        return new Guid(bytes, true);
    }
}
