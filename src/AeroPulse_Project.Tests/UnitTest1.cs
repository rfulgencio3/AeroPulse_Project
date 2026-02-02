using AeroPulse.SharedKernel;

namespace AeroPulse_Project.Tests;

public sealed class UuidV7Tests
{
    [Fact]
    public void NewGuid_SetsVersionAndVariant()
    {
        var guid = UuidV7.NewGuid();

        Span<byte> bytes = stackalloc byte[16];
        Assert.True(guid.TryWriteBytes(bytes, true));

        var version = (bytes[6] & 0xF0) >> 4;
        var variant = (bytes[8] & 0xC0) >> 6;

        Assert.Equal(7, version);
        Assert.Equal(2, variant);
    }

    [Fact]
    public void NewGuid_EmbedsUnixMilliseconds()
    {
        var timestamp = new DateTimeOffset(2025, 1, 2, 3, 4, 5, 6, TimeSpan.Zero);
        var guid = UuidV7.NewGuid(timestamp);

        Span<byte> bytes = stackalloc byte[16];
        Assert.True(guid.TryWriteBytes(bytes, true));

        long extracted =
            ((long)bytes[0] << 40) |
            ((long)bytes[1] << 32) |
            ((long)bytes[2] << 24) |
            ((long)bytes[3] << 16) |
            ((long)bytes[4] << 8) |
            bytes[5];

        Assert.Equal(timestamp.ToUnixTimeMilliseconds(), extracted);
    }
}

public sealed class CorrelationContextTests
{
    [Fact]
    public void Begin_SetsAndRestoresCurrent()
    {
        CorrelationContext.Current = null;
        var correlationId = Guid.NewGuid();
        var causationId = Guid.NewGuid();

        using (CorrelationContext.Begin(correlationId, causationId))
        {
            Assert.NotNull(CorrelationContext.Current);
            Assert.Equal(correlationId, CorrelationContext.Current!.CorrelationId);
            Assert.Equal(causationId, CorrelationContext.Current!.CausationId);
        }

        Assert.Null(CorrelationContext.Current);
    }
}
